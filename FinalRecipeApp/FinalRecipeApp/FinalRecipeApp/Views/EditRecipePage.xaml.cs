using FinalRecipeApp.Models;
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
    public partial class EditRecipePage : ContentPage
    {
        //private EditRecipePageViewModel editRecipePage => (EditRecipePageViewModel)BindingContext;
        public EditRecipePage(Recipe recipe, bool flag)
        {
            InitializeComponent();

            BindingContext = recipe;
            CancelButton.Clicked += CancelButton_Clicked;


            SaveButton.Clicked += async (s, e) =>
            {


                if (flag == true)
                {
                    Recipe recipe1 = new Recipe(RecipeNameEntry.Text, RecipeIngredientEntry.Text, RecipeDirectionEntry.Text);
                    //var newGroup =  CategoriesCollection.LongName{ CategoriesEntry.Text};
                    // CategoriesCollection.GroupedRecipes.Add(recipe1);
                    await App.RecipeRepo.AddNewRecipeTask(recipe1);
                    //RecipeCollection.Recipes.Add(recipe1);
                    //App.RecipeRepo.AddNewRecipeTask(RecipeNameEntry.Text, RecipeIngredientEntry.Text, RecipeDirectionEntry.Text);
                }
                //App.RecipeRepo.AddNewRecipeTask(RecipeNameEntry.Text, RecipeIngredientEntry.Text, RecipeDirectionEntry.Text);

                await App.RecipeRepo.IncomingUpdatedRecipeTask(recipe);
                await Navigation.PushAsync(new MainPage(false));
            };
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}