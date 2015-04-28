using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App8
{
    public class App : Application
    {
        public App()
        {
            var page = new ContentPage
            {
            };

            var navigationPage = new NavigationPage(page);
            var command = new Command(AddContact);
            var list = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Label {
                        XAlign = TextAlignment.Center,
                        Text = "Welcome to Xamarin Forms!"  + GetNames()
                    },
                    new Button()
                    {
                        Text = "Click me!",
                        Command = command,
                        CommandParameter = navigationPage
                    }
                }
            };

            page.Content = list;

          
            MainPage = navigationPage;
     
        }

        private string GetNames()
        {
            var buffer = new StringBuilder();
            foreach (var name in Global.Doer.GetAllNames())
            {
                buffer.AppendLine(name);
            }

            return buffer.ToString();
        }

        private void AddContact(object obj)
        {
            Global.Doer.ShowContact((NavigationPage)obj);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

    public static class Global
    {
        public static IDo Doer { get; set; }
    }

    public interface IDo
    {
        void ShowContact(NavigationPage page);
        IList<string> GetAllNames();
    }
}
