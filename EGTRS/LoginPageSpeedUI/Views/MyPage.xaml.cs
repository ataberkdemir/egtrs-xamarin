using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginPageSpeedUI.Views

{
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();

        }

        async void OnFrameTapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            await frame.ScaleTo(1.1, 100);
            await frame.ScaleTo(1, 100);
            Navigation.PushAsync(new ToplantiOlusturmaSayfası());
        }

        async void OnFrameTapped2(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            await frame.ScaleTo(1.1, 100);
            await frame.ScaleTo(1, 100);
            Navigation.PushAsync(new ToplantiGoruntule());
        }

        async void OnFrameTapped3(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            await frame.ScaleTo(1.1, 100);
            await frame.ScaleTo(1, 100);
            await Navigation.PushAsync(new ToplantiDuzenle());
        }
    }
}
   

