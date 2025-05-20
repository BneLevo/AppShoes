using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagasinOzgun
{
    public partial class Panier : Form
    {
        public Panier()
        {
            InitializeComponent();
            label6.Text = string.Join(", ", BagManager.Bag);
        }
    }
}
