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

namespace Logan_G___D201_Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public bool Availablilty { get; set; }

        public Movie(int movie_id, string title, string director, string genre, int release_year, bool availability)
        {
            MovieID = movie_id;
            Title = title;
            Director = director;
            Genre = genre;
            ReleaseYear = release_year;
            Availablilty = availability;
        }

    }

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