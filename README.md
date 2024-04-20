You will be practicing to read from a file and building a relatively more complex system consisting o the three interconnected types that is illustrated below:

![image](https://github.com/dyeyniyel/comp123-lab3-part2-Song/assets/158533198/bae69c78-9248-4a13-aa09-7eb39d048a5a)


![image](https://github.com/dyeyniyel/comp123-lab3-part2-Song/assets/158533198/f63d7e42-ca58-4c68-9023-db99182c9f9b)

![image](https://github.com/dyeyniyel/comp123-lab3-part2-Song/assets/158533198/8da4d7f0-9c8b-4ea0-8baf-5e68ffe054d3)


![image](https://github.com/dyeyniyel/comp123-lab3-part2-Song/assets/158533198/951afd34-dde9-4b43-a7c5-088def4fa405)

Test Harness

Insert the following code statements in the Main() method of your Program.cs file:





  //To test the constructor and the ToString method

  Console.WriteLine(new Song("Baby", "Justin Bebier", 3.35, SongGenre.Pop));



  //This is first time that you are using the bitwise or. It is used to specify a combination of genres

  Console.WriteLine(new Song("The Promise", "Chris Cornell", 4.26, SongGenre.Country | SongGenre.Rock));



  Library.LoadSongs("Week_03_lab_09_songs4.txt");     //Class methods are invoke with the class name

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

![image](https://github.com/dyeyniyel/comp123-lab3-part2-Song/assets/158533198/96691204-b544-460c-8655-ffdc7e13720a)



