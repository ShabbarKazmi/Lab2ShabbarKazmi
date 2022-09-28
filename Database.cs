
using System;
using System.Text.Json;
using System.IO;
using System.Collections.ObjectModel;



namespace Lab2ShabbarKazmi
{
    public class Database
    {

        public const String filename = "crossword.db";

       public JsonSerializerOptions jsonOptions;


        private ObservableCollection<Entry> entries = new ObservableCollection<Entry>();

        public ObservableCollection<Entry> AllEntries
        {
            get { return entries; }
            set { entries = value; }
        }

        public Database()
        {
            GetEntries();
            jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        }

        public void AddEntry(Entry entry)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(MauiProgram.crossword.jsonOptions);
                File.WriteAllText(filename, jsonString);
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error while adding entry: {0}", ioe);
            }
       }

        public ObservableCollection<Entry> GetEntries()
        {
            if (!File.Exists(filename))
            {
                File.CreateText(filename);
                entries = new ObservableCollection<Entry>();
                return entries;
            }

            string jsonString = File.ReadAllText(filename);
            if (jsonString.Length > 0)
            {
                entries = JsonSerializer.Deserialize<ObservableCollection<Entry>>(jsonString);
            }
            return entries;
        }








    }
}


