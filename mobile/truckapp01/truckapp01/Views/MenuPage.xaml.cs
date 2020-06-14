using System;
using System.Collections.Generic;
using truckapp01.Models;
using Xamarin.Forms;

namespace truckapp01.Views
{
    public partial class MenuPage : MasterDetailPage
    {
        public List<MenuPageItems> menuList { get; set; }

        public MenuPage()
        {
            InitializeComponent();

            menuList = new List<MenuPageItems>();

            // incluindo items de menu e definindo : title ,page and icon
            menuList.Add(new MenuPageItems()
            {
                Title = "Home",
                Icon = "home.png",
                TargetType = typeof(HomePage)
            });
            menuList.Add(new MenuPageItems()
            {
                Title = "Avisos CCR (3)",
                Icon = "ccrlogobranca.png",
                TargetType = typeof(PostsPage)
            });
            menuList.Add(new MenuPageItems()
            {
                Title = "Meus Alertas (4)",
                Icon = "lista_alertas.png",
                TargetType = typeof(MyOcurrencesList)
            });
            menuList.Add(new MenuPageItems()
            {
                Title = "Minhas informações",
                Icon = "perfil.png",
                TargetType = typeof(RegisterPage)
            });
            menuList.Add(new MenuPageItems()
            {
                Title = "Sair",
                Icon = "sair.png",
                TargetType = null
            });
            // Configurando o ItemSource fpara o ListView na MainPage.xaml
            lstMenu.ItemsSource = menuList;

            // navegação inicial
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));
        }

        private void OnMenuItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            //Deselect Item
            ((ListView)sender).SelectedItem = null;

            var item = e.Item as MenuPageItems;

            Type page = item.TargetType;         

            if (page == null)
            {
                Navigation.InsertPageBefore(new LoginPage(), this);
                Navigation.RemovePage(this);
            }
            else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                IsPresented = false;
            }
        }
    }
}
