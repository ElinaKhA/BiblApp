using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiblApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KabinetPage : ContentPage
    {
        Label stackLabel;
        public KabinetPage()
        {
            Title = "Page 2";
            Button booksBtn = new Button { Text = "К списку книг" };
            booksBtn.Clicked += GoToForward;

            Button regBtn = new Button { Text = "Назад" };
            regBtn.Clicked += GoToBack;

            stackLabel = new Label();
            Content = new StackLayout { Children = { booksBtn, regBtn, stackLabel } };
        }
        protected internal void DisplayStack()
        {
            NavigationPage navPage = (NavigationPage)App.Current.MainPage;
            stackLabel.Text = "";
            foreach (Page p in navPage.Navigation.NavigationStack)
            {
                stackLabel.Text += p.Title + "\n";
            }
        }
        // Переход вперед на Page3
        private async void GoToForward(object sender, EventArgs e)
        {
            BooksPage page = new BooksPage();
            await Navigation.PushAsync(page);
            page.DisplayStack();
        }
        // Переход обратно на MainPage
        private async void GoToBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

            NavigationPage navPage = (NavigationPage)App.Current.MainPage;
            ((RegPage)navPage.CurrentPage).DisplayStack();
        }

    }
}