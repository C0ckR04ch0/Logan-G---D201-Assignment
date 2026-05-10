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
using Logan_G___D201_Assignment.Classes;

namespace Logan_G___D201_Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    //public class MovieNode
    //{

    //}

    //public class MyLinkedList
    //{

    //}

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadMovieOnStartup();


        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadMovieOnStartup()
        {
            Movie HTTYD = new Movie(1, "How to Train your Dragon", "Chris Sanders", "Fantasy", 2010, true);
            dtgMovies.ItemsSource = new List<Movie>([HTTYD]);
        }
    }
}