using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Juego;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using FormularioGrafica.Controladores;

namespace FormularioGrafica
{
    public partial class Form1 : Form
    {
        Pantalla pantalla;
        Escenario es;
        IObjeto seleccionado;
        Animacion animacion;
        bool rotar = false;
        bool mover = false;
        string enlace;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameWindowSettings config = new GameWindowSettings();
            config.RenderFrequency = 30.0;
            config.UpdateFrequency = 60.0;
            NativeWindowSettings nativo = new NativeWindowSettings();
            nativo.Size = new Vector2i(800, 600);
            nativo.Title = "Programacion Grafica";
            nativo.Location = new Vector2i(325, 131);
            pantalla = new Pantalla(config, nativo);
            es = pantalla.es;
            seleccionado = es;
            animacion = new Animacion(pantalla);
            foreach (KeyValuePair<string, IObjeto> aux in es.listaDeObjetos)
            {
                comboBox1.Items.Add(aux.Key);
            }
            comboBox1.Items.Add("Escenario");
            comboBox1.Text = "Escenario";
        }

        private void Form1_Shown(object sender, EventArgs e)
        {          
            pantalla.Run();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rotar = true;
            mover = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (comboBox1.Text != "Escenario")
            {
                seleccionado = es.listaDeObjetos[comboBox1.Text];
                foreach (KeyValuePair<string, IObjeto> aux in seleccionado.listadepartes)
                {
                    comboBox2.Items.Add(aux.Key);
                }              
            }
            else
            {
                seleccionado = es;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionado = es.listaDeObjetos[comboBox1.Text].listadepartes[comboBox2.Text];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mover = true;
            rotar = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(mover)
            {
                pantalla.cont.controlar(seleccionado,"T","A",1,0.3f);
            }
            else if(rotar)
            {
                pantalla.cont.controlar(seleccionado, "R", "A",1, 0.3f);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (mover)
            {
                pantalla.cont.controlar(seleccionado, "T", "W",1, 0.3f);
            }
            else if (rotar)
            {
                pantalla.cont.controlar(seleccionado, "R", "W",1, 0.3f);
            }
           
        }

        private void S_Click(object sender, EventArgs e)
        {
            if (mover)
            {
                pantalla.cont.controlar(seleccionado, "T", "S",1, 0.3f);
            }
            else if (rotar)
            {
                pantalla.cont.controlar(seleccionado, "R", "S",1, 0.3f);
            }

        }

        private void D_Click(object sender, EventArgs e)
        {
            if (mover)
            {
                pantalla.cont.controlar(seleccionado, "T", "D",0, 0.3f);
            }
            else if (rotar)
            {
                pantalla.cont.controlar(seleccionado, "R", "D",0, 0.3f);
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            pantalla.cont.controlar(seleccionado, "S", "", Int32.Parse(textBox1.Text), 0.3f);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                enlace = openFileDialog1.FileName;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            animacion.play(enlace);
        }
    }
}
