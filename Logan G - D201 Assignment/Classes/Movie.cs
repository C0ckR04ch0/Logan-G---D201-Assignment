namespace Logan_G___D201_Assignment.Classes
{
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

    //Creating Nodes for movies
    public class MovieNode
    {
        public Movie Data;
        public MovieNode Next;

        public MovieNode(Movie movie)
        {
            Data = movie;
            Next = null;
        }
    }

    //creating a linked list for the entire Movie Collection
    public class MovieLinkedList
    {
        public MovieNode head;

        public void movieInsertion(Movie movie)
        {
            MovieNode newMovieNode = new MovieNode(movie);
            if (head == null)
            {
                head = newMovieNode;
            }
            else
            {
                MovieNode current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newMovieNode;
            }
        }

        public void BubbleSort()
        {
            if (head == null || head.Next == null) 
            {
                return;
            }

            bool swapped;
            do
            {
                swapped = false;
                MovieNode current = head;
                while (current.Next != null)
                {
                    if (string.Compare(current.Data.Title, current.Next.Data.Title) > 0)
                    {
                        Movie temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;

                        swapped = true;
                    }
                    current = current.Next;
                }
            }
            while (swapped);
        }

        public MovieNode GetMiddleMergeSort(MovieNode head)
        {
            if (head == null)
            {
                return null;
            }

            MovieNode slow = head;
            MovieNode fast = head;

            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return slow;
        }


        public void MergeSortByReleaseYear()
        {
            head = MergeSort(head);
        }

        public MovieNode MergeSort(MovieNode node)
        {
            if (node == null || node.Next == null)
            {
                return node;
            }

            MovieNode middle = GetMiddleMergeSort(node);
            MovieNode nextOfMiddle = middle.Next;
            middle.Next = null;

            MovieNode left = MergeSort(node);
            MovieNode right = MergeSort(nextOfMiddle);

            return SortedMerge(left, right);
        }

        public MovieNode SortedMerge(MovieNode a, MovieNode b)
        {
            if (a == null)
            {
                return b;
            }
            if (b == null)
            {
                return a;
            }

            MovieNode result;

            if (a.Data.ReleaseYear <= b.Data.ReleaseYear)
            {
                result = a;
                result.Next = SortedMerge(a.Next, b);
            }
            else
            {
                result = b;
                result.Next = SortedMerge(a, b.Next);
            }

            return result;
        }

        //Ensures that the Datagrid can read any movies in the linked list
        public List<Movie> ToList()
        {
            List<Movie> movieList = new List<Movie>();
            MovieNode current = head;

            while (current != null)
            {
                movieList.Add(current.Data);
                current = current.Next;
            }

            return movieList;
        }

        public MovieNode GetMiddle(MovieNode start, MovieNode end)
        {
            if (start == null)
            {
                return null;
            }

            MovieNode slow = start;
            MovieNode fast = start;

            while (fast != end && fast.Next != end)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }

            return slow;
        }

        public MovieNode BinarySearch(MovieNode head, int searchedID)
        {
            MovieNode start = head;
            MovieNode end = null;

            while (start != end)
            {
                MovieNode mid = GetMiddle(start, end);

                if (mid == null)
                {
                    return null;
                }
                if (mid.Data.MovieID == searchedID)
                {
                    return mid;
                }
                if (mid.Data.MovieID < searchedID)
                { 
                    start = mid.Next;
                }
                else
                {
                    end = mid;
                }

            }

            return null;
        }
    }
}