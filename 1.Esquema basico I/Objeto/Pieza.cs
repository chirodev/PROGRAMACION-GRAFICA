using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Juego
{
    class Pieza : Objeto
    {
        int VertexBufferObject;
        int VertexArrayObject;
        float sca;
        float Ancho;
        float Alto;
        float Largo;
        bool rotado;
        Vector3 posi;
        Shader shader;
        Vector2 vecX;
        Vector2 vecY;
        Matrix4 view;
        Matrix4 projection;
        Matrix4 scale;
        Matrix4 X;
        Matrix4 Y;
        Matrix4 Z;
        Matrix4 model;
        Vector3 Origen;
        float[] vertices;
        public Pieza(Vector3 posicion, Vector3 Traslacion, float escala, float an, float lar, float alt, Vector2 X, Vector2 Y, Vector3 origen)
        {
            Ancho = an;
            Largo = lar;
            Alto = alt;
            vertices = Base(posicion, an, lar, alt, X, Y);
            posi = posicion;
            traslacionPieza = Traslacion;
            Angulo = new Vector3(0, 0, 0);
            eje = posicion;
            sca = escala;
            rotado = false;
            Origen = origen;
            Load();
            matrices();
        }
        float[] Base(Vector3 p, float an, float lar, float alt, Vector2 X, Vector2 Y)
        {
            float[] vert = new float[]
            {
                p.X,     p.Y,     p.Z-an, X.X, Y.Y,
                p.X,     p.Y,     p.Z,    X.X, Y.X,
                p.X+lar, p.Y,     p.Z,    X.Y, Y.X,

                p.X+lar, p.Y,     p.Z,    X.Y, Y.X,
                p.X,     p.Y,     p.Z-an, X.X, Y.Y,
                p.X+lar, p.Y,     p.Z-an, X.Y, Y.Y,
            
                p.X,     p.Y-alt, p.Z-an, X.X, Y.Y,
                p.X,     p.Y-alt, p.Z,    X.X, Y.X,
                p.X+lar, p.Y-alt, p.Z,    X.Y, Y.X,

                p.X+lar, p.Y-alt, p.Z,    X.Y, Y.X,
                p.X,     p.Y-alt, p.Z-an, X.X, Y.Y,
                p.X+lar, p.Y-alt, p.Z-an, X.Y, Y.Y,
               
                p.X,     p.Y,     p.Z,    X.X, Y.Y,
                p.X,     p.Y-alt, p.Z,    X.X, Y.X,
                p.X+lar, p.Y,     p.Z,    X.Y, Y.Y,

                p.X,     p.Y-alt, p.Z,    X.X, Y.X,
                p.X+lar, p.Y,     p.Z,    X.Y, Y.Y,
                p.X+lar, p.Y-alt, p.Z,    X.Y, Y.X,
               
                p.X,     p.Y,     p.Z-an, X.X, Y.Y,
                p.X,     p.Y-alt, p.Z-an, X.X, Y.X,
                p.X+lar, p.Y,     p.Z-an, X.Y, Y.Y,

                p.X,     p.Y-alt, p.Z-an, X.X, Y.X,
                p.X+lar, p.Y,     p.Z-an, X.Y, Y.Y,
                p.X+lar, p.Y-alt, p.Z-an, X.Y, Y.X,
                
                p.X,     p.Y,     p.Z,    X.X, Y.Y,
                p.X,     p.Y-alt, p.Z,    X.X, Y.X,
                p.X,     p.Y,     p.Z-an, X.Y, Y.Y,

                p.X,     p.Y,     p.Z-an, X.Y, Y.Y,
                p.X,     p.Y-alt, p.Z,    X.X, Y.X,
                p.X,     p.Y-alt, p.Z-an, X.Y, Y.X,
               
                p.X+lar, p.Y,     p.Z,    X.X, Y.Y,
                p.X+lar, p.Y-alt, p.Z,    X.X, Y.X,
                p.X+lar, p.Y,     p.Z-an, X.Y, Y.Y,

                p.X+lar, p.Y,     p.Z-an, X.Y, Y.Y,
                p.X+lar, p.Y-alt, p.Z,    X.X, Y.X,
                p.X+lar, p.Y-alt, p.Z-an, X.Y, Y.X,
            };
            return vert;
        }
        private void Load()
        {
            shader = new Shader(); 
            VertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject);
            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, true, 5 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, true, 5 * sizeof(float), 6 * sizeof(float));
            GL.EnableVertexAttribArray(1);
            shader.Use();         

        }
        public void matrices()
        {
            view = Matrix4.CreateTranslation(traslacionPieza.X, traslacionPieza.Y, -10f);
            model = Matrix4.CreateRotationX(Angulo.X) * Matrix4.CreateRotationY(Angulo.Y) * Matrix4.CreateRotationZ(Angulo.Z);
            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), 800 / 600, 0.1f, 100.0f);
            scale = Matrix4.CreateScale(sca);
            shader.SetMatrix4("model", model);
            shader.SetMatrix4("view", view);
            shader.SetMatrix4("projection", projection);
            shader.SetMatrix4("scale", scale);

        }
        public override void Dibujar()
        {
               Load();
               view = Matrix4.CreateTranslation(traslacionPieza.X, traslacionPieza.Y, -10f);
              // model = Matrix4.CreateRotationX(Angulo.X);// * Matrix4.CreateRotationY(Angulo.Y) * Matrix4.CreateRotationZ(Angulo.Z);
               projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), 800 / 600, 0.1f, 100.0f);
               scale = Matrix4.CreateScale(sca);
               shader.SetMatrix4("model", model);
               shader.SetMatrix4("view", view);
               shader.SetMatrix4("projection", projection);
               shader.SetMatrix4("scale", scale);
               GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length);
               GL.BindVertexArray(VertexArrayObject);
        }
       
    }
}
