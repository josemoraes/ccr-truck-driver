using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Acr.UserDialogs;
using truckapp01.Interfaces;
using Xamarin.Forms;

namespace truckapp01.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void Salvar_Clicked(object sender, EventArgs e)
        {
            using (var Dialog = UserDialogs.Instance.Loading("Salvando seus dados ...", null, null, true, MaskType.Black))
            {
                await Task.Delay(1500);

                DependencyService.Get<IMessages>().LongAlert("Salvo com sucesso!");

                await Navigation.PopAsync();
            }
        }

        void MaskPhone(object sender, EventArgs e)
        {
            var ev = e as TextChangedEventArgs;

            var entry = (Entry)sender;

            string oldText = ev.NewTextValue.Replace("(","").Replace(")","").Replace(" ","").Replace("-", "");

            string text = Regex.Replace(oldText, @"(\d{2})(\d{5})(\d{4})", "($1) $2-$3");

            if (text.Length > 15)
            {
                text = text.Remove(15);
            }
            entry.Text = text;
        }

        void MaskCpf(object sender, EventArgs e)
        {
            var ev = e as TextChangedEventArgs;

            if (ev.NewTextValue != ev.OldTextValue && ev.NewTextValue != null)
            {
                var entry = (Entry)sender;
                string text = Regex.Replace(ev.NewTextValue, @"[^0-9]", "");

                text = text.PadRight(11);

                // removendo todos os digitos excedentes 
                if (text.Length > 11)
                {
                    text = text.Remove(11);
                }

                text = text.Insert(3, ".").Insert(7, ".").Insert(11, "-").TrimEnd(new char[] { ' ', '.', '-' });
                if (entry.Text != text)
                    entry.Text = text;

            }
        }
    }
}
