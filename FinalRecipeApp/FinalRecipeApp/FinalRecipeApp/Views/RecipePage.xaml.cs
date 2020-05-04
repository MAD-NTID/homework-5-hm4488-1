using FinalRecipeApp.Models;
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
    public partial class RecipePage : ContentPage
    {
        private Recipe Recipe;
        //private RecipePageViewModel recipePageViewModel = (RecipePageViewModel)BindingContext();
        public RecipePage(Recipe recipe)
        {
            Recipe = recipe;
            InitializeComponent();

            /*BindingContext = recipe;
            EditButtonToolbarItem.Clicked += async (s, e) =>
            {
                await Navigation.PushAsync(new EditRecipePage(recipe, false));
            };*/

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //BindingContext = recipeViewModel;
            BindingContext = new RecipePageViewModel(Recipe);
        }
    }
}