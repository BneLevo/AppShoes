using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MagasinOzgun
{
    public class Chaussures
    {
        public int Id { get; set; }
        public string chaussures { get; set; }
        public string image { get; set; }
        public double prix { get; set; }

        public Chaussures(int ID, string Chassures, string image, double prix) 
        { 
            this.Id = ID;
            this.chaussures = Chassures;
            this.image = image;
            this.prix = prix;
        }
    }
}
