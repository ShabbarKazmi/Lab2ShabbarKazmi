
using System;
using System.Text.Json;
using System.IO;
using System.Collections.ObjectModel;


namespace Lab2ShabbarKazmi
{
    public class Database
    {

        const String filename = "clues.db";

        JsonSerializerOptions options;


        private ObservableCollection<Entry> entries = new ObservableCollection<Entry>();

        public ObservableCollection<Entry> AllEntries
        {
            get { return entries; }
            set { entries = value; }
        }

        public Database()
        {
            GetEntries();
            options = new JsonSerializerOptions { WriteIndented = true };
        }

        public async void WriteTextToFile(string text, string targetFileName)
        {
            // Write the file content to the app data directory
            string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, targetFileName);
            using FileStream outputStream = System.IO.File.OpenWrite(targetFile);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            await streamWriter.WriteAsync(text);
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
/*
        public bool ReplaceEntry(Entry replacementEntry)
        {
            foreach (Entry entry in entries) // iterate through entries until we find the Entry in question
            {
                if (entry.Id == replacementEntry.Id) // found it
                {
                    entry.Answer = replacementEntry.Answer;
                    entry.Clue = replacementEntry.Clue;
                    entry.Difficulty = replacementEntry.Difficulty;
                    entry.Date = replacementEntry.Date;         // change it then write it out

                    try
                    {
                        string jsonString = JsonSerializer.Serialize(entries, options);
                        File.WriteAllText(filename, jsonString);
                        return true;
                    }
                    catch (IOException ioe)
                    {
                        Console.WriteLine("Error while replacing entry: {0}", ioe);
                    }

                }
            }
            return false;
        }
    }
}
