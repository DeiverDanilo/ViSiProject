using VidaSilvestre.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VidaSilvestre
{
    public partial class MainPage
    {
        public Elemento elemento { get; set; }
        Random rand = new Random();
        public Command AgregarComando { get; set; }
        public Command AbrirComando { get; set; }
        public Favoritos f = new Favoritos();

        public MainPage()
        {
            AgregarComando = new Command(async () => await CargarItems());

            //AbrirComando = new Command(async () => await Navigation.PushAsync(f(elemento));

            InitializeComponent();        
            ButtonFavoritos.Clicked += ButtonFavoritos_Click;
            ButtonAgregar.Clicked += ButtonAgregar_Click;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            elemento = await CargarProductos(686);
            mostrarEspecie();
            //await CargarItems();
        }

        private void mostrarEspecie()
        {
            lbNombre.Text = elemento.Species.ScientificName;
            lbClassCommonName.Text = elemento.Species.ClassCommonName;
            lbAcceptedCommonName.Text = elemento.Species.AcceptedCommonName;
            lbKingdomName.Text = elemento.Species.KingdomName;
            //lbKingdomCommonName.Text = elemento.Species.KingdomCommonName;
            //lbClassName.Text = elemento.Species.ClassName;
            //lbFamilyName.Text = elemento.Species.FamilyName;
            //lbFamilyCommonName.Text = elemento.Species.FamilyCommonName;       
            //lbFamilyRank.Text = elemento.Species.FamilyRank;
            //lbIsSuperseded.Text = elemento.Species.IsSuperseded;
        }
        private async void ButtonFavoritos_Click(object sender, EventArgs arg)
        {
            f.Items.Add(elemento);
            await Navigation.PushAsync(f);
        }
        private async void ButtonAgregar_Click(object sender, EventArgs arg)
        {
            elemento = await CargarProductos(rand.Next(1, 10000));
            mostrarEspecie();
            // await CargarItems();
        }

        private async Task CargarItems()
        {
            //if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            //{
            //    await DisplayAlert("Advertencia", "No hay internet", "Cerrar");
            //    return;
            //}
            //IsBusy = true;

            //await Task.Delay(2500);

            //Items.Add($"Elemento #{Items.Count}");

        
            IsBusy = false;

            //await DisplayAlert("Titulo", "Hola!", "Cerrar");
        }

        private async Task<Elemento> CargarProductos(int ob)
        {
            try
            {
                var cliente = new HttpClient();

                cliente.BaseAddress = new Uri(App.WebServiceUrl);
                //var json = await cliente.GetStringAsync("api/products");
                var json = await cliente.GetStringAsync("species/?op=getspeciesbyid&taxonid=" +ob);// 686
                json = "[" + json + "]";
                Console.WriteLine(json);

                var resultado = JsonConvert.DeserializeObject<Elemento[]>(json);

                return resultado[0];

            }
            catch (Exception ex)
            {
                // Log 
                return new Elemento();
            }
        }
    }
}
