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
            InitializeComponent();        
            ButtonFavoritos.Clicked += ButtonFavoritos_Click;
            ButtonAgregar.Clicked += ButtonAgregar_Click;
            ButtonFav.Clicked += ButtonFav_Click;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            elemento = await CargarProductos(686);
            mostrarEspecie(); 
        }

        private void mostrarEspecie()
        {
            lbNombre.Text = elemento.Species.ScientificName;
            lbClassCommonName.Text = elemento.Species.ClassCommonName;
            lbAcceptedCommonName.Text = elemento.Species.AcceptedCommonName;
            lbKingdomName.Text = elemento.Species.KingdomName; 
        }
        private async void ButtonFavoritos_Click(object sender, EventArgs arg)
        {
            f.Items.Add(elemento);
            await Navigation.PushAsync(f);
        }
        private async void ButtonAgregar_Click(object sender, EventArgs arg)
        {
            elemento = null;
            while (elemento==null || elemento.Species == null)
            {
                elemento = await CargarProductos(rand.Next(1, 10000));
            }
            mostrarEspecie(); 
        }
        private async void ButtonFav_Click(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(f);
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
