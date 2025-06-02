using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            foreach (var chaussure in Chaussures.ChaussuresList)
            {
                AffichageUneChaussure(chaussure);
            }
        }

        // Affichage des chaussures dans le flowLoyautPanel
        private void AffichageUneChaussure(Chaussures chaussure)
        {
            Panel panel = new Panel
            {
                Size = new Size(230, 200),
                BackColor = Color.DarkOrange,
            };

            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(150, 90),
                Location = new Point(40, 15),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            pictureBox.MouseClick += (s, e) =>
            {
                this.Hide();
                Form2 form2 = new Form2(chaussure.Id);
                form2.Show();
            };

            string imagePathChaussures = Path.Combine(Application.StartupPath, chaussure.image.Replace("./", "").Replace("/", "\\"));
            pictureBox.Image = Image.FromFile(imagePathChaussures);

            Label labelNomChaussures = new Label
            {
                Text = chaussure.chaussures,
                Location = new Point(50, 100),
                Size = new Size(150, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label labelPrixChaussures = new Label
            {
                Text = chaussure.prix.ToString() + ".-",
                Location = new Point(50, 125),
                Size = new Size(150, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button buttonAddToBag = new Button
            {
                Text = "Add To Bag",
                Location = new Point(50, 160),
                Size = new Size(150, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White,
                ForeColor = Color.Orange
            };

            buttonAddToBag.MouseClick += (s, e) =>
            {
                BagManager.AddToBag(chaussure.Id);

                if (BagManager.Bag.Contains(chaussure.Id))
                {
                    MessageBox.Show("Ajouté au panier");
                }
                else
                {
                    MessageBox.Show("Error");
                }

            };

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(labelNomChaussures);
            panel.Controls.Add(labelPrixChaussures);
            panel.Controls.Add(buttonAddToBag);

            flpChaussures.Controls.Add(panel);
            flpChaussures.FlowDirection = FlowDirection.LeftToRight;
            flpChaussures.WrapContents = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Panier panier = new Panier();
            panier.Show();
        }
    }
}
