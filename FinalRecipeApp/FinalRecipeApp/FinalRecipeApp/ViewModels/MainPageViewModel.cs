using FinalRecipeApp.Models;
using FinalRecipeApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinalRecipeApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Recipe> recipes;
        public ObservableCollection<Recipe> Recipes
        {
            get
            {
                return recipes;
            }

            set
            {
                recipes = value;
                OnPropertyChanged();
            }
        }


        /* public MainPageViewModel()
         {
            // InitializeRecipeCollection();
         }*/

        public async void InitializeRecipeCollection()
        {
            Recipes = new ObservableCollection<Recipe>(await App.RecipeRepo.GetAllRecipe());
        }

        private Command addCommand;
        public Command AddCommand => addCommand ?? (addCommand = new Command(Add));

        async void Add()
        {
            Recipe recipe = null;


            await App.Current.MainPage.Navigation.PushAsync(new EditRecipePage(recipe, true));
        }

        private Recipe selectedItemAsRecipe;

        public Recipe SelectedItemAsRecipe
        {
            get
            {
                return selectedItemAsRecipe;
            }
            set
            {
                selectedItemAsRecipe = value;
                if (selectedItemAsRecipe != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new RecipePage(selectedItemAsRecipe));

                }
            }
        }


        private string searchBarText;

        public string SearchBarText
        {
            get
            {
                return searchBarText;
            }
            set
            {
                searchBarText = value;
            }
        }


        private Command searchCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public Command SearchCommand => searchCommand ?? (searchCommand = new Command(Search));

        private async static Task<List<Recipe>> GetSearchResults(string queryString)
        {

            return await App.RecipeRepo.SearchWithSQLiteTable(queryString);


        }

        async void Search()
        {
            await GetSearchResults(searchBarText);
        }
    }
}
