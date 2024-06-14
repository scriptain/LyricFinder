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
                        // store the lyrics in "content"
                        string content = File.ReadAllText(file);
                        // perform a case insensitive search for searchTerm
                        if(content.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                        {
                            // Match found, add it to matches array 
                            matches.Append(file).ToArray();
                            Console.WriteLine(file);
                        }
                    } catch (Exception ex)
                    {
                    Console.WriteLine(ex.Message); 
                    }

                }
            }
            else
            {
                Console.Write("Directory Doesn't Exist");
            }
            foreach(string match in matches) 
             {
                Console.WriteLine(match);
             }
            return matches;
        }



    }
}
