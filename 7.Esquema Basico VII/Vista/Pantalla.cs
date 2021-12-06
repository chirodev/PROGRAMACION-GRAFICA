using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL4;
using System.Linq;
using OpenTK.Mathematics;
using System.Drawing;
using System.Drawing.Imaging;
using GraficaCubo;
using Newtonsoft.Json;
using GraficaCubo.Controladores;
using FormularioGrafica.Controladores;

namespace Juego
{
    class Pantalla : GameWindow
    {
        public Escenario es;
        Objeto hormiga;
        Objeto libro;
        public controlarAccion cont;
        string path1 = @"CoordenadasHormiga.json";
        string path2 = @"CoordenadasPartesHor.json";
        string path3 = @"CoordenadasLibro.json";
        string path4 = @"CordenadasPartesLib.json";
        float x = 0;
        public Pantalla(GameWindowSettings config, NativeWindowSettings nativo) : base(config, nativo) {
            cont = new controlarAccion();
            es = new Escenario();
            hormiga = new Objeto(path1, path2);
            libro = new Objeto(path3,path4);
            es.addDibujo("hormiga", hormiga);
            es.addDibujo("libro",libro);
        }

        protected override void OnLoad()
        {
            GL.Enable(EnableCap.DepthTest);          
            base.OnLoad();
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            es.Dibujar();

           /* if (x < 2)
            {
                x = x + 0.05f;
                hormiga.Traslacion(+0.05f, 0, 0);
            }
            else
            {
                x = x + 0.05f;
                hormiga.Traslacion(+0.05f, 0, 0);
                if (x < 5.2f)
                {
                    libro.listadepartes["arriba"].rotar(0.05f, 1, 0, 0, new Vector3(0, 0, 0));
                }
             }*/
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {           
            base.OnUpdateFrame(e);
        }     
        
    }
}
