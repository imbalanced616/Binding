
namespace BindingApp;

public partial class Binding4 : ContentPage
{
    // Создание класса Car
    public class Car
    {
        public string Company { get; set; } = "";
        public string Model { get; set; } = "";
        public int Price { get; set; }
        public string ModelAndPrice { get { return Model + " от " + Price; } }
        public string ImagePath { get; set; } = "";
    }
    public Binding4()
	{
        ListView listView = new ListView();
        // определяем источник данных
        listView.ItemsSource = new List<Car>
        {
            new Car {Company = "Lada", ImagePath="Lada.png", Model="Granta", Price = 75000},
            new Car {Company = "Audi", ImagePath="Audi.png", Model="A5", Price = 1750000},
            new Car {Company = "BMW", ImagePath="BMW.png", Model="X6", Price = 2350000}
        };
        // определяем шаблон данных
        listView.ItemTemplate = new DataTemplate(() =>
        {
            ImageCell imageCell = new ImageCell
            {
                TextColor = Colors.Black,
                DetailColor = Colors.Black
            };
            imageCell.SetBinding(ImageCell.TextProperty, "Company");
            imageCell.SetBinding(ImageCell.DetailProperty, "ModelAndPrice");
            imageCell.SetBinding(ImageCell.ImageSourceProperty, "ImagePath");
            return imageCell;
        });

        Label header = new Label { FontSize = 20, Text = "Автомобили", TextColor = Colors.Black, FontAttributes = FontAttributes.Bold, Margin = new Thickness(0, 15), HorizontalOptions = LayoutOptions.Center };
        Content = new StackLayout { Background=Colors.Wheat, Children = { header, listView }, Padding = 7 };
    }
}