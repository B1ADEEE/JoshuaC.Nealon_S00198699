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
    /// 


    /*
     * 
     * ---- GITHUB https://github.com/B1ADEEE/JoshuaC.Nealon_S00198699
     */
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
            var query = from g in db.Games                                                              //query to get the games into the tbx
                        select g;
            AllGames = query.ToList();
            GamesLBX.ItemsSource = AllGames;
        }
        private void GamesLBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Game selectedGame = GamesLBX.SelectedItem as Game;                                                          //selecting the games to get the image and the desc
            if (selectedGame != null)
            {
                GameIMG.Source = new BitmapImage(new Uri(selectedGame.GameImage, UriKind.Relative));
                GameDescTBX.Text = $"{selectedGame.Description:C}";
            }
        }

        private void FilterDrop_SelectionChanged(object sender, SelectionChangedEventArgs e)        //filters the games to platform
        {
            Game selectedPlatform = FilterDrop.SelectedItem as Game;                                //this crashes once but if your press continue it will work again.. seems to happen everytime you reselt a new filter for the fist time it wont work
            GameData db = new GameData();
            var query = from g in db.Games                                                          
                        where g.Platform != null && g.Platform == selectedPlatform.Platform
                        select g;
            GamesLBX.ItemsSource = query.ToList();
        }

        private void FilterDrop_DropDownOpened(object sender, EventArgs e)                          //dropdown menu for filtering
        {
            GameData db = new GameData();
            var query = from g in db.Games
                        select g;
            FilterDrop.ItemsSource = query.ToList();
        }
    }
}
