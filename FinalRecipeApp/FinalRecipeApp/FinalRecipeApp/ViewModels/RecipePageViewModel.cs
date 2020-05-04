using FinalRecipeApp.Models;
using FinalRecipeApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FinalRecipeApp.ViewModels
{
    public class RecipePageViewModel : BaseViewModel
    {
        private Recipe recipe;
        public Recipe Recipe
        {
            get
            {
                return recipe;
            }
            set
            {
                recipe = value;
                OnPropertyChanged();
            }
        }


        public RecipePageViewModel(Recipe recipe)
        {
            Recipe = recipe;
        }



        // Edit Command
        private Command editCommand;

        public Command EditCommand => editCommand ?? (editCommand = new Command(Edit));

        async void Edit()
        {
            await App.Current.MainPage.Navigation.PushAsync(new EditRecipePage(recipe, false));
        }

        //   ((() => Application.Current.MainPage.Navigation.PushAsync(new RecipeEdit(Recipe))));


    }
}
