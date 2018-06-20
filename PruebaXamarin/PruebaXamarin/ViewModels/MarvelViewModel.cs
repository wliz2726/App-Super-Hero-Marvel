namespace PruebaXamarin.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using PruebaXamarin.Models;
    using Sevices;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    class MarvelViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private Marvel marvel;
        private ObservableCollection<MarvelItemViewModel> superHero;
        private string hero;
        private string img;
        private bool isRefreshing;
        #endregion

        #region Properties
        public string Hero
        {
            get { return this.hero; }
            set {SetValue(ref this.hero, value);}
        }

        public string Img
        {
            get { return this.img; }
            set { SetValue(ref this.img, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public ObservableCollection<MarvelItemViewModel> SuperHero
        {
            get { return this.superHero; }
            set { SetValue(ref this.superHero, value); }
        }
        #endregion

        #region Constructor
        public MarvelViewModel()
        {
            this.apiService = new ApiService();
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }
        #endregion

        #region Methods
        private async void Search()
        {
            this.IsRefreshing = true;

            if (string.IsNullOrEmpty(this.Hero))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", // Titulo del Error
                    "You must enter some Text", // Mensage
                    "Accept"); // Nombre del botón
                return;
            }

            var connection = await this.apiService.CheckConnection();
            // si no hay coneccion
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false; // desactiva la carga del listView

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                return;
            }

            //para cargar las lands hay que instanciar el servicio
            var response = await this.apiService.Get<Marvel>(
                "http://gateway.marvel.com",
                Hero);

            // si dio algun error
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false; // desactiva la carga del listView
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");

                return;
            }

            this.marvel = (Marvel)response.Result;

            //Si no encuentra al super heroe
            if (marvel.Data.Results.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", // Titulo del Error
                    "Super Hero Was not Found", // Mensage
                    "Accept"); // Nombre del botón

                this.IsRefreshing = false;
                Hero = "";

                //esto hace que vuelva hacia la pestaña anterior
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            this.SuperHero = new ObservableCollection<MarvelItemViewModel>(
            this.ToSuperHeroItemViewModel());

            
           this.Img = String.Format("{0}.{1}", marvel.Data.Results[0].Thumbnail.Path, marvel.Data.Results[0].Thumbnail.Extension);

            this.IsRefreshing = false;
        }

        private IEnumerable<MarvelItemViewModel> ToSuperHeroItemViewModel()
        {
            return this.marvel.Data.Results.Select(m => new MarvelItemViewModel
            {
                Description = m.Description,
                Id = m.Id,
                Modified = m.Modified,
                Name = m.Name,
                Thumbnail = m.Thumbnail,
                //ResourceUri = m.ResourceUri
            });
        }
        #endregion
    }
}
