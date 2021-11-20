using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Mathematics;
namespace Juego
{
    public abstract class Objeto : IObjeto
    {
        public Dictionary<string, Objeto> listadepartes;
        public abstract void Dibujar();
        public abstract void rotar(float angle, float x, float y, float z);
        public abstract void Traslacion(float trasX, float trasY, float trasZ);
    }
}
