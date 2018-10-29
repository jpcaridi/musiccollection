using System;
using System.Collections.Generic;
using MusicCollectionController;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionConsole
{
    public class TestApp
    {

        private static readonly String TEST_LIBRARY_NAME = "TEST_LIBRARY";
        private static IMusicCollection _mMusicCollection;
        private static IAlbumLibrary _mAlbumLibrary;

        public static void Main(string[] args)
        {
            _mMusicCollection = Driver.CreateXmlMusicCollection();
            _mAlbumLibrary = Controller.ReadLibrary(_mMusicCollection.Persistance, TEST_LIBRARY_NAME);

            string choice;
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
                choice = Console.In.ReadLine()?.Trim();


            } while (!ProcessChoice(choice));
        }

        private static bool ProcessChoice(string choice)
        {
            bool exit = false;

            switch (choice)
            {
                case "1":
                    PrintCollection();
                    break;
                case "2":
                    AddAlbum();
                    break;
                case "3":
                    DeleteAlbum();
                    break;
                case "4":
                    WriteCollection();
                    break;
                case "5":
                    Search();
                    break;
                case "0":
                    exit = true;
                    break;
            }

            return exit;
        }

        private static void DeleteAlbum()
        {

            PrintCollection();

            Console.Out.Write("Enter an album number to delete: ");
            string entry = Console.In.ReadLine()?.Trim();
            int albumNumber;

            if (Int32.TryParse(entry, out albumNumber))
            {
                albumNumber -= 1;
                if (albumNumber >= 0 && albumNumber < _mAlbumLibrary.Albums.Count)
                {
                    IAlbum album = _mAlbumLibrary.Albums[albumNumber];

                    Console.Out.WriteLine(Controller.DeleteAlbum(_mAlbumLibrary, album)
                        ? "Abum has been deleted."
                        : "Unable to delete album.");
                }
            }
        }

        private static void Search()
        {
            Console.Out.Write("Enter an album search: ");
            var searchString = Console.In.ReadLine()?.Trim();

            IList<IAlbum> albums = Controller.Search(_mMusicCollection.ConsumerService, searchString);

            Console.Out.WriteLine("\nSearch results (" + albums.Count + " items)");
            int num = 1;
            foreach (IAlbum a in albums)
            {
                Console.Out.WriteLine("" + num + ".  Name: " + a.Name + " Artist: " + a.Artist + " Year:" + a.Year);
                num++;
            }

            Console.Out.Write("Add to collection (Enter Number - 0 to not add)? ");
            String selection = Console.In.ReadLine()?.Trim();
            if (selection != null)
            {
                int choice = int.Parse(selection) - 1;

                if (choice >= 0 && choice < albums.Count)
                {
                    IAlbum album = albums[choice];
                    Controller.AddAlbum(_mAlbumLibrary, album);
                }
            }
        }

        private static void AddAlbum()
        {

            Console.Out.Write("Album Name: ");
            String name = Console.In.ReadLine();

            Console.Out.Write("Album Artist: ");
            String artist = Console.In.ReadLine();

            Console.Out.Write("Album Year: ");
            String yearString = Console.In.ReadLine();
            if (yearString != null)
            {
                uint year = uint.Parse(yearString);

                Controller.AddAlbum(_mAlbumLibrary, name, artist, year, "");
            }
        }

        private static void PrintCollection()
        {
            Console.Out.WriteLine("\n\t--- Music Collection ---");
            Console.Out.WriteLine("\t\t" + _mAlbumLibrary.Albums.Count + " items");
            Int32 num = 1;

            foreach (IAlbum a in _mAlbumLibrary.Albums)
            {
                Console.Out.WriteLine("\t" + num + ". " + a.Name + " " + a.Artist + " " + a.Year);
                num++;
            }
            Console.Out.WriteLine(" \t-----------------------\n");
        }

        private static void WriteCollection()
        {
            Controller.WriteLibrary(_mMusicCollection.Persistance, _mAlbumLibrary);
        }
    }
}
