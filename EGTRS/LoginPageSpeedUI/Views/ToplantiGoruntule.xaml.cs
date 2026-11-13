
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginPageSpeedUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToplantiGoruntule : ContentPage
    {

        public class MyTableList
        {
            public string Top_Bolum { get; set; }

            public string Top_Olusturan { get; set; }

            public string Top_Konusu { get; set; }
        }


        SqlConnection sqlConnection;

        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }

        public ToplantiGoruntule()
        {
            InitializeComponent();

            sqlConnection = new SqlConnection(ConnectionSettings.SqlConnectionString);


        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.Open();
                await App.Current.MainPage.DisplayAlert("Tebrikler", "Bağlantı Sağlandı", "Tamam");
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(value: ex.Message);

                throw;
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.Open();
                List<MyTableList> myTableLists = new List<MyTableList>();
                //sqlConnection.Open();
                string queryString = "Select * from dbo.goruntule";
                SqlCommand command = new SqlCommand(queryString, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    myTableLists.Add(new MyTableList
                    {
                        Top_Bolum = reader["Top_Bolum"].ToString(),
                        Top_Olusturan = reader["Top_Olusturan"].ToString(),
                        Top_Konusu = reader["Top_Konusu"].ToString(),
                    }
                    );


                }
                MyListView.ItemsSource = myTableLists;

                reader.Close();
                sqlConnection.Close();



            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
                throw;
            }

            //List<MyTableList> myTableLists = new List<MyTableList>();
            //sqlConnection.Open();
            //string queryString = "Select * from dbo.goruntule";
            //SqlCommand command = new SqlCommand(queryString, sqlConnection);
            //SqlDataReader reader = command.ExecuteReader();

            //while(reader.Read())
            //{

            //    myTableLists.Add(new MyTableList
            //    {
            //        Top_Bolum = (reader["Top_Bolum"]).ToString(),
            //        Top_Olusturan = reader["Top_Olusturan"].ToString(),
            //        Top_Konusu = reader["Top_Konusu"].ToString(),

            //    }
            //    );

            //    reader.Close();
            //    sqlConnection.Close();

            //}

            //MyListView.ItemsSource = myTableLists; 

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            await frame.ScaleTo(1.1, 100);
            await frame.ScaleTo(1, 100);
            Navigation.PushAsync(new AyrintiliGoruntule());

        }
    }
}

    
