using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BiblApp
{
    public partial class RegPage : ContentPage
    {
        bool loaded = false;
        Label stackLabel;
        public RegPage()
        {
            InitializeComponent();
            stackLabel = new Label();
            Content = new StackLayout { Children = { stackLabel } };


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
        void rolePicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private async void OnButtonClicked(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            if (login.Text == null)
            {
                DisplayAlert("Неуспешно", "Введите логин", "Ок");
            }
            else if (email.Text == null)
            {
                DisplayAlert("Неуспешно", "Введите почту", "Ок");
            }
            else if (password.Text == null || confirmPassword == null)
            {
                DisplayAlert("Неуспешно", "Введите пароль", "Ок");
            }
            else if (password.Text != confirmPassword.Text)
            {
                DisplayAlert("Неуспешно", "Неправильно повторили пароль", "Ок");
            }
            else if (phone.Text == null)
            {
                DisplayAlert("Неуспешно", "Введите телефон", "Ок");
            }
            else if (role.SelectedItem == null)
            {
                DisplayAlert("Неуспешно", "Укажите роль", "Ок");
            }
            else
            {
                DisplayAlert("Успешно", "Вы зарегистрировались", "Ок");
               
                KabinetPage page = new KabinetPage();
                await Navigation.PushAsync(page);
                page.DisplayStack();

            }
        }
        

        private void Theme_OnButtonClicked(object sender, System.EventArgs e)
        {
            //int k = 0;
            //k++;
            if (BackgroundColor == Color.White)
            {
                BackgroundColor = Color.Black;
                regLabel.TextColor = Color.White;
                header.TextColor = Color.White;
                email.TextColor = Color.White;
                password.TextColor = Color.White;
                confirmPassword.TextColor = Color.White;
                phone.TextColor = Color.White;
                login.TextColor = Color.White;
                dateLable.TextColor = Color.White;
                role.TextColor = Color.White;
                datePic.TextColor = Color.White;
            }
            else 
            {
                BackgroundColor = Color.White;
                regLabel.TextColor = Color.Black;
                header.TextColor = Color.Black;
                email.TextColor = Color.Black;
                password.TextColor = Color.Black;
                confirmPassword.TextColor = Color.Black;
                phone.TextColor = Color.Black;
                login.TextColor = Color.Black;
                dateLable.TextColor = Color.Black;
                role.TextColor = Color.Black;
                datePic.TextColor = Color.Black;
            }



        }
        private void Exit_OnButtonClicked(object sender, System.EventArgs e)
        {
            Thread.CurrentThread.Abort();
        }

    }
}
