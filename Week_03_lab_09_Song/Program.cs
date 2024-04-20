using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Week_03_lab_09_Song
{
    //create enum SongGenre with the flags attribute
    [Flags]
    public enum SongGenre
    {
        Unclassified = 0,
        Pop = 0b1,
        Rock = 0b10,
        Blues = 0b100,
        Country = 0b1_000,
        Metal = 0b10_000,
        Soul = 0b100_000
    }
    //Song class
    public class Song
    {
        public string Artist { get; }
        public string Title { get; }
        public double Length { get; }
        public SongGenre Genre { get; }

        //constructor with 4 arguments
        public Song(string title, string artist, double length, SongGenre genre)
        {
            Title = title;
            Artist = artist;
            Length = length;
            Genre = genre;
        }

        //toString method
        public override string ToString()
        {
            return $"{Title} by {Artist} ({Genre}) {Length:N2} mins"; //added N2 to format the length to display up to 2 decimal places, thus matching the expected output provided on the lab document
        }
    }
    //static Library class
    public static class Library 
    { 
    private static List<Song> songs = new List<Song>(); //initialize songs field to a new List of Song

        //methods
        public static void DisplaySongs()  //this method is to display all songs in the collection
        {
            foreach (Song song in songs)
            { 
            Console.WriteLine(song);
            }
        }
        public static void DisplaySongs(double longerThan) //method that takes a double argument and displays only songs that are longer than the argument.
        {
            foreach (Song song in songs) 
            {
                if (longerThan < song.Length)                
                {
                    Console.WriteLine(song);
                }

            }
        }
        public static void DisplaySongs(SongGenre genre) //method that takes a SongGenre argument and displays only songs that are of this genre.
        {
            foreach (Song song in songs) 
            {
                if (song.Genre.HasFlag(genre)) // Using the HasFlag method to check if the song's genre matches
                { 
                Console.WriteLine(song);    
                }     
            }
        }
        public static void DisplaySongs(string artist) //method that takes a string argument and displays only songs by this artist.
        {
            foreach (Song song in songs)
            {
                if (artist == song.Artist)
                {
                    Console.WriteLine(song);
                }
            }
        }
        public static void LoadSongs(string fileName) //takes a single string argument that represents the text file containing the collection of songs
        {
            using (StreamReader reader = new StreamReader(fileName)) //using StreamReader to read the text file
            {
                string title;
                while ((title = reader.ReadLine()) != null) //while loop to read each line from the file until the end is reached
                    { 
                    string artist = reader.ReadLine(); //reads next line for the artist
                    double length = Convert.ToDouble(reader.ReadLine()); //reads and convert next line for the song's length
                    SongGenre genre = (SongGenre)Enum.Parse(typeof(SongGenre), reader.ReadLine()); //reads next line and parses it to a SongGenre enum value. Uses the Enum.Parse() to get the required type
                    
                    //Add the objects to the songs list
                    songs.Add(new Song(title, artist, length, genre));
                }
            }
        }
    }
    internal class Program
        {
        //provided code from the lab for displaying songs
            static void Main(string[] args)
            {
            Console.WriteLine(new Song("Baby", "Justin Bieber", 3.35, SongGenre.Pop));
            Console.WriteLine(new Song("The Promise", "Chris Cornell", 4.26, SongGenre.Country | SongGenre.Rock));

            Library.LoadSongs("Week_03_lab_09_songs4.txt");
            Console.WriteLine("\n\nAll songs");
            Library.DisplaySongs();

            SongGenre genre = SongGenre.Rock;
            Console.WriteLine($"\n\n{genre} songs");
            Library.DisplaySongs(genre);

            string artist = "Bob Dylan";
            Console.WriteLine($"\n\nSongs by {artist}");
            Library.DisplaySongs(artist);

            double length = 5.0;
            Console.WriteLine($"\n\nSongs more than {length}mins");
            Library.DisplaySongs(length);

            Console.ReadKey();
            }
        }
}
