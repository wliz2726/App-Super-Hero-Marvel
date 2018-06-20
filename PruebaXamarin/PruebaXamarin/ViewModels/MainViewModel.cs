namespace PruebaXamarin.ViewModels
{
    class MainViewModel
    {
        #region ViewModels
        public MarvelViewModel MarvelPage { get; set; }
        public SuperHeroInfoViewModel SuperHeroInfoPage { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            this.MarvelPage = new MarvelViewModel();
        }
        #endregion

        //permite hacer un llamado de la MainViewModel desde cualquier
        //clase sin necesidad de tener que instanciar otra MainViewModel
        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
