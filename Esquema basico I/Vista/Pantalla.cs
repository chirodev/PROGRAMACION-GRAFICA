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


namespace Juego
{
    class Pantalla : GameWindow
    {
        Escenario es;
        silla sil ;
        silla sil2;
        ClassKeyboard k;
        float i=0;
        float teta;
        public Pantalla(GameWindowSettings config, NativeWindowSettings nativo) : base(config, nativo) { }


        protected override void OnLoad()
        {
            GL.Enable(EnableCap.DepthTest);
            es = new Escenario();
            k = new ClassKeyboard();
            sil = new silla(new Vector3(0, 0, 0f),1, new Vector2(0.0f, 0.1f), new Vector2(0.6f, 0.8f), 2f, 2f, 2f);
           // sil2 = new silla(new Vector3(-3,0,0), new Vector3(0, 0, -10f), 1, new Vector3(0, 0, 0), new Vector2(0.0f, 0.1f), new Vector2(0.6f, 0.8f), 1f, 1f, 0.6f);
            es.addDibujo("Silla", sil);
           // es.addDibujo("Silla2", sil2);
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
            teta += 0.10f;
            es.Dibujar();
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState input = KeyboardState;
           
            if (input.IsKeyDown(Keys.A))
            {
                i=i+0.1f;
                //sil.listaDePiezas["].rotar(i, 1, 0, 0);
                sil.rotar(i, 0, 1, 0);
            }
            if (input.IsKeyDown(Keys.D))
            {
                i = i - 0.1f;
                sil.listaDePiezas["pata2"].rotar(i, 0, 1, 0);
                sil.rotar(i, 0, 1, 0);
            }
            base.OnUpdateFrame(e);
        }
        
    }
}
