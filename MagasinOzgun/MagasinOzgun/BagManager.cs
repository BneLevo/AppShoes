using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagasinOzgun
{
    public class BagManager
    {
        private static List<int> bag = new List<int>();

        public static List<int> Bag
        {
            get { return bag; }
        }

        public static void AddToBag(int itemId)
        {
            bag.Add(itemId);
        }

        public static void ClearBag()
        {
            bag.Clear();
        }
    }
}
