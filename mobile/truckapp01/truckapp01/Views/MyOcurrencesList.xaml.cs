using System.Collections.Generic;
using System.Collections.ObjectModel;
using truckapp01.Models;
using Xamarin.Forms;

namespace truckapp01.Views
{
    public partial class MyOcurrencesList : ContentPage
    {
        public IList<Alert> AlertsList { get; set; }

        public MyOcurrencesList()
        {
            InitializeComponent();

            BindingContext = this;

            AlertsList = new ObservableCollection<Alert>();

            LoadPosts();
        }

        public void LoadPosts()
        {
            AlertsList.Add(new Alert
            {
                Icon = "alerta",
                Date = "12/06/2020",
                Title = "ACIDENTE"                
            });

            AlertsList.Add(new Alert
            {
                Icon = "alerta",
                Date = "12/06/2020",
                Title = "SAÚDE"
            });

            AlertsList.Add(new Alert
            {
                Icon = "alerta",
                Date = "13/06/2020",
                Title = "ROUBO"
            });
            AlertsList.Add(new Alert
            {
                Icon = "alerta",
                Date = "14/06/2020",
                Title = "PANE"
            });

            LstAlerts.ItemsSource = AlertsList;
        }
    }
}
