namespace Lab2ShabbarKazmi;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private void OnEdit(Object send , EventArgs e)
	{
		EditButton.Text = "This button hase been clickd";
	}

    private void onDelete(Object send, EventArgs e)
    {
        EditButton.Text = "This button hase been clickd";
    }

    private void onAdd(Object send, EventArgs e)
    {
        EditButton.Text = "This button hase been clickd";
    }

}

