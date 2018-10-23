using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using MusicCollectionModel;
using MusicCollectionController;

namespace TestingApplication
{
    public class TestApp
    {
        public static void Main(string[] args)
        {
            AlbumLibrary albumLibrary = Controller.ReadLibrary();

            String choice = "0";
            do
            {
                Console.Out.WriteLine("   -- Menu -- ");
                Console.Out.WriteLine("1 - Print Collection ");
                Console.Out.WriteLine("2 - Add Album ");
                Console.Out.WriteLine("3 - Delete Album ");
                Console.Out.WriteLine("4 - Save Collection ");
                Console.Out.WriteLine("5 - Search");
                Console.Out.WriteLine("0 - Exit ");
                Console.Out.Write("Please Enter a Selection: ");
                choice = Console.In.ReadLine().Trim();


            } while (!ProcessChoice(choice, albumLibrary));
        }

        private static bool ProcessChoice(String choice, AlbumLibrary albumLibrary)
        {
            bool exit = false;

            switch (choice)
            {
                case "1":
                    PrintCollection(albumLibrary);
                    break;
                case "2":
                    AddAlbum(albumLibrary);
                    break;
                case "3":
                    DeleteAlbum(albumLibrary);
                    break;
                case "4":
                    WriteCollection(albumLibrary);
                    break;
                case "5":
                    Search(albumLibrary);
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    break;
            }

            return exit;
        }

        private static void DeleteAlbum(AlbumLibrary albumLibrary)
        {

            PrintCollection(albumLibrary);

            Console.Out.Write("Enter an album number to delete: ");
            String entry = Console.In.ReadLine().Trim();
            int albumNumber;

            if (Int32.TryParse(entry, out albumNumber))
            {
                albumNumber -= 1;
                if (albumNumber >= 0 && albumNumber < albumLibrary.Albums.Count)
                {
                    Album album = albumLibrary.Albums[albumNumber];

                    if (Controller.DeleteAlbum(albumLibrary, album))
                    {
                        Console.Out.WriteLine("Abum has been deleted.");
                    }
                    else
                    {
                        Console.Out.WriteLine("Unable to delete album.");
                    }
                }
            }
        }

        private static void Search(AlbumLibrary albumLibrary)
        {
            String searchString;

            Console.Out.Write("Enter an album search: ");
            searchString = Console.In.ReadLine().Trim();

            IList<Album> albums = Controller.Search(searchString);

            Console.Out.WriteLine("\nSearch results (" + albums.Count + " items)");
            int num = 1;
            foreach (Album a in albums)
            {
                Console.Out.WriteLine("" + num + ".  Name: " + a.Name + " Artist: " + a.Artist + " Year:" + a.Year);
                num++;
            }

            Console.Out.Write("Add to collection (Enter Number - 0 to not add)? ");
            String selection = Console.In.ReadLine().Trim();
            Int32 choice = Int32.Parse(selection) - 1;

            if (choice >= 0 && choice < albums.Count)
            {
                Album album = albums[choice];
                Controller.AddAlbum(albumLibrary, album);
            }

        }

        private static void AddAlbum(AlbumLibrary albumLibrary)
        {

            Console.Out.Write("Album Name: ");
            String name = Console.In.ReadLine();

            Console.Out.Write("Album Artist: ");
            String artist = Console.In.ReadLine();

            Console.Out.Write("Album Year: ");
            String yearString = Console.In.ReadLine();
            UInt32 year = UInt32.Parse(yearString);

            Controller.AddAlbum(albumLibrary, new Album(name, artist, year));
        }

        private static void PrintCollection(AlbumLibrary albumLibrary)
        {
            Console.Out.WriteLine("\n\t--- Music Collection ---");
            Console.Out.WriteLine("\t\t" + albumLibrary.Albums.Count + " items");
            Int32 num = 1;

            foreach (Album a in albumLibrary.Albums)
            {
                Console.Out.WriteLine("\t" + num + ". " + a.Name + " " + a.Artist + " " + a.Year);
                num++;
            }
            Console.Out.WriteLine(" \t-----------------------\n");
        }

        private static void WriteCollection(AlbumLibrary albumLibrary)
        {
            Controller.WriteLibrary(albumLibrary);
        }
    }
}
