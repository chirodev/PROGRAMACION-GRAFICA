using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Juego
{
    class silla : Objeto
    {
        public Vector3 pos;
        public Vector3 tras;
        float sca;
        public Vector3 eje;
        public Vector3 Angulo;
        public Vector2 X;
        public Vector2 Y;
        float Ancho;
        float Largo;
        float Alto;
        Pieza pata1;
        Pieza pata2;
        Pieza pata3;
        Pieza pata4;
        Pieza sillon;
        Pieza espaldar;
        public silla(Vector3 Posicion, float escala, Vector2 x, Vector2 y, float ancho, float alto, float largo)
        {
            pos = new Vector3(0, 0, 0);
            Ancho = ancho;
            Largo = largo;
            Alto = alto;
            eje = new Vector3(Posicion.X, Posicion.Y, Posicion.Z);
            tras = eje;
            sca = escala;
            X = x;
            Y = y;
            LoadPiezas();
        }
        public void LoadPiezas() {
            float lar;
            if (Ancho > Largo)
            {
                lar = Ancho;
            }
            else
            {
                lar = Largo;
            }
          //  pata1 = new Pieza(pos, new Vector3(-(Ancho / 4), Alto / 2, eje.Z), sca, Ancho / 8, Largo / 8, Alto / 2, X, Y,pos);
            pata2 = new Pieza(new Vector3(0,0,0), new Vector3((Ancho / 4), Alto / 2, eje.Z), sca, Ancho / 8, Largo / 8, Alto / 2, X, Y, new Vector3(-1f,0,0));
           // pata3 = new Pieza(pos, new Vector3(-(Ancho / 4), Alto / 2, -8f), sca, Ancho / 8, Largo / 8, Alto / 2, X, Y);
           // sillon = new Pieza(pos, new Vector3(-(Ancho / 4), Alto / 2, eje.Z), sca, Ancho / 2, Largo / 1.6f, Alto / 8, X, Y);
            listaDePiezas = new Dictionary<string, Objeto>() { 
            //   {"sillon", sillon },
              //  {"espaldar",espaldar},
              // { "pata1", pata1},
               { "pata2", pata2 }
              //{ "pata3", pata3},
               //{ "pata4", pata4}
               };
            /*pata1 = new Pieza(new Vector3(pos.X + Largo * 10 / 100, pos.Y - Alto * 5 / 100, pos.Z - Ancho * 10 / 100), tras, sca, lar * 15 / 100, lar * 15 / 100, Alto * 45 / 100 - Alto * 5 / 100, X, Y);
            pata2 = new Pieza(new Vector3(pos.X + Largo * 10 / 100, pos.Y - Alto * 5 / 100, pos.Z - Ancho + Ancho * 10 / 100 + lar * 15 / 100), tras, sca, lar * 15 / 100, lar * 15 / 100, Alto * 45 / 100 - Alto * 5 / 100, X, Y);
            pata3 = new Pieza(new Vector3(pos.X + Largo - Largo * 10 / 100 - lar * 15 / 100, pos.Y - Alto * 5 / 100, pos.Z - Ancho * 10 / 100), tras, sca, lar * 15 / 100, lar * 15 / 100, Alto * 45 / 100 - Alto * 5 / 100, X, Y);
            pata4 = new Pieza(new Vector3(pos.X + Largo - Largo * 10 / 100 - lar * 15 / 100, pos.Y - Alto * 5 / 100, pos.Z - Ancho + Ancho * 10 / 100 + lar * 15 / 100), tras, sca, lar * 15 / 100, lar * 15 / 100, Alto * 45 / 100 - Alto * 5 / 100, X, Y);
            sillon = new Pieza(pos, tras, sca, Ancho, Largo, Alto * 5 / 100, X, Y);
            espaldar = new Pieza(new Vector3(pos.X, pos.Y, pos.Z - Ancho + Ancho * 10 / 100), tras, sca, Ancho * 10 / 100, Largo, -Alto * 50 / 100, X, Y);
            listaDePiezas = new Dictionary<string, Objeto>() {
                {"sillon", sillon },
                {"espaldar",espaldar},
                {"pata1", pata1},
                {"pata2", pata2 },
                {"pata3", pata3},
                {"pata4", pata4}
               };*/


        }
        public override void Dibujar()
        {
            foreach (KeyValuePair<string, Objeto> Dibujador in listaDePiezas)
            {
                Dibujador.Value.Dibujar();
            }
        }
        
    }   
}
