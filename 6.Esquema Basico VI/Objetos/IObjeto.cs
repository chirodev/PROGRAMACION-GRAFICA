using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Mathematics;
namespace Juego
{
    public abstract class IObjeto : Interface
    {
        public Dictionary<string, IObjeto> listadepartes= new Dictionary<string, IObjeto>();
        public static bool rotacionTotal;
        public abstract void Dibujar();
        public abstract void rotar(float angle, float x, float y, float z,Vector3 origen);
        public abstract void Traslacion(float trasX, float trasY, float trasZ);
        public abstract void Escala(float num);

    }
}
