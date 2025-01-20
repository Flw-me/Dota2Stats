using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dota2Stats
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MatchModelView viewModel = new MatchModelView();

            // Заполнение списка героев
            viewModel.InitiateHero();

            // Устанавливаем DataContext
            DataContext = viewModel;
        }

        /// <summary>
        /// подтверждаем и запрашиваем статистику
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GetStatistic_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MatchModelView viewModel)
            {
                //проверяем что оба героя выбраны
                if (viewModel.SelectedHero_1 == null || viewModel.SelectedHero_2 == null)
                {
                    MessageBox.Show("Пожалуйста, выберите двух героев.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                try
                {
                    // Создаем экземпляр DotaStatsService
                    DotaStatsService dotaStatsService = new DotaStatsService();
                    //Вызываем метод для получения статистики
                    var matchStatistics = await dotaStatsService.GetMatchesAsync(viewModel.SelectedHero_1.HeroId, viewModel.SelectedHero_2.HeroId);
                    // Обновляем ViewModel с полученными данными
                    viewModel.Matches = matchStatistics;

                    MessageBox.Show("Статистика успешно загружена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex) 
                {
                    // Обрабатываем возможные ошибки
                    MessageBox.Show($"Произошла ошибка при получении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
