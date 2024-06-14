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
                List<Match> matches = Search(input);
                foreach (Match match in matches)
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine(match.ToString());
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
            }
        }

        // Search() takes in a search term as input and searches the ./Library/Beatles directory
        // may expand to other bands/artists down the track
        static List<Match> Search(string searchTerm)
        {
            // @ signifies 'verbatim string' ignoring escape sequences 
            string libraryPath = @"C:\Users\scrip\source\repos\LyricFinder\LyricFinder\Library\Beatles";
            // a list of matches that can be iterated through later
            List<Match> matches = new List<Match>();
            if (Directory.Exists(libraryPath))
            {
                // capture/store the contents of each .txt file in the 'libraryPath' directory  
                string[] files = Directory.GetFiles(libraryPath, "*.txt", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    // 'file' is a path that resembles C:\x\x\x\beatles\somealbum\somesong.txt
                    // Extract the name of the album and the name of the song to use later

                    // create a new instance of DirectoryInfo class
                    DirectoryInfo dirInfo = new DirectoryInfo(file);

                    // in this case the directory "Name" will be the title of the song "Run_For_Your_Life.txt"
                    string songName = dirInfo.Name;
                    string album = dirInfo.Parent.Name;
                    string artist = dirInfo.Parent.Parent.Name;
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
                                // construct Match 
                                matches.Add(new Match(artist, album, songName, lines[i], i));
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
            public string Artist { get; }
            public string Album { get; }
            public string SongTitle { get; }
            public string Line { get; }

            public int LineNum { get; }

            public Match(string artist, string album, string songTitle, string line, int lineNum)
            {
                Artist = artist;
                Album = album;
                SongTitle = songTitle;
                LineNum = lineNum;
                Line = line;
            }

            public override string ToString()
            {
                return $"Artist: {Artist} \n Album: {Album} \n Song: {SongTitle} \n Found at line: {LineNum} \n Full Line: {Line}";
            }
        }
    }
}