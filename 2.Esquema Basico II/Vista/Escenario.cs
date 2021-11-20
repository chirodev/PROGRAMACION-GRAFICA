using OpenTK.Mathematics;
using System;
using OpenTK.Graphics.OpenGL;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Juego
{
    class Escenario : Objeto, IObjeto
    {
        public Dictionary<string, Objeto> listaDeObjetos;
        public Escenario()
        {
            listaDeObjetos = new Dictionary<string, Objeto>();
        }
        public void addDibujo(string nombre,Objeto act)
        {
            listaDeObjetos.Add(nombre,act);
        }
        public override void Dibujar()
        {
            foreach (KeyValuePair<string, Objeto> Dibujador in listaDeObjetos)
            {
                Dibujador.Value.Dibujar();
            }
        }

        public override void rotar(float angle, float x, float y, float z)
        {
            foreach (KeyValuePair<string, Objeto> aux in listaDeObjetos)
            {
                aux.Value.rotar(angle, x, y, z);
            };
        }
        public override void Traslacion(float trasX, float trasY, float trasZ)
        {
            foreach (KeyValuePair<string, Objeto> aux in listaDeObjetos)
            {
                aux.Value.Traslacion(trasX, trasY, trasZ);
            };
        }

    }
}
