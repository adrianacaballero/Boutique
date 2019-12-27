namespace AppBoutique.ViewModels
{
    using AppBoutique.Models;
    using AppBoutique.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class BoutiqueViewModel : BaseViewModel
    {
        #region Attributes
        private ApiService apiService;
        private ObservableCollection<Boutique> boutiques;
        #endregion

        #region Properties
        public ObservableCollection<Boutique> Boutiques
        {
            get { return this.boutiques; }
            set { SetValue(ref this.boutiques, value); }
        }
        #endregion

        #region Constructor 
        public BoutiqueViewModel()
        {
            this.apiService = new ApiService();
            this.LoadBoutiques();
        }
        #endregion

        #region Methods
        private async void LoadBoutiques()
        {
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                "Internet Error Connection",
                connection.Message,
                "Accept");
                 return;
            }
            var response = await apiService.GetList<Boutique>(
            "http://localhost:50318/",
            "api/",
            "Boutiques");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
            "Boutique Service Error",
            response.Message,
            "Accept"
            );
            return;
            }

            MainViewModel main = MainViewModel.GetInstance();
            main.ListBoutique = (List<Boutique>)response.Result;

            this.Boutiques = new ObservableCollection<Boutique>( ToBoutiqueCollect() );

        }

        private IEnumerable<Boutique> ToBoutiqueCollect()
        {
            ObservableCollection<Boutique> collection = new ObservableCollection<Boutique>();
            MainViewModel main = MainViewModel.GetInstance();
            foreach(var lista in main.ListBoutique)
            {
                Boutique boutique = new Boutique();
                boutique.ClothesID = lista.ClothesID;
                boutique.Dress = lista.Dress;
                boutique.Pant = lista.Pant;
                boutique.Shirt = lista.Shirt;
                boutique.Accessory = lista.Accessory;
                collection.Add(boutique); 
            }
            return (collection);
        }
        #endregion
    }
}