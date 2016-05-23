using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace YouTubeTutorial
{


    public class ListPage : ContentPage {
        ObservableCollection<string> Items;
        public ListPage()
        {
            this.Title = "Tab 1";
            Items = new ObservableCollection<string>();
            var list = new ListView();
            list.ItemsSource = Items;

            list.ItemSelected += (sender, args) =>
             {
                 if (list.SelectedItem == null)
                 {

                     return;
                 }

                 this.Navigation.PushAsync(new ContentPage
                 {

                     Title = "Page 2",
                     Content = new Label
                     {
                         Text = args.SelectedItem as string

                     }
                 });
                 list.SelectedItem = null;

             };
            var button = new Button
            {

                Text = "Add time"
            };
            button.Clicked += (sender, args) =>
            {
                Items.Add(DateTime.Now.ToString("F"));
            };

            var stack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 10,
                Children = { list, button }

            };
            Content = stack;            

        }

    }

    public class Page1 : TabbedPage
    {
        public Page1()
        {
            this.Title = "Time List";
            Children.Add(new ListPage());

            Children.Add(new ContentPage
            {
                Title = "Tab 2",
                Padding = 10,
                Content = new Label
                {
                    Text = "Hello from Tab 2"
                }

            });

        }
    }
}
