using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FinalRecipeApp.Models
{
    [Table("NewTableRecipeStuff")]
    public class Recipe : INotifyPropertyChanged
    {
        private string name;

        private string ingredients;

        private string directions;



        public event PropertyChangedEventHandler PropertyChanged;

        public Recipe()
        {

        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }


        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;

                    RaisePropertyChanged();
                }
            }
        }


        public string Ingredients
        {
            get { return ingredients; }
            set
            {
                if (ingredients != value)
                {
                    ingredients = value;

                    RaisePropertyChanged();
                }
            }
        }


        public string Directions
        {
            get { return directions; }
            set
            {
                if (directions != value)
                {
                    directions = value;

                    RaisePropertyChanged();
                }
            }
        }

        //[MaxLength(250), Unique]
        /*public string Categories
        {
            get { return categories; }
            set
            {
                if (categories != value)
                {
                    categories = value;

                    RaisePropertyChanged();
                }
            }
        }*/

        public Recipe(string _name, string _ingredients, string _directions)
        {
            Name = _name;
            Ingredients = _ingredients;
            Directions = _directions;
            // Categories = _categories;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
