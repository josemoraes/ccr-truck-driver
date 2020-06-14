using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace truckapp01.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void Login_Clicked(object sender, EventArgs e)
        {
            if (txtCpf.Text == null)
                txtCpf.ErrorText = "Obrigatório";
            else
                txtCpf.ErrorText = null;

            if (txtPassword.Text == null)
                txtPassword.ErrorText = "Obrigatório";
            else
                txtPassword.ErrorText = null;

            if (txtPassword.Text != null && txtPassword.Text != null)
            {
                if (Util.Validacoes.ValidateCPF(txtCpf.Text))
                {
                    using (var Dialog = UserDialogs.Instance.Loading("Autenticando ...", null, null, true, MaskType.Black))
                    {
                        await Task.Delay(1500);
                        txtCpf.ErrorText = null;
                        Navigation.InsertPageBefore(new MenuPage(), this);
                        await Navigation.PopAsync();
                    }
                }
                else
                    txtCpf.ErrorText = "CPF inválido!";
            }
        }

        public void ShowPass(object sender, EventArgs args)
        {
            txtPassword.IsPassword = txtPassword.IsPassword ? false : true;
            imgEye.Opacity = txtPassword.IsPassword == true ? 1.0 : 0.5;
        }

        async void ResetPassword_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResetPassword(), true);
        }

        async void Register_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(), true);
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
