using System.Collections;
using System.Runtime.ExceptionServices;
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

    

    public partial class MainWindow : Window
    {
        private Hashtable movieTable;
        private Dictionary<int, Queue<string>> movieDictionary = new Dictionary<int, Queue<string>>();

        private Movie HTTYD1;
        private Movie HTTYD2;
        private Movie alien;
        
        private Movie storedMovie1;

        public MainWindow()
        {
            InitializeComponent();
            
            movieTable = new Hashtable();

            HTTYD1 = new Movie(1, "How to Train your Dragon", "Chris Sanders", "Fantasy", 2010, true);
            HTTYD2 = new Movie(2, "How to Train your Dragon 2", "Dean DeBlois", "Fantasy", 2014, true);
            alien = new Movie(3, "Alien", "Joe Mama", "Horror", 1990, false);

            movieTable.Add(HTTYD1.MovieID, HTTYD1);
            movieTable.Add(HTTYD2.MovieID, HTTYD2);
            movieTable.Add(alien.MovieID, alien);


            storedMovie1 = (Movie)movieTable[1];
            System.Diagnostics.Debug.WriteLine("Movie ID: {0}, Title: {1}, Director: {2}, Genre: {3}, Year: {4}, Available {5}", storedMovie1.MovieID, storedMovie1.Title, storedMovie1.Director, storedMovie1.Genre, storedMovie1.ReleaseYear, storedMovie1.Availablilty);
            
            loadMovieOnStartup();

        }

        //Converts a string into an integer if exists, then if that integer contains the key of the Movie which is MovieID then it will display it in the dtgMovies
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchBox = tbxSearch.Text;
            int i = 0;
            Int32.TryParse(searchBox, out i);

            if (movieTable.ContainsKey(i))
            {
                dtgMovies.DataContext = null;
                Movie hashMovie = (Movie)movieTable[i];
                dtgMovies.ItemsSource = new List<Movie> { hashMovie };
            }
        }


        private void loadMovieOnStartup()
        {
            MovieLinkedList movieCollection = new MovieLinkedList();

            movieCollection.movieInsertion(HTTYD1);
            movieCollection.movieInsertion(HTTYD2);
            movieCollection.movieInsertion(alien);

            dtgMovies.ItemsSource = movieCollection.ToList();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            dtgMovies.Items.Refresh();
        }

        private void btnBorrow_Click(object sender, RoutedEventArgs e)
        {

            Movie selectedMovie = dtgMovies.SelectedItem as Movie;

            if (selectedMovie == null)
            {
                MessageBox.Show("Please select a movie to borrow");
            }
            else
            {
                if (selectedMovie.Availablilty == true)
                {
                    selectedMovie.Availablilty = false;
                    MessageBox.Show("You have borrowed a movie");
                    dtgMovies.Items.Refresh();
                }
                else if (string.IsNullOrWhiteSpace(tbxSearch.Text))
                {
                    MessageBox.Show("Please put your name in the textbox");
                }
                else
                {
                    if (!movieDictionary.ContainsKey(selectedMovie.MovieID)) 
                    {
                        movieDictionary[selectedMovie.MovieID] = new Queue<string>();
                    }

                    movieDictionary[selectedMovie.MovieID].Enqueue(tbxSearch.Text);

                    MessageBox.Show($"{tbxSearch.Text} added to waiting list for {selectedMovie.MovieID}");
                }
                //if (movieDictionary.ContainsKey(selectedMovie.MovieID))
                //{
                //    Queue<string> waitingList = movieDictionary[selectedMovie.MovieID];

                //    string queueText = string.Join(Environment.NewLine, waitingList);

                //    MessageBox.Show("Waiting list:\n" + queueText);
                //}
            }
        }

        private void btnReturn1_Click(object sender, RoutedEventArgs e)
        {
            Movie selectedMovie = (Movie)dtgMovies.SelectedItem;

            if (selectedMovie == null) 
            {
                MessageBox.Show("Please select a movie to return");
            }
            else
            {
                if (selectedMovie.Availablilty == true)
                {
                    MessageBox.Show("This movie has already been returned");
                }
                else
                {
                    if (movieDictionary.ContainsKey(selectedMovie.MovieID) && movieDictionary[selectedMovie.MovieID].Count > 0) 
                    {
                        string nextCustomer = movieDictionary[selectedMovie.MovieID].Peek();
                        MessageBox.Show(nextCustomer + " is next to rent");
                        movieDictionary[selectedMovie.MovieID].Dequeue();
                    }
                    else
                    {
                        selectedMovie.Availablilty = true;
                        MessageBox.Show("Movie is available to be rented");
                        dtgMovies.Items.Refresh();
                    }
                }
            }
        }
    }
}