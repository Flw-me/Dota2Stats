using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Dota2Stats
{
    public class Item
    {
        public Item(string itemName)
        {
            name = itemName;
        }
        /// <summary>
        /// Название предмета
        /// </summary>
        string name;

        public string Name
        {
            get
            { return name; }
            set
            { name = value; }
        }

        /// <summary>
        /// Путь к миниатюре
        /// </summary>
        string pathToImage;
        public string PathToImage
        {
            get
            { return pathToImage; }
            set
            { pathToImage = value; }
        }
    }

}

