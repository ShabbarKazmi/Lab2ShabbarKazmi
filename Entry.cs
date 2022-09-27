using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Java.Util;

namespace Lab2ShabbarKazmi
{
    public class Entry : ObservableObject
    {
        String clue;
        String answer;
        int difficulty;

        //Date date; // commented out for now 
        String date; 

        int id;
        public String Clue { get { return clue; } set { SetProperty(ref clue, value); } }
        public String Answer { get { return answer; } set { SetProperty(ref answer, value); } }
        public int Difficulty { get { return difficulty; } set { SetProperty(ref difficulty, value); } }
        public String CurrentDate { get { return date; } set { SetProperty(ref date, value); } }
        public int Id { get { return id; } set { SetProperty(ref id, value); } }

        public Entry(String clue, String answer, int difficulty, String date, int id)
        {
            this.answer = answer;
            this.clue = clue;
            this.difficulty = difficulty;
            this.date = date;
            this.id = id;
        }
    }

}
        
