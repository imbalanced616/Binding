﻿namespace BindingApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        ResourceDictionary = new Dictionary<string, ResourceDictionary>();
        foreach (var dictionary in Application.Current.Resources.MergedDictionaries)
        {
            string key = dictionary.Source.OriginalString.Split(';').First().Split('/').Last().Split('.').First();
            ResourceDictionary.Add(key, dictionary);
        }
    }

    public static Dictionary<string, ResourceDictionary> ResourceDictionary;
}
