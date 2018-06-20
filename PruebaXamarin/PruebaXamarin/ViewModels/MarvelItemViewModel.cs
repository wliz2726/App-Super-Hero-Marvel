using GalaSoft.MvvmLight.Command;
using PruebaXamarin.Models;
using PruebaXamarin.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace PruebaXamarin.ViewModels
{
    public class MarvelItemViewModel: Result
    {
        #region Commands
        public ICommand SelectHeroCommand
        {
            get
            {
                return new RelayCommand(SelectHero);
            }
        }
        #endregion

        #region Methods
        private async void SelectHero()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.SuperHeroInfoPage = new SuperHeroInfoViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new SuperHeroInfoPage());
        }
        #endregion
    }
}
