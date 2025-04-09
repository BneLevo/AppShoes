using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            Panel panel = new Panel();
            panel.Location = new Point(10, 110);
            panel.Size = new Size(230, 132);

            //PictureBox pictureBox = new PictureBox();
            //pictureBox.Location = new Point(15, 15);
            pbImage.Image = Properties.Resources.nike;//Image.FromFile(@"Resources\W+NIKE+AIR+MAX+1.png");
            //pictureBox.Size = new Size(150, 90);
            //pictureBox
            //panel.Controls.Add(pictureBox);



            Label label = new Label();
            label.Text = "Nike Air Max";
            label.Location = new Point(10, 110);
            label.Size = new Size(150, 20);
            panel.Controls.Add(label);
            

            
            this.Controls.Add(panel);
                 
        }


        // Button pour aller au panier
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Panier panier = new Panier();
            panier.ShowDialog();    
        }
    }
}
