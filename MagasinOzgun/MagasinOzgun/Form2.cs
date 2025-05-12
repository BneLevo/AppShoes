using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagasinOzgun
{
    public partial class Form2 : Form
    {
        public Form2(string nom, string photo, double prix)
        {
            InitializeComponent();
            nomChaussures = nom;
            photoChaussures = photo;
            prixChaussures = prix;
        }
        public string nomChaussures;
        public string photoChaussures;
        public double prixChaussures;

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = nomChaussures;
            string imagePath = Path.Combine(Application.StartupPath, photoChaussures.Replace("./", "").Replace("/", "\\"));
            pictureBox1.Image = Image.FromFile(imagePath);

            // ça marche pas
            label4.Text = prixChaussures.ToString() + ".-";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Panier panier = new Panier();
            panier.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
