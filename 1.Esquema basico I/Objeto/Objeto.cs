using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Mathematics;
namespace Juego
{
    public abstract class Objeto : IObjeto
    {
        public Dictionary<string, Objeto> listaDePiezas;
        public abstract void Dibujar();
   
    }
}
