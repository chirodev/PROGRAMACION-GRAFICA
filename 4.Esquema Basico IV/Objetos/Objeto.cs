using GraficaCubo;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using System.IO;
using System.Text;
using GraficaCubo.Controladores;
using OpenTK.Mathematics;

namespace Juego
{
    class Objeto : IObjeto
    {
        List<CoordenadasPiezas> coordenadas;
        CoordenadasObjeto casaCordenadas;
        Vector3 posicionInicial;
        Vector3 posicion;
        public Objeto(string path)
        {
            posicionInicial = new Vector3(-2, 2, 0);
            string pathcasa = @"coordenadas.json";

            string json = getJson(pathcasa);
            coordenadas = JsonConvert.DeserializeObject<List<CoordenadasPiezas>>(json);
            for (int i = 0; i < coordenadas.Count; i++)
            {
                cubo parte = new cubo(coordenadas[i]);
                listadepartes.Add(coordenadas[i].nombre, parte);
            }
            json = getJson(path);
            Traslacion(posicionInicial.X, posicionInicial.Y, posicionInicial.Z);
            casaCordenadas = JsonConvert.DeserializeObject<CoordenadasObjeto>(json);
            posicion = new Vector3(posicionInicial.X + casaCordenadas.X,
                       posicionInicial.Y + casaCordenadas.Y,
                       posicionInicial.Z + casaCordenadas.Z);

            Traslacion(posicion.X, posicion.Y,posicion.Z);
            
        }
        public string getJson(string path)
        {           
            string json;
            using (StreamReader jsonStream = File.OpenText(path))
            {
                 json = jsonStream.ReadToEnd();
            }
            return json;
        }
        public override void Dibujar()
        {
            
            foreach (KeyValuePair<string, IObjeto> Dibujador in listadepartes)
            {
                Dibujador.Value.Dibujar();
            }
            

        }
        public override void rotar(float angle, float x, float y, float z,Vector3 origen)
       {

            
            foreach (KeyValuePair<string, IObjeto> aux in listadepartes)
            {
                aux.Value.rotar(angle, x, y, z,new Vector3(1,0,0));
            };        
      

        }
    public override void Traslacion(float trasX, float trasY, float trasZ)
    {
            foreach (KeyValuePair<string, IObjeto> aux in listadepartes)
            {
                aux.Value.Traslacion(trasX, trasY, trasZ);
            };
            
        }
        public override void Escala(float num)
        {

            foreach (KeyValuePair<string, IObjeto> aux in listadepartes)
            {
                aux.Value.Escala(num);
            };
        }
    }
}
