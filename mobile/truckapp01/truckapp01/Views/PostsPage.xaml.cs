using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using truckapp01.Models;
using Xamarin.Forms;

namespace truckapp01.Views
{
    public partial class PostsPage : ContentPage
    {
        public IList<PostMessage> PostsList { get; set; }

        public PostsPage()
        {
            InitializeComponent();

            BindingContext = this;

            PostsList = new ObservableCollection<PostMessage>();

            LoadPosts();
        }

        public void LoadPosts()
        {
            PostsList.Add(new PostMessage
            {
                Icon  = "ccrlogopequena",
                PostDate = "27/03/2020",
                Title = "CCR distribui kits de alimentação para caminhoneiros",
                Url   = "http://www.grupoccr.com.br/assets/grupoccr/files/misc/20200330091031614-200326_kit_alimenta%C3%A7%C3%A3o.pdf"
            });

            PostsList.Add(new PostMessage
            {
                Icon = "ccrlogopequena",
                PostDate = "11/03/2020",
                Title = "Grupo CCR repassa R$ 367 mi de ISS para 180 cidades em 2019",
                Url = "http://www.grupoccr.com.br/assets/grupoccr/files/misc/20200325111627258-20200311_repasse_iss.pdf"
            });

            PostsList.Add(new PostMessage
            {
                Icon = "ccrlogopequena",
                PostDate = "13/06/2020",
                Title = "Lembrete, exame médico agendado para o dia 21/06/2020",
                Url = "http://www.grupoccr.com.br/"
            });

            LstPosts.ItemsSource = PostsList;
        }
    }
}
