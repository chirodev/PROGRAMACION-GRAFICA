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

namespace Juego
{
    class Pantalla : GameWindow
    {
        Escenario es;
        ClassCasa casa;
        ClassCasa casa1;
             
        public Pantalla(GameWindowSettings config, NativeWindowSettings nativo) : base(config, nativo) { }

        protected override void OnLoad()
        {
            string path = @"coordenadasCasa.json";
            string path1 = @"coordenadasCasa1.json";
            GL.Enable(EnableCap.DepthTest);
            es = new Escenario();          
            casa = new ClassCasa(path);
            casa1 = new ClassCasa(path1);
            es.addDibujo("casa1",casa);
            es.addDibujo("casa2",casa1);
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
            KeyboardState input = KeyboardState;
            
            if (input.IsKeyDown(Keys.A))
            {
                //ROTAR TODO EL ESCENARIO
                es.rotar(+0.1f, 0, 1, 0);
            }
            if (input.IsKeyDown(Keys.D))
            {             
                //ROTAR LA CASA 
                es.listaDeObjetos["casa1"].rotar(-0.1f, 0, 1, 0);
            }
            if (input.IsKeyDown(Keys.R))
            {
                //ROTAR LA PIEZA DE LA CASA 
                es.listaDeObjetos["casa1"].listadepartes["paredderecha"].rotar(+0.1f, 0, 1, 0);
            }
            if (input.IsKeyDown(Keys.J))
            {
                //TRASLACION DE LA CASA EN -X
                es.listaDeObjetos["casa1"].Traslacion(-0.1f,0,0);
            }
            if (input.IsKeyDown(Keys.L))
            {              
                //TRASLACION DE LA CASA EN X
                es.listaDeObjetos["casa1"].Traslacion(0.1f, 0, 0);
            }
            if (input.IsKeyDown(Keys.K))
            {
                //TRASLACION DE LA CASA EN -Y
                es.listaDeObjetos["casa1"].Traslacion(0, -0.1f, 0);
            }
            if (input.IsKeyDown(Keys.I))
            {
                //TRASLACION DE LA CASA EN Y
                es.listaDeObjetos["casa1"].Traslacion(0,0.1f, 0);
            }
            if (input.IsKeyDown(Keys.KeyPad1))
            {
                //TRASLACION DE LA CASA EN -X
                es.listaDeObjetos["casa1"].listadepartes["paredderecha"].Traslacion( -0.1f,0, 0);
            }
            if (input.IsKeyDown(Keys.KeyPad2))
            {
                //TRASLACION DE LA CASA EN X
                es.listaDeObjetos["casa1"].listadepartes["paredderecha"].Traslacion( +0.1f, 0,0);
            }
            base.OnUpdateFrame(e);
        }
        
    }
}
