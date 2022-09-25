namespace Lab2ShabbarKazmi;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}
    
	private void onEdit(Object send , EventArgs e)
	{
		EditButton.Text = "This button hase been clickd";
	}

    private void onDelete(Object send, EventArgs e)
    {
        DeleteButton.Text = "This button hase been clickd";
    }

    private void onAdd(Object send, EventArgs e)
    {
        AddButton.Text = "This button hase been clickd";
    }
    
	private void ClueTextChanged(object sender, TextChangedEventArgs e)
	{
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = Clue.Text;
    }
 
	private void ClueCompleted (object sender, EventArgs e)
	{
        string text = ((Entry)sender).Text;
    }


    private void AnswerTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = Answer.Text;
    }

    private void AnswerCompleted(object sender, EventArgs e)
    {
        string text = ((Entry)sender).Text;
    }

    private void DifficultyChanged(Object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = Answer.Text;
    }

    private void DifficultyCompleted(object sender, EventArgs e)
    {
        string text = ((Entry)sender).Text;
    }









}

