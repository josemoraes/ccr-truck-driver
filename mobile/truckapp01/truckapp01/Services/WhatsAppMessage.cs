using System;
using Xamarin.Forms.OpenWhatsApp;

namespace truckapp01.Services
{
    public class WhatsAppMessage
    {
        public static async void WhatsappMessage(string number, string message)
        {
            try
            {
                Chat.Open(number, message);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
