namespace LyricFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                Console.WriteLine("Enter a lyric to search:");
                var input = Console.ReadLine(); 
                Search(input);
            }
        }

        // Search() takes in a search term as input and searches the ./Library/Beatles directory
        // may expand to other bands/artists down the track
        static string Search(string searchTerm)
        {
            // @ signifies 'verbatim string' ignoring escape sequences 
            string libraryPath = @"C:\Users\scrip\source\repos\LyricFinder\LyricFinder\Library\Beatles";

            if (Directory.Exists(libraryPath))
            {
                // capture/store the contents of each .txt file in the 'libraryPath' directory  
                string[] files = Directory.GetFiles(libraryPath, "*.txt", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    // at this point 'file' is a string that contains the full path of every song across all albums
                    Console.WriteLine($"{file}");

                }
            }
            else
            {
                Console.Write("Directory Doesn't Exist");
            }

            return searchTerm;
        }



    }
}
