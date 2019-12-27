namespace AppBoutique.ViewModels
{
    using AppBoutique.Models;
    using System.Collections.Generic;

    public class MainViewModel
    {
        #region Properties
        public List<Boutique> ListBoutique { get; set; }
        #endregion

        #region ViewModels
        public BoutiqueViewModel boutiqueViewModel { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            boutiqueViewModel = new BoutiqueViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }
            return (instance);
        }
        #endregion

    }
}
