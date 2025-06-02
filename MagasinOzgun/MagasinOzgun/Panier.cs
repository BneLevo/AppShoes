using Newtonsoft.Json;
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
    public partial class Panier : Form
    {
        double prixTotal;

        public Panier()
        {
            InitializeComponent();

            foreach (var chaussure in Chaussures.ChaussuresList)
            {
                Bag(chaussure);
            }
        }

        private void Bag(Chaussures chaussure)
        {
            foreach (var bag in BagManager.Bag)
            {
                if (chaussure.Id == bag)
                {
                    Panel panel = new Panel()
                    {
                        Size = new Size(500, 100)
                    };

                    PictureBox pictureBox = new PictureBox
                    {
                        Size = new Size(150, 90),
                        Location = new Point(40, 15),
                        SizeMode = PictureBoxSizeMode.Zoom
                    };
                    string imagePath = Path.Combine(Application.StartupPath, chaussure.image.Replace("./", "").Replace("/", "\\"));
                    pictureBox.Image = Image.FromFile(imagePath);

                    Label labelNomChaussures = new Label
                    {
                        Text = chaussure.chaussures,
                        Location = new Point(210, 50),
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    Label labelPrixChaussures = new Label
                    {
                        Text = chaussure.prix.ToString() + ".-",
                        Location = new Point(320, 50),
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    PictureBox trash = new PictureBox
                    {
                        Image = Image.FromFile("./img/trash.png"),
                        Location = new Point(400, 50),
                        Size = new Size(100, 30),
                        BackColor = Color.Transparent,
                        SizeMode = PictureBoxSizeMode.Zoom
                    };

                    trash.MouseClick += (s, e) =>
                    {
                        BagManager.ClearAShoe(chaussure.Id);

                        if (BagManager.Bag.Contains(chaussure.Id))
                        {
                            MessageBox.Show("Error");
                        }
                        else
                        {
                            MessageBox.Show("Ce produit a été supprime du votre sac");
                        }

                    };

                    panel.Controls.Add(pictureBox);
                    panel.Controls.Add(labelNomChaussures);
                    panel.Controls.Add(labelPrixChaussures);
                    panel.Controls.Add(trash);

                    flpBag.Controls.Add(panel);
                    flpBag.FlowDirection = FlowDirection.LeftToRight;
                    flpBag.WrapContents = true;

                    label5.Text = "Total : ";
                    prixTotal += chaussure.prix;
                    label5.Text += prixTotal.ToString();
                    label5.Text += ".-";
                }
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Panier panier = new Panier();
            panier.Show();
        }
    }
}
