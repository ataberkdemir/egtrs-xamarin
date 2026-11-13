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
    public partial class AyrintiliGoruntule : ContentPage
    {
        public class MyTableList
        {
            public string Top_Bolum { get; set; }

            public string Top_Olusturan { get; set; }

            public string Top_Konusu { get; set; }

            public string Oda_Adi { get; set; }
        }

        SqlConnection sqlConnection;

        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }

        public AyrintiliGoruntule()
        {
            InitializeComponent();

            sqlConnection = new SqlConnection(ConnectionSettings.SqlConnectionString);
        }
                   

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.Open();
                List<MyTableList> myTableLists = new List<MyTableList>();
                //sqlConnection.Open();
                string queryString = "Select * from dbo.goruntule where Top_Id = 1";
                SqlCommand command = new SqlCommand(queryString, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    myTableLists.Add(new MyTableList
                    {
                        Top_Bolum = reader["Top_Bolum"].ToString(),
                        Top_Olusturan = reader["Top_Olusturan"].ToString(),
                        Top_Konusu = reader["Top_Konusu"].ToString(),
                        Oda_Adi = reader["Oda_Adi"].ToString(),
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
        }
    }    
}