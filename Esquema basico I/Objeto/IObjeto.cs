using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Mathematics;

namespace Juego
{
    interface IObjeto
    {
   
        void Dibujar();
        void escalar(float sca);
        void rotar(float angle, float x, float y, float z);
        void Traslacion(float trasX, float trasY, float trasZ);
    }
}
