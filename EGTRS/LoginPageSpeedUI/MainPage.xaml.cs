using LoginPageSpeedUI.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginPageSpeedUI
{

    public partial class MainPage : ContentPage
    {        

        private SqlConnection sqlConnection;

        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }

     
        public MainPage()
        {
            InitializeComponent();

            sqlConnection = new SqlConnection(ConnectionSettings.SqlConnectionString);

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string queryString = "SELECT 1 FROM dbo.giris WHERE Sicil_No = @Sicil_No AND Sifre = @Sifre";
            using (SqlCommand command = new SqlCommand(queryString, sqlConnection))
            {
                command.Parameters.AddWithValue("@Sicil_No", txtsno.Text);
                command.Parameters.AddWithValue("@Sifre", txtsifre.Text);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        await App.Current.MainPage.Navigation.PushAsync(new MyPage());
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Hata", "Sicil Numarası veya Şifre yanlış!", "Tekrar Dene");
                    }
                }
            }
            sqlConnection.Close();
            return;

        }
    }    
}

