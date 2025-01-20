using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
   public class MatchModelView : INotifyPropertyChanged
    {
        //выбранный герой 2 
        private Hero selectedHero_1;
        public Hero SelectedHero_1
        {
            get => selectedHero_1;
            set
            {
                if (selectedHero_1 != value)
                {
                    selectedHero_1 = value;
                    OnPropertyChanged(nameof(SelectedHero_1));
                }
            }
        }
        //Выбранный герой 2
        private Hero selectedHero_2;
        public Hero SelectedHero_2
        {
            get => selectedHero_2;
            set
            {
                if (selectedHero_2 != value)
                {
                    selectedHero_2 = value;
                    OnPropertyChanged(nameof(SelectedHero_2));
                }
            }
        }
        //Список загруженных матчей
        private List<Match> matches;
        public List<Match> Matches
        {
            get => matches;
            set
            {
                matches = value;
                OnPropertyChanged(nameof(Matches));
            }
        }

        /// <summary>
        /// Хранит список героев для отображения 
        /// </summary>
        private List<Hero> heroesList = new List<Hero>();

        /// <summary>
        /// Хранит список героев для отображения
        /// </summary>
        public List<Hero> HeroesList
        {
            get => heroesList;
            set
            {
                if (heroesList != value)
                {
                    heroesList = value;
                    OnPropertyChanged(nameof(HeroesList));  // Оповещаем об изменении
                }
            }
        }

        //событие
        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// Вызываем событие (Свойство изменено)
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Заполняем список героев
        /// </summary>
        public void InitiateHero()
        {
            foreach (var hero in HeroName.KeyAndNames)
            {
                heroesList.Add(new Hero(hero.Value, hero.Key));
            }
        }


    }
}
