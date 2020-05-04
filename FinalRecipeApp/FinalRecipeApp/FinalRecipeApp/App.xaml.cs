using FinalRecipeApp.Helpers;
using FinalRecipeApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//Harsh Mathur
//Homework 5
//5-3-2020
namespace FinalRecipeApp
{
    public partial class App : Application
    {

        public static RecipeRepository RecipeRepo { get; private set; }
        public App(string dbPath)
        {
            InitializeComponent();

            RecipeRepo = new RecipeRepository(dbPath);
            //To populate Data
            //RecipeCollection.PopulateData();
            //List<Recipe>.ToObservableCollection();
            var navPage = new NavigationPage(new MainPage(true));

            navPage.BarBackgroundColor = Color.Black;

            navPage.BarTextColor = Color.White;


            MainPage = navPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
