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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string jsonPath = @"C:\Users\LEVENT.OZGN\Documents\GitHub\ApplicationMagasin\MagasinOzgun\MagasinOzgun\chaussures.json";
            string json = File.ReadAllText(jsonPath);
            List<Chaussures> chaussuresList = JsonConvert.DeserializeObject<List<Chaussures>>(json);

            foreach (var chaussure in chaussuresList)
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

            string imagePath = Path.Combine(Application.StartupPath, chaussure.image.Replace("./", "").Replace("/", "\\"));
            pictureBox.Image = Image.FromFile(imagePath);

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
                MessageBox.Show("Ajouté au panier");
            };

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(labelNomChaussures);
            panel.Controls.Add(labelPrixChaussures);
            panel.Controls.Add(buttonAddToBag);

            flpChaussures.Controls.Add(panel);
            flpChaussures.FlowDirection = FlowDirection.LeftToRight;
            flpChaussures.WrapContents = true;

            pictureBox.MouseClick += (s, e) =>
            {
                this.Hide();
                Form2 form2 = new Form2(chaussure.Id, chaussure.chaussures, chaussure.image, chaussure.prix);
                form2.Show();
            };
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Panier panier = new Panier();
            panier.Show();
        }
    }
}
