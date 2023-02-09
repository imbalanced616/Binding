namespace BindingApp;

public partial class Binding2 : ContentPage
{
	public Binding2()
	{
		InitializeComponent();
	}

	// Событие для кнопки
    private void Button_Clicked(object sender, EventArgs e)
    {
		string s1 = entryBox1.Text;
		string s2 = entryBox2.Text;
        string s3 = entryBox3.Text;

		entryBox3.Text = s2;
		entryBox1.Text = s3;
		entryBox2.Text = s1;
    }
}