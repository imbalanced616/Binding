namespace BindingApp;

public partial class Binding1 : ContentPage
{
    // Создание полей ввода и меток
    Entry entry1 = new Entry()
    {
        Margin = 5,
        WidthRequest = 300,
        HeightRequest = 20
    }, entry2 = new Entry()
    {
        Margin = 5,
        WidthRequest = 300,
        HeightRequest = 20
    }, entry3 = new Entry()
    {
        Margin = 5,
        WidthRequest = 300,
        HeightRequest = 20
    };
    Label label1 = new Label()
    {
        Margin = 5,
        WidthRequest = 300,
        HeightRequest = 20,
        Background = new SolidColorBrush(Colors.White),
        TextColor = Colors.Black
    }, label2 = new Label()
    {
        Margin = 5,
        WidthRequest = 300,
        HeightRequest = 20,
        Background = new SolidColorBrush(Colors.White),
        TextColor = Colors.Black
    }, label3 = new Label()
    {
        Margin = 5,
        WidthRequest = 300,
        HeightRequest = 20,
        Background = new SolidColorBrush(Colors.White),
        TextColor = Colors.Black
    };
    public Binding1()
	{
        // Создание кнопки и события для неё
        Button button = new Button { Text = "Поменять", WidthRequest = 150, HeightRequest = 45, Margin = 5 };
        button.Clicked += Button_Clicked;

        // Устанавливаем привязку
        // источник привязки - entry, цель привязки - label
        label1.BindingContext = entry1;
        label2.BindingContext = entry2;
        label3.BindingContext = entry3;

        // Связываем свойства источника и цели
        label1.SetBinding(Label.TextProperty, "Text");
        label2.SetBinding(Label.TextProperty, "Text");
        label3.SetBinding(Label.TextProperty, "Text");


        // определяем объект привязки: Source - источник, Path - его свойство
        Binding binding1 = new Binding { Source = entry1, Path = "Text" };
        Binding binding2 = new Binding { Source = entry2, Path = "Text" };
        Binding binding3 = new Binding { Source = entry3, Path = "Text" };
        // установка привязки для свойства TextProperty
        label1.SetBinding(Label.TextProperty, binding1);
        label2.SetBinding(Label.TextProperty, binding2);
        label3.SetBinding(Label.TextProperty, binding3);

        StackLayout stackLayout = new StackLayout()
        {
            Children = { entry1, entry2, entry3, button, label1, label2, label3 },
            Padding = 20
        };
        Content = stackLayout;
    }

    // Событие для кнопки
    private void Button_Clicked(object sender, EventArgs e)
    {
        string s1 = entry1.Text;
        string s2 = entry2.Text;
        string s3 = entry3.Text;

        entry3.Text = s2;
        entry1.Text = s3;
        entry2.Text = s1;
    }
}

