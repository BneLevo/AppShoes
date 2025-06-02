using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagasinOzgun
{
    public partial class Form2 : Form
    {
        public Form2(int id)
        {
            InitializeComponent();

            foreach (var chaussure in Chaussures.ChaussuresList)
            {
                AffichageUneChaussure(chaussure, id);
            }
        }

        private void AffichageUneChaussure(Chaussures chaussures, int id)
        {
            if (chaussures.Id == id)
            {
                Panel panel = new Panel()
                {
                    Size = new Size(702, 336),
                    Location = new Point(89, 172)
                };

                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(400, 270),
                    Location = new Point(30, 50),
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                string imagePathChaussures = Path.Combine(Application.StartupPath, chaussures.image.Replace("./", "").Replace("/", "\\"));
                pictureBox.Image = Image.FromFile(imagePathChaussures);

                Label labelNomChaussures = new Label
                {
                    Text = chaussures.chaussures,
                    Location = new Point(463, 101),
                    AutoSize = true,
                    Size = new Size(150, 40),
                    Font = new Font("Microsoft Sans Serif", 15),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Label labelPrixChaussures = new Label
                {
                    Text = chaussures.prix.ToString() + ".-",
                    Location = new Point(463, 139),
                    Size = new Size(150, 20),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Button buttonAddToBag = new Button
                {
                    Text = "Add To Bag",
                    Location = new Point(463, 236),
                    Size = new Size(150, 30),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White,
                    ForeColor = Color.Orange
                };

                buttonAddToBag.MouseClick += (s, e) =>
                {
                    BagManager.AddToBag(chaussures.Id);

                    if (BagManager.Bag.Contains(chaussures.Id))
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
                this.Controls.Add(panel);
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Panier panier = new Panier();
            panier.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}