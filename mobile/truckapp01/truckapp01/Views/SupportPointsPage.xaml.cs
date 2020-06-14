using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Newtonsoft.Json;
using truckapp01.ApiMobile;
using truckapp01.Interfaces;
using truckapp01.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace truckapp01.Views
{
    public partial class SupportPointsPage : ContentPage
    {
        double _mylatitude = 0, _mylongitude = 0, _pinLatitude = 0, _pinLongitude = 0;
        string _phone      = string.Empty;
        int _alertCode     = 0;

        public IList<SupportPoint> SupportPointsList { get; set; }       

        public SupportPointsPage(int alertCode)
        {
            InitializeComponent();

            _alertCode = alertCode;

            Mapa.UiSettings.MapToolbarEnabled = true;
            Mapa.UiSettings.MyLocationButtonEnabled = true;
            Mapa.UiSettings.ZoomControlsEnabled = true;

            SupportPointsList = new ObservableCollection<SupportPoint>();
            GetCurrentLocation();

            Mapa.InfoWindowClicked += (sender, args) =>
            {
                var dados = SupportPointsList.First(c => c.Id == args.Pin.Tag.ToString());

                lblName.Text        = dados.Name;
                lblAdress.Text      = $"{dados.Address} \n\nLocalização: {dados.Latitude} {dados.Longitude}";

                BackgroundPopupInformacoes.IsVisible = true;
                PopupInformacoes.IsVisible           = true;
            };
        }

        public async void GetCurrentLocation()
        {
            using (var Dialog = UserDialogs.Instance.Loading("Carregando Pontos de Apoio ...", null, null, true, MaskType.Black))
            {
                await Task.Delay(1500);

                var position = await Geolocation.GetLastKnownLocationAsync();

                if (position == null)
                {
                    await DisplayAlert("Atenção", "null gps :(", "OK");
                    return;
                }

                _mylatitude = position.Latitude;
                _mylongitude = position.Longitude;

                LoadSupportPoints();
            }
        }

        public void LoadSupportPoints()
        {
            SupportPointsList.Clear();
            Mapa.Pins.Clear();
            var myPos = new Position(_mylatitude, _mylongitude);
                        
            var json   = Api.GetJsonData("support_points");
            var result = JsonConvert.DeserializeObject<List<SupportPoint>>(json);

            foreach (var item in result)
            {
                if (item.AlertCodesThatAttends.Contains(_alertCode))
                {
                    SupportPointsList.Add(new SupportPoint
                    {
                        Id = item.Id,
                        Logo = item.Logo,
                        Name = item.Name,
                        Address = item.Address,
                        Phone = item.Phone,
                        Latitude = item.Latitude,
                        Longitude = item.Longitude,
                        AlertCodesThatAttends = item.AlertCodesThatAttends
                    });

                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(double.Parse(item.Latitude), double.Parse(item.Longitude)),
                        Label = "CLIQUE AQUI",
                        Address = item.Name,
                        Tag = item.Id
                        //Icon     = BitmapDescriptorFactory.DefaultMarker(Color.FromHex("#4086F4")),
                        //Icon     = BitmapDescriptorFactory.FromBundle("localizacao"),

                    };

                    Mapa.Pins.Add(pin);
                }
            }          
           
            Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(myPos, Distance.FromMeters(1500)), true);
        }        

        public void ClosePopUpInformacoes_Clicked(object sender, EventArgs e)
        {
            Close();
        }

        public async void GetSupport_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Atenção!", $"Confirma a solicitação deste Ponto de Apoio?", "Confirmar!", "Cancelar") == true)
            {
                using (var Dialog = UserDialogs.Instance.Loading("Solicitando apoio ...", null, null, true, MaskType.Black))
                {
                    await Task.Delay(1500);

                    DependencyService.Get<IMessages>().LongAlert("Ponto de Apoio solicitado com sucesso!");

                    await Navigation.PopAsync();
                }
            }
        }

        public void PhoneCall_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IPhoneCall>().PhoneCall(_phone);
        }

        public void Close()
        {
            BackgroundPopupInformacoes.IsVisible = false;
            PopupInformacoes.IsVisible = false;
        }
    }
}
