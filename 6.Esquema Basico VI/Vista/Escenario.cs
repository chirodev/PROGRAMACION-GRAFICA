using OpenTK.Mathematics;
using System;
using OpenTK.Graphics.OpenGL;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Juego
{
    class Escenario : IObjeto,Interface
    {
        public Dictionary<string, IObjeto> listaDeObjetos;
        public Escenario()
        {
            listaDeObjetos = new Dictionary<string, IObjeto>();
        }
        public void addDibujo(string nombre,IObjeto act)
        {
            listaDeObjetos.Add(nombre,act);
        }
        public override void Dibujar()
        {
            foreach (KeyValuePair<string, IObjeto> Dibujador in listaDeObjetos)
            {
                Dibujador.Value.Dibujar();
            }
        }

        public override void rotar(float angle, float x, float y, float z, Vector3 origen)
        {
            rotacionTotal = true;
            foreach (KeyValuePair<string, IObjeto> aux in listaDeObjetos)
            {
                aux.Value.rotar(angle, x, y, z,origen);
            };
            rotacionTotal = false;
        }
        public override void Traslacion(float trasX, float trasY, float trasZ)
        {
            foreach (KeyValuePair<string, IObjeto> aux in listaDeObjetos)
            {
                aux.Value.Traslacion(trasX, trasY, trasZ);
            };
        }
        public override void Escala(float num)
        {

            foreach (KeyValuePair<string, IObjeto> aux in listaDeObjetos)
            {
                aux.Value.Escala(num);
            };
        }

    }
}
