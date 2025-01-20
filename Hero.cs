using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
   public class Hero
    {
        //Конструкторс9
        public Hero(string heroName, int heroId) 
        {
            this.heroName = heroName;
            this.heroID = heroId;
        }

        //предметы героя
        public static List<Item> Items { get; set; } = new List<Item>();

        /// <summary>
        /// Имя героя
        /// </summary>
        string heroName;
        public string HeroName
        { 
            get { return heroName; }
            set { heroName = value; } 
        }
        
        /// <summary>
        /// ID героя
        /// </summary>
        int heroID;
      public  int HeroId 
        { 
            get 
            { return heroID; } 
            set 
            { heroID = value; } 
        }
    }
}
