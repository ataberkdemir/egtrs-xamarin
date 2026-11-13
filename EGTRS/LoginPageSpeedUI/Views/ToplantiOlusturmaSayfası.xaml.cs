using Android.Content.Res;
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
    public partial class ToplantiOlusturmaSayfası : ContentPage

    {
        public class MyTableList
        {
            public string Top_Bolum { get; set; }

            public string Top_Olusturan { get; set; }

            public string Top_Konusu { get; set; }
        }

        SqlConnection sqlConnection;

        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }

        public ToplantiOlusturmaSayfası()            

        {
            InitializeComponent();

            sqlConnection = new SqlConnection(ConnectionSettings.SqlConnectionString);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyPage());
        }

        private async void setButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.goruntule VALUES(@Top_Olusturan, @Top_Konusu, @Top_Bolum, @Oda_Adi)",sqlConnection))
                {
                    command.Parameters.Add(new SqlParameter("Top_Olusturan", ToplantiOlusturan.Text));
                    command.Parameters.Add(new SqlParameter("Top_Konusu", ToplantiKonusu.Text));
                    command.Parameters.Add(new SqlParameter("Top_Bolum", ToplantiBolumu.Text));
                    command.Parameters.Add(new SqlParameter("Oda_Adi", TopOda.Text));
                    //command.Parameters.Add(new SqlParameter("Top_Odasi", ToplantininYapilacagiYer.Text));
                    //command.Parameters.Add(new SqlParameter("Top_Tarihi", ToplantiGunu.Text));
                    //command.Parameters.Add(new SqlParameter("Top_Katilacaklar", KimlerKatilacak.Text));
                    //command.Parameters.Add(new SqlParameter("Top_Bas_Saati", ToplantiBaslangicSaati.Text));
                    //command.Parameters.Add(new SqlParameter("Top_Bitis_Saati", ToplantiBitisSaati.Text));
                    command.ExecuteNonQuery();

                }
                sqlConnection.Close(); 
                await App.Current.MainPage.DisplayAlert("Tebrikler", "Bir Toplantı Oluşturdunuz" , "Tamam");

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
                throw;
            }
        }
    }
}