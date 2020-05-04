using FinalRecipeApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalRecipeApp.Helpers
{
    public class RecipeRepository
    {
        private SQLiteAsyncConnection conn;
        public string StatusMessage { get; set; }

        public RecipeRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Recipe>().Wait();
        }

        public Task<int> AddNewRecipeTask(Recipe recipe)
        {

            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(recipe.Name))
                {
                    throw new Exception("Valid name required");
                }

                if (string.IsNullOrEmpty(recipe.Ingredients))
                {
                    throw new Exception("Valid ingredient required");
                }

                if (string.IsNullOrEmpty(recipe.Directions))
                {
                    throw new Exception("Valid direction required");
                }

                conn.InsertAsync(recipe);

                // StatusMessage = string.Format("{0} record(s) added )",  recipe);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", recipe, ex.Message);
            }

            return conn.InsertAsync(recipe);
        }

        public Task<int> IncomingUpdatedRecipeTask(Recipe recipe)
        {

            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(recipe.Name))
                {
                    throw new Exception("Valid name required");
                }

                if (string.IsNullOrEmpty(recipe.Ingredients))
                {
                    throw new Exception("Valid ingredient required");
                }

                if (string.IsNullOrEmpty(recipe.Directions))
                {
                    throw new Exception("Valid direction required");
                }

                conn.UpdateAsync(recipe);

                // StatusMessage = string.Format("{0} record(s) added )",  recipe);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", recipe, ex.Message);
            }

            return conn.UpdateAsync(recipe);
        }

        public async Task<List<Recipe>> GetAllRecipe()
        {
            try
            {
                //await conn.Table<Recipe>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return await conn.Table<Recipe>().ToListAsync();
        }

        //Strange, in the main Page, I try to bind the search to Recipe collection's Recipe but it does not work then I realized that it is separated from SQLite Table so I have to modify. SQLite is nasty piece of work.
        public async Task<List<Recipe>> SearchWithSQLiteTable(string queryString)
        {
            var normalizedQuery = queryString?.ToLower() ?? "";
            //return RecipeCollection.Recipes.Where(f => f.Name.ToLowerInvariant().Contains(normalizedQuery)).ToList();
            return await conn.Table<Recipe>().Where(f => f.Name.ToLower().Contains(normalizedQuery)).ToListAsync();

        }


        //After understanding how I can connect SQLite table to listview, I decided to add two more for sort because in main page, it won't work with RecipeCollection's Recipe property so I can modify it by following similar method as SearchWithSQLiteTable
        public async Task<List<Recipe>> AscendingWithSQLiteTable()
        {
            return await conn.Table<Recipe>().OrderBy(x => x.Name).ToListAsync();

        }

        public async Task<List<Recipe>> DescendingWithSQLiteTable()
        {
            return await conn.Table<Recipe>().OrderByDescending(x => x.Name).ToListAsync();

        }
    }
}
