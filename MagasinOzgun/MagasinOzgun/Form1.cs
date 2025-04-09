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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MagasinOzgun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AffichageUneChaussure("Nike Air Max", "nike");
            AffichageUneChaussure("Nike Air Max", "panier");

        }

        // Button pour aller au panier
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Panier panier = new Panier();
            panier.ShowDialog();
        }

        private void AffichageUneChaussure(string nomChassures, string photoChaussures)
        {
            Panel panel = new Panel();
            {
                panel.Size = new Size(230, 150);
                panel.BackColor = Color.DarkOrange;
            }

            PictureBox pictureBox = new PictureBox();
            {
                var image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(photoChaussures);
                pictureBox.Image = image;
                pictureBox.Size = new Size(150, 90);
                pictureBox.Location = new Point(15, 15);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                panel.Controls.Add(pictureBox);
            }

            Label label = new Label();
            {
                label.Text = nomChassures;
                label.Location = new Point(40, 110);
                label.Size = new Size(150, 20);
                label.TextAlign = ContentAlignment.MiddleCenter;
                panel.Controls.Add(label);
            }

            flpChaussures.Controls.Add(panel);
            flpChaussures.FlowDirection = FlowDirection.LeftToRight;
            flpChaussures.WrapContents = true;
        }
    }
}
