
namespace Lab2ShabbarKazmi;

public partial class MainPage : ContentPage
{
    public String userClue = null;
    public String userAnswer= null;
    public String userDate = null;
    public int userDifficulty =-1;
    public int id = 0; // need to find a way to get the largest id in the list

	public MainPage()
	{
		InitializeComponent();
        //EntriesLV.ItemsSource = MauiProgram.crossword.AllEntries;
    }

    // Clue Field 
    private void ClueCompleted (object sender, EventArgs e)
	{
      userClue = Clue.Text;
    }
	 private void ClueTextChanged(object sender, TextChangedEventArgs e)
	{
        userClue = Clue.Text;
    }



    //Answer Field 
    private void AnswerTextChanged(object sender, TextChangedEventArgs e)
    {
        userAnswer = Answer.Text;
    }
    private void AnswerCompleted(object sender, EventArgs e)

    {
      userAnswer = Answer.Text;       
    }

    //Difficulty Field 
    private void DifficultyCompleted(object sender, EventArgs e)
    {
        int changedDifficulty = Int32.Parse(Difficulty.Text);
        if (changedDifficulty > 3 || changedDifficulty < 0)
        {
            DisplayAlert("Invalid Difficulty", "Please make sure difficulty is within range (1-3", "Ok");
        }
        else
        {
            userDifficulty = changedDifficulty;
        }
    }

    //Date Field
    void OnDateSelected(object sender, DateChangedEventArgs args)
    {
        userDate = (((DatePicker)sender).Date.ToString("d"));
    }

    private void onAdd(Object send, EventArgs e)
    {
        if (userClue is not null && userAnswer is not null && userDate is not null
                && userDifficulty != -1)
        {
            MauiProgram.crossword.AllEntries.Add(new Entry(userClue,
            userAnswer, userDifficulty, userDate, ++id));

            DisplayAlert("Entry Sucessful", "Entry was successfully added", "Ok");   
        }
        else
            DisplayAlert("Invalid Entry", "Please make sure no field is left empty", "Ok");

    }

    // Button methods
    private async void onEdit(Object send, EventArgs e)
    {

        string userEditId = await DisplayPromptAsync("Edit Entry", "Enter Id of entry:", keyboard: Keyboard.Numeric);

        Entry editEntry = GetEntry(Int32.Parse(userEditId));

        if (editEntry is not null)
        {
            int editId = MauiProgram.crossword.AllEntries.IndexOf(editEntry);

            String editClue = await DisplayPromptAsync("Edit Entry", "Enter new Clue:", keyboard: Keyboard.Text);
            String editAnswer = await DisplayPromptAsync("Edit Entry", "Enter new Answer:", keyboard: Keyboard.Text);
            String editDifficulty = await DisplayPromptAsync("Edit Entry", "Enter new Difficulty:", keyboard: Keyboard.Numeric);
            String editdate = await DisplayPromptAsync("Edit Entry", "Enter new date:", keyboard: Keyboard.Text);


            MauiProgram.crossword.AllEntries[editId].Clue = editClue;
            MauiProgram.crossword.AllEntries[editId].Answer = editAnswer;
            MauiProgram.crossword.AllEntries[editId].CurrentDate = editdate;
            MauiProgram.crossword.AllEntries[editId].Difficulty = Int32.Parse(editDifficulty);
            


            DisplayAlert("Edit Entry", "Entry was edited successfully", "Ok");
        }
        else
        {
            DisplayAlert("Edit Entry", "Entry was not found, Please enter valid Id", "Ok");
        }

    }
    private async void onDelete(Object send, EventArgs e)
    {
        

        string deletionId = await DisplayPromptAsync("Delete Entry", "Enter Id of entry:", keyboard: Keyboard.Numeric);

        Entry deletionEntry = GetEntry(Int32.Parse(deletionId));

        if (deletionEntry is not null)
        {
            MauiProgram.crossword.AllEntries.Remove(deletionEntry);

            await DisplayAlert("Delete Entry", "Entry successfully deleted", "Ok");

        }
        else
        {
            await DisplayAlert("Delete Entry", "Entry was not successfully deleted, Please enter valid Id", "Ok");
        }
    }

    private Entry GetEntry(int id)
    {
        foreach (Entry entry in MauiProgram.crossword.AllEntries)
        {
            if (entry.Id == id)
            {
                return entry;
            }
        }
        return null;
    }
}




