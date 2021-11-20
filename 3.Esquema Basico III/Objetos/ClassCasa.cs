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
    class ClassCasa : Objeto
    {
        List<CoordenadasCasa> coordenadas;
        CoordenadasObjeto casaCordenadas;
        Vector3 posicionInicial;
        public ClassCasa(string path)
        {
            posicionInicial = new Vector3(-2, 2, 0);
            string pathcasa = @"coordenadas.json";
            listadepartes = new Dictionary<string, Objeto>();
            string json = getJson(pathcasa);
            coordenadas = JsonConvert.DeserializeObject<List<CoordenadasCasa>>(json);
            for (int i = 0; i < coordenadas.Count; i++)
            {              
                cubo parte = new cubo(coordenadas[i]);
                listadepartes.Add(coordenadas[i].nombre ,parte);
            }
            json = getJson(path);
            Traslacion(posicionInicial.X,posicionInicial.Y,posicionInicial.Z);


            casaCordenadas = JsonConvert.DeserializeObject<CoordenadasObjeto>(json);
            Traslacion(posicionInicial.X+casaCordenadas.X, 
                       posicionInicial.Y+casaCordenadas.Y,
                       posicionInicial.Z+casaCordenadas.Z);
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

            foreach (KeyValuePair<string, Objeto> Dibujador in listadepartes)
            {
                Dibujador.Value.Dibujar();
            }

        }


        public override void rotar(float angle, float x, float y, float z)
    {
            foreach (KeyValuePair<string, Objeto> aux in listadepartes)
            {
                aux.Value.rotar(angle, x, y, z);
            };


        }
    public override void Traslacion(float trasX, float trasY, float trasZ)
    {
            foreach (KeyValuePair<string, Objeto> aux in listadepartes)
            {
                aux.Value.Traslacion(trasX, trasY, trasZ);
            };
        }
}
}
