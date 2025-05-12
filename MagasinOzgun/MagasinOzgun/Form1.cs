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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string nom;
        string photo;
        double prix;

        private void Form1_Load(object sender, EventArgs e)
        {
            string jsonPath = @"C:\Users\LEVENT.OZGN\Documents\GitHub\ApplicationMagasin\MagasinOzgun\MagasinOzgun\chaussures.json";
            string json = File.ReadAllText(jsonPath);
            List<Chaussures> chaussuresList = JsonConvert.DeserializeObject<List<Chaussures>>(json);

            foreach (var chaussure in chaussuresList)
            {
                AffichageUneChaussure(chaussure.chaussures, chaussure.image, chaussure.prix);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Panier panier = new Panier();
            panier.Show();
        }


        // Affichage des chaussures dans le flowLoyautPanel
        private void AffichageUneChaussure(string nomChaussures, string photoChaussures, double prixChaussures)
        {
            nom = nomChaussures;
            photo = photoChaussures;
            prix = prixChaussures;
            // Les noms des chaussures
            Panel panel = new Panel
            {
                Size = new Size(230, 200),
                BackColor = Color.DarkOrange,
                //Anchor = AnchorStyles.None
            };

            // Les images des chaussures
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(150, 90),
                Location = new Point(40, 15),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            string imagePath = Path.Combine(Application.StartupPath, photoChaussures.Replace("./", "").Replace("/", "\\"));
            pictureBox.Image = Image.FromFile(imagePath);
            //MessageBox.Show(imagePath);

            // Les noms des chaussures
            Label labelNomChaussures = new Label
            {
                Text = nomChaussures,
                Location = new Point(50, 100),
                Size = new Size(150, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Les prix des chaussures
            Label labelPrixChaussures = new Label
            {
                Text = prixChaussures.ToString() + ".-",
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


            panel.Controls.Add(pictureBox);
            panel.Controls.Add(labelNomChaussures);
            panel.Controls.Add(labelPrixChaussures);
            panel.Controls.Add(buttonAddToBag);

            flpChaussures.Controls.Add(panel);
            flpChaussures.FlowDirection = FlowDirection.LeftToRight;
            flpChaussures.WrapContents = true;

            pictureBox.MouseClick += new MouseEventHandler(pictureBox1_Click);
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2(nom, photo, prix);
            form2.Show();
        }
    }
}
