using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Acr.UserDialogs;
using truckapp01.Interfaces;
using truckapp01.Models;
using Xamarin.Forms;

namespace truckapp01.Views
{
    public partial class HomePage : ContentPage
    {
        public IList<MenuAlertButtons> MenuList { get; set; }

        public HomePage()
        {
            InitializeComponent();

            BindingContext = this;
            
            LoadMenu();
        }

        public void LoadMenu()
        {
            MenuList = new ObservableCollection<MenuAlertButtons>();

            MenuList.Add(new MenuAlertButtons
            {
                FigureIcon          = "saude",
                Title               = "SAÚDE",
                FigureSeta          = "seta",
                BackgroundColorMenu = "#E36764",
                AlertCode           = 1
            });

            MenuList.Add(new MenuAlertButtons
            {
                FigureIcon          = "ladrao",
                Title               = "ROUBO",
                FigureSeta          = "seta",
                BackgroundColorMenu = "#B84B55",
                AlertCode           = 2
            });

            MenuList.Add(new MenuAlertButtons
            {
                FigureIcon          = "acidente",
                Title               = "ACIDENTE",
                FigureSeta          = "seta",
                BackgroundColorMenu = "#4B365D",
                AlertCode           = 3
            });

            MenuList.Add(new MenuAlertButtons
            {
                FigureIcon          = "pane",
                Title               = "PANE MECÂNICA/ELÉTRICA",
                FigureSeta          = "seta",
                BackgroundColorMenu = "#725193",
                AlertCode           = 4
            });

            MenuList.Add(new MenuAlertButtons
            {
                FigureIcon          = "assedio",
                Title               = "ASSÉDIO (CAMINHONEIRA)",
                FigureSeta          = "seta",
                BackgroundColorMenu = "#61CCF9",
                AlertCode           = 5
            });

            LstMenuAlertas.ItemsSource = MenuList;
        }

        public async void SendOcurrence_Clicked(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            //Deselect Item
            ((ListView)sender).SelectedItem = null;

            var alerta_selecionado = e.Item as MenuAlertButtons;

            if (await DisplayAlert("Atenção!", $"Enviar um alerta de:\n'{alerta_selecionado.Title.ToUpper()}' ?", "Enviar", "Cancelar") == true)
            {
                using (var Dialog = UserDialogs.Instance.Loading("Enviando alerta ...", null, null, true, MaskType.Black))
                {
                    await Task.Delay(1500);
                    //SendOcurrenceAsync();

                    DependencyService.Get<IMessages>().LongAlert("Alerta enviado com sucesso!");

                    await Navigation.PushAsync(new SupportPointsPage(alerta_selecionado.AlertCode), true);
                }
            }
        }

        public void SendOcurrenceAsync()
        {
            DependencyService.Get<ISendSms>().SendSms("43998026660", "Teste SMS TruckApp diretooo!!!");
        }
    }
}
