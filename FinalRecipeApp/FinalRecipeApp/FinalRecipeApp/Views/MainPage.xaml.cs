using FinalRecipeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalRecipeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel mainPageViewModel;
        //public  MainPageViewModel mainPageViewModel = (MainPageViewModel)BindingContext;
        public MainPage(bool flag)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel = new MainPageViewModel();

            //RecipeCollectionSqlite();
            //mainPageViewModel.InitializeRecipeCollection();
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
            //RecipeListView.ItemSource = await App.RecipeRepo.GetAllRecipe();
            //BindingContext = mainPageViewModel;
            mainPageViewModel.InitializeRecipeCollection();
        }
    }
}