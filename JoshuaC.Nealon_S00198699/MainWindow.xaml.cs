using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JoshuaC.Nealon_S00198699
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Game> AllGames;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GameData db = new GameData();
            var query = from g in db.Games
                        select g;
            AllGames = query.ToList();
            GamesLBX.ItemsSource = AllGames;
        }
        private void GamesLBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Game selectedGame = GamesLBX.SelectedItem as Game;
            if (selectedGame != null)
            {
                GameIMG.Source = new BitmapImage(new Uri(selectedGame.GameImage, UriKind.Relative));
                GameDescTBX.Text = $"{selectedGame.Description:C}";
            }
        }

        private void FilterDrop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Game selectedPlatform = FilterDrop.SelectedItem as Game;
            GameData db = new GameData();
            var query = from g in db.Games
                        where g.Platform != null && g.Platform == selectedPlatform.Platform
                        select g;
                GamesLBX.ItemsSource = query.ToList();
        }

        private void FilterDrop_DropDownOpened(object sender, EventArgs e)
        {
            
            GameData db = new GameData();
            var query = from g in db.Games
                        select g;
            FilterDrop.ItemsSource = query.ToList();
        }
    }
}
