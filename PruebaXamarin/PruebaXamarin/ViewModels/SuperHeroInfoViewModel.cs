namespace PruebaXamarin.ViewModels
{
    using PruebaXamarin.Models;
    using PruebaXamarin.Sevices;

    public class SuperHeroInfoViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private Result heroInfo;
        private bool isRefreshing;
        //private ObservableCollection<Doc> articleObsCol;
        #endregion

        #region Properties
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public Result HerosIfo
        {
            get { return this.heroInfo; }
            set { SetValue(ref this.heroInfo, value); }
        }
        #endregion

        #region Constructor
        public SuperHeroInfoViewModel(Result herosInfo)
        {
            this.apiService = new ApiService();
            this.HerosIfo = herosInfo;
        }
        #endregion
    }
}