/*Colegio Técnico Antônio Teixeira Fernandes (Univap)
 * Curso Técnico em Informática - Data de Entrega: 06 / 08 / 2026
 * Autores do Projeto: Fábio Silva de Lima
 *                     Luís Otávio Miranda
 *
 * Turma: 3I
 * Atividade Proposta em aula
 * Observação: <Uso de Pen.Dispose() para Limpeza de Memóriae Técnicas de Redução de Gasto de Memória>
 * 
 * 
 * ******************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto1_aula
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Random rnd = new Random();
        private bool coresDefinidas = false;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (coresDefinidas)
                Desenhar(e);
        }

        private void Desenhar (PaintEventArgs e)
        {
            int r = 0, g = 0, b = 0;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    r = 255;
                    break;

                case 1:
                    g = 255;
                    break;

                case 2:
                    b = 255;
                    break;

                case 3:
                    g = 255;
                    b = 255;
                    break;

                case 4:
                    r = 255;
                    b = 255;
                    break;

                case 5:
                    r = 255;
                    g = 255;
                    break;

                case 6:
                    break;

                case 7:
                    r = 255;
                    g = 255;
                    b = 255;
                    break; 
            }

            decagono(e, r, g, b);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!coresDefinidas)
                DefinirCores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!coresDefinidas)
                coresDefinidas = true;

            Invalidate();
            MessageBox.Show("Decágono Gerado com Sucesso!");
        }

        public float Modulo(float a, float b)
        {
            return (a % b + b) % b;
        }

        private Pen CriarCaneta (int R, int G, int B)
        {
            return new Pen(Color.FromArgb(R, G, B));
        }

        private void DesenharPonto (PaintEventArgs e, Pen caneta, int x, int y)
        {
            e.Graphics.DrawLine(caneta, x, y, x + 1, y);
        }

        public void decagono(PaintEventArgs e, int r, int g, int b)
        {
            int n = 10; 
            int R = 150; 
            int tentativas = 80000;
            int largura = 800;
            int altura = 800;
            int centroX = largura / 2;
            int centroY = altura / 2;
            int dx = 0, dy = 0;
            int px = 0, py = 0;

            float α = 0;
            float seccao = (float)Math.PI * 2 / n;
            float angulo = 0;

            double d = 0;
            double dmax = 0;
            
            Pen caneta = CriarCaneta (r, g, b);

            for (int i = 0; i < tentativas; i++)
            {
                px = rnd.Next(centroX - R, centroX + R);
                py = rnd.Next(centroY - R, centroY + R);

                dx = px - centroX;
                dy = py - centroY;

                d = dx * dx + dy * dy;

                if (d > R * R) 
                    continue;

                angulo = (float)Math.Atan2(dy, dx);
                α = (float)(Modulo(angulo, seccao) - (seccao / 2.0));

                dmax = R * Math.Cos(Math.PI/n) / Math.Cos(α);

                if (d < dmax * dmax)
                    DesenharPonto(e, caneta, px, py);
            }

            caneta.Dispose();
        }

        private void DefinirCores ()
        {
            string[] colors = {"Vermelho", "Verde", "Azul", "Ciano", "Magenta", "Amarelo", "Escuro", "Branco"};
            foreach (string color in colors)
            {
                comboBox1.Items.Add(color);
            }
            comboBox1.SelectedIndex = 0;
        }
    }
}
