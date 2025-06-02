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
    public class Chaussures
    {
        private static string jsonPath = @"C:\Users\LEVENT.OZGN\Documents\GitHub\ApplicationMagasin\MagasinOzgun\MagasinOzgun\chaussures.json";
        private static List<Chaussures> chaussuresList = JsonConvert.DeserializeObject<List<Chaussures>>(File.ReadAllText(jsonPath));

        public static List<Chaussures> ChaussuresList
        {
            get { return chaussuresList; }
        }

        public int Id { get; set; }
        public string chaussures { get; set; }
        public string image { get; set; }
        public double prix { get; set; }
    }
}
