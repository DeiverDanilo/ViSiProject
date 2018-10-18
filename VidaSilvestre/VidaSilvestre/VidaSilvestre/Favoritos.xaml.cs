using VidaSilvestre.Modelos;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VidaSilvestre
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Favoritos : ContentPage
    {
        public ObservableCollection<Elemento> Items = new ObservableCollection<Elemento>();

        public Favoritos()
        {
            InitializeComponent();
 
			MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            Elemento el = (Elemento)e.Item;
            await Navigation.PushAsync(new TabsPage(el));
            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            //((ListView)sender).SelectedItem = null;
        }
    }
}
