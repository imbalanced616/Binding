
namespace BindingApp;

public partial class Binding3 : ContentPage
{
    // Создание класса Car
    public class Car
    {
        public string Company { get; set; } = "";
        public string Model { get; set; } = "";
        public int Price { get; set; }
    }
    // Список машин
    public List<Car> Cars { get; set; }
    // Список, отображаемый на форме
    ListView listView = new ListView();
    // Создание полей ввода
    Entry companyEntry, modelEntry, priceEntry;
    public Binding3()
	{
        // определяем данные
        Cars = new List<Car>
        {
            new Car {Company = "Lada", Model="Granta", Price = 75000},
            new Car {Company = "Audi", Model="A5", Price = 1750000},
            new Car {Company = "BMW", Model="X6", Price = 2350000}
        };
        
        // определяем источник данных
        listView.ItemsSource = Cars;
        // определяем шаблон данных
        listView.ItemTemplate = new DataTemplate(() =>
        {
            // привязка к свойству Company
            Label companyLabel = new Label { Margin = new Thickness(15, 0), WidthRequest = 75, HorizontalOptions = LayoutOptions.Center };
            companyLabel.SetBinding(Label.TextProperty, "Company");

            // привязка к свойству Model
            Label modelLabel = new Label { Margin = new Thickness(15, 0), WidthRequest = 75, HorizontalOptions = LayoutOptions.Center };
            modelLabel.SetBinding(Label.TextProperty, "Model");

            // привязка к свойству Price
            Label priceLabel = new Label { Margin = new Thickness(15, 0), WidthRequest = 75, HorizontalOptions = LayoutOptions.Center };
            priceLabel.SetBinding(Label.TextProperty, "Price");

            // создаем объект ViewCell.
            return new ViewCell
            {
                View = new StackLayout
                {
                    WidthRequest = 300,
                    HeightRequest = 35,
                    Padding = new Thickness(0, 5),
                    Orientation = StackOrientation.Horizontal,
                    Children = { companyLabel, modelLabel, priceLabel }
                }
            };
        });

        // поля для добавления нового объекта User
        companyEntry = new Entry { Placeholder = "Введите компанию", Margin = 5, WidthRequest = 300, HeightRequest = 20 };
        modelEntry = new Entry { Placeholder = "Введите модель", Margin = 5, WidthRequest = 300, HeightRequest = 20 };
        priceEntry = new Entry { Placeholder = "Введите цену", Margin = 5, WidthRequest = 300, HeightRequest = 20 };
        Button saveButton = new Button { Text = "Добавить", WidthRequest = 150, HeightRequest = 45, Margin = 5 };
        saveButton.Clicked += SaveButton_Clicked;
        StackLayout form = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
            Children = { companyEntry, modelEntry, priceEntry, saveButton }
        };
        Content = new StackLayout { Orientation = StackOrientation.Vertical, Children = { form, listView }, Padding = 7 };
    }

    // Событие для кнопки
    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        int.TryParse(priceEntry.Text, out var price);
        Cars.Add(new Car { Company = companyEntry.Text, Model = modelEntry.Text, Price = price });
        listView.ItemsSource = null;
        companyEntry.Text = modelEntry.Text = priceEntry.Text = "";
        listView.ItemsSource = Cars;
    }
}