using Juego;
using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Mathematics;
namespace FormularioGrafica.Controladores
{
    class controlarAccion
    {
        public void controlar(IObjeto objeto, string accion, string tecla,int sca,float velocidad)
        {
            if (accion == "S")
            {
                objeto.Escala(sca);
            }
            else
            {

                if (tecla == "A")
                {
                    if (accion == "T")
                    {
                        objeto.Traslacion(-velocidad, 0, 0);
                    }
                    if (accion == "R")
                    {
                        objeto.rotar(-velocidad, 1, 0, 0, new Vector3(0, 0, 0));
                    }
                }
                if (tecla == "D")
                {
                    if (accion == "T")
                    {
                        objeto.Traslacion(velocidad, 0, 0);
                    }
                    if (accion == "R")
                    {
                        objeto.rotar(velocidad, 1, 0, 0, new Vector3(0, 0, 0));
                    }
                }
                if (tecla == "W")
                {
                    if (accion == "T")
                    {
                        objeto.Traslacion(0, velocidad, 0);
                    }
                    if (accion == "R")
                    {
                        objeto.rotar(velocidad, 0, 1, 0, new Vector3(0, 0, 0));
                    }
                }
                if (tecla == "S")
                {
                    if (accion == "T")
                    {
                        objeto.Traslacion(0, -velocidad, 0);
                    }
                    if (accion == "R")
                    {
                        objeto.rotar(-velocidad, 0, 1, 0, new Vector3(0, 0, 0));
                    }
                }
                if(tecla=="Z")
                {
                    if (accion == "R")
                    {
                        objeto.rotar(velocidad, 0, 0, 1, new Vector3(0, 0, 0));
                    }
                }
            }

        }
    }
}
