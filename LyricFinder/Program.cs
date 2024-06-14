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
                string[] matches = Search(input);
                Console.WriteLine(matches.Length);
            }
        }

        // Search() takes in a search term as input and searches the ./Library/Beatles directory
        // may expand to other bands/artists down the track
        static string[] Search(string searchTerm)
        {
            // @ signifies 'verbatim string' ignoring escape sequences 
            string libraryPath = @"C:\Users\scrip\source\repos\LyricFinder\LyricFinder\Library\Beatles";
            string[] matches = Array.Empty<string>();
            if (Directory.Exists(libraryPath))
            {
                // capture/store the contents of each .txt file in the 'libraryPath' directory  
                string[] files = Directory.GetFiles(libraryPath, "*.txt", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    // at this point 'file' is a string that contains the full path of every song across all albums
                    // wrapping in try catch block so as to 'gracefully' handle various errors such as filenotfound, access denied, disk errors
                    try
                    {
                        // Read all lines in the current file
                        string[] lines = File.ReadAllLines(file);

                        // go through the song line by line
                        for (int i = 0; i < lines.Length; i++)
                        {
                            // check if this line is a match
                            if (lines[i].Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine($"Found a match at line: {i}");
                                Console.WriteLine(lines[i]);
                                Console.WriteLine(file);
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");


                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.ToString());
                    }
                }
            }
            else
            {
                Console.Write("Directory Doesn't Exist");
            }
            return matches;



        }

        public struct Match
        {
            // {get; set;} are 'accessors' for the property. They define how the property can be accessed and modified
            // get: returns the value of the property. Match.artist is called
            // set: assigns a value to the property. Match.artist = "Bono" uses set implicitly
            public string artist { get; set; }
            public string album { get; set; }
            public string songTitle { get; set; }
            public int line { get; set; }
        }
    }
}