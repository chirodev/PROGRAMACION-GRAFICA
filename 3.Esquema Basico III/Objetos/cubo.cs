using GraficaCubo;
using Newtonsoft.Json;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Juego
{
    class cubo : Objeto
    {
        int VertexBufferObject;
        int VertexArrayObject;
        Vector3 posi;
        Shader shader;
        Vector3 tras;
        Vector3 Angulo;
        Matrix4 view;
        Matrix4 rotacion;
        Matrix4 projection;
        Matrix4 scale;
        Matrix4 model;
        float[] vertices;
        float ancho;
        float altura;
        float largo;
        float AnguloX;
        float AnguloY;
        float AnguloZ;
        Vector2 colorX;
        Vector2 colorY;
        bool rot = false;
        public cubo(CoordenadasCasa coordenadas)
        {

            posi = new Vector3(coordenadas.X, coordenadas.Y, coordenadas.Z);
            int dimension = coordenadas.dimension;
            ancho = coordenadas.ancho;
            altura = coordenadas.altura;
            largo = coordenadas.largo;
            colorX = new Vector2(coordenadas.colorX, coordenadas.colorY);
            colorY = new Vector2(coordenadas.colorY, coordenadas.colorX);
            vertices = Base(new Vector3(0,0,0), ancho, altura, largo, colorX, colorY);
            AnguloX = coordenadas.AnguloX;
            AnguloY = coordenadas.AnguloY;
            AnguloZ = coordenadas.AnguloZ;
            Angulo = new Vector3(AnguloX, AnguloY, AnguloZ);
            tras = posi;
        }
        void contruir(Vector3 posiciones)
        {
            vertices = Base(posiciones, ancho, altura, largo, colorX, colorY);
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
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, true, 5 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);
            shader.Use();

        }
        public void matrices()
        {
            view = Matrix4.CreateTranslation(0, 0, 0);
            model = Matrix4.CreateRotationX(Angulo.X) * Matrix4.CreateRotationY(Angulo.Y) * Matrix4.CreateRotationZ(Angulo.Z);
            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), 800 / 600, 0.1f, 100.0f);
            scale = Matrix4.CreateScale(1);
            model = scale * model * view * projection;
            shader.SetMatrix4("model", model);
        }
        public override void Dibujar()
        {
            Load();
            
            view = Matrix4.CreateTranslation(tras.X, tras.Y, tras.Z);
            rotacion = Matrix4.CreateRotationX(Angulo.X) * Matrix4.CreateRotationY(Angulo.Y) * Matrix4.CreateRotationZ(Angulo.Z);    
            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), 800 / 600, 0.1f, 100.0f);
            scale = Matrix4.CreateScale(1);          
            model = rotacion*scale*view * projection;       
            shader.SetMatrix4("model", model);
            GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length);
            GL.BindVertexArray(VertexArrayObject);
            GL.Rotate(AnguloY,posi);
            
        }

        public override void rotar(float angle, float x, float y, float z)
        {
            if (x > 0)
            {
                Angulo.X = angle;

            }
            if (y > 0)
            {
                Angulo.Y = Angulo.Y + angle;
                rot = true;
            }
            if (z > 0)
            {
                Angulo.Z = angle;

            }
        }
        public override void Traslacion(float trasX, float trasY, float trasZ)
        {            
            tras.X =posi.X + trasX;
            posi.X = tras.X;
            tras.Y = posi.Y + trasY;
            posi.Y = tras.Y;
            tras.Z = posi.Z + trasZ;
            posi.Z = tras.Z;
        }

    }
}

