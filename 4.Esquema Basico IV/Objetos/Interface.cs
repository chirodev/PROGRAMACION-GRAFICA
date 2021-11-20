using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Mathematics;

namespace Juego
{
    interface Interface
    {

        void Dibujar();
        void rotar(float angle, float x, float y, float z, Vector3 origen);
        void Traslacion(float trasX, float trasY, float trasZ);
        void Escala(float num);

    }
}
