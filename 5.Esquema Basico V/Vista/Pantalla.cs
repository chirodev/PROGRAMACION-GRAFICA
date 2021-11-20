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
        Objeto casa;
        Objeto casa1;
        public controlarAccion cont;
        string path = @"coordenadasCasa.json";
        string path1 = @"coordenadasCasa1.json";

        public Pantalla(GameWindowSettings config, NativeWindowSettings nativo) : base(config, nativo) {
            cont = new controlarAccion();
            es = new Escenario();
            casa = new Objeto(path);
            casa1 = new Objeto(path1);
            es.addDibujo("casa1", casa);
            es.addDibujo("casa2", casa1);
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
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {           
            base.OnUpdateFrame(e);
        }     
        
    }
}
