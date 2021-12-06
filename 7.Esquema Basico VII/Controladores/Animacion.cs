using Juego;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace FormularioGrafica.Controladores
{
    class Animacion
    {
        public bool ejecutar;

        public Pantalla pant;
        List<Escenas> escenas1;
        float TiempoTotal;
        public Animacion(Pantalla p)
        {
            ejecutar = false;
            pant = p;
        }
        public void play(string animacion)
        {           
            string jsonfile;
            using (var reader = new StreamReader(animacion))
            {
                jsonfile = reader.ReadToEnd();
            }
            var jsonDes = jsonfile;
            escenas1 = JsonConvert.DeserializeObject<List<Escenas>>(jsonDes);
            float temporizador = tiempo(escenas1);
            DateTime timer = DateTime.Now;
            float second = timer.Second;
            TiempoTotal = second + temporizador;
            for (int i = 0; i < escenas1.Count; i++)
            {
                Thread miHilo = new Thread(playEscena);
                miHilo.Start(i);
            };

        }

        void playEscena(object ob)
        {
            Escenas es = escenas1[(int)ob];
            DateTime timer = DateTime.Now;
            DateTime timer2 = DateTime.Now;
            float tiempoFinal = timer2.Second + es.tiempoEspera + es.tiempo;
            IObjeto objeto;
            if (es.parte == "")
            {
                objeto = pant.es.listaDeObjetos[es.objeto];
            }
            else
            {
                objeto = pant.es.listaDeObjetos[es.objeto].listadepartes[es.parte];
            }
            while (timer.Second < TiempoTotal)
            {
                if ((timer.Second >= (timer2.Second + es.tiempoEspera)) && (timer.Second < (timer2.Second + es.tiempoEspera + es.tiempo)))
                {

                    if (es.X > 0)
                    {

                        pant.cont.controlar(objeto, es.accion, "D", 1, es.velocidad);
                    }
                    if (es.X < 0)
                    {

                        pant.cont.controlar(objeto, es.accion, "A", 1, es.velocidad);
                    }
                    if (es.Y > 0)
                    {

                        pant.cont.controlar(objeto, es.accion, "W", 1, es.velocidad);
                    }
                    if (es.Y < 0)
                    {

                        pant.cont.controlar(objeto, es.accion, "S", 1, es.velocidad);
                    }
                }
                if(timer.Second > (timer2.Second + es.tiempoEspera + es.tiempo))
                {
                    return;
                }
                timer = DateTime.Now;
            }

        }



        float tiempo(List<Escenas> Temporizador)
        {
            float tiempoMay = Temporizador[0].tiempo + Temporizador[0].tiempoEspera;
            for (int i = 1; i < Temporizador.Count; i++)
            {
                if ((Temporizador[i].tiempo + Temporizador[i].tiempoEspera) > tiempoMay)
                {
                    tiempoMay = Temporizador[i].tiempo + Temporizador[i].tiempoEspera;
                }
            }
            return tiempoMay;
        }
    }
}
