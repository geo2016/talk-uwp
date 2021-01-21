using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace AppListView
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Animal> _animals;
        private static readonly string[] animalTitles =
        {
            "Dog","Cat","Elephont","Spider","Snake","Clock","Pig"
        };

        public MainPage()
        {
            this.InitializeComponent();

            _animals = CreateAnimals();
            lv1.ItemsSource = _animals;
        }

        private ObservableCollection<Animal> CreateAnimals()
        {
            var animals = new ObservableCollection<Animal>();

            var r1 = new Random();
            for (int i = 0; i < 20; i++)
            {
                animals.Add(new Animal()
                {
                    Title=animalTitles[r1.Next(0,animalTitles.Length)],
                    Age = r1.Next(1, 20)
                });
            }

            return animals;
        }

        private void btnAdd(object sender, RoutedEventArgs e)
        {
            var r1 = new Random();
            _animals.Insert(0,new Animal()
            {
                Title = animalTitles[r1.Next(0, animalTitles.Length)],
                Age = r1.Next(1, 20)
            });
        }

        private void btnChangeFirstRow(object sender, RoutedEventArgs e)
        {
            var o1 = _animals[0];
            o1.Title = "Cat";
            o1.Age = 8;
        }
    }
}
