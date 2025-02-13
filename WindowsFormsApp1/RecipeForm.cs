using System;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class RecipeForm : Form
    {
        public delegate void OnAddRecipe(Recipe recipe);
        public event OnAddRecipe AddRecipe;
        public RecipeForm()
        {
            InitializeComponent();
        }
        private void addIngredientsButton_Click(object sender, EventArgs e)
        {
            Recipe recipe = new Recipe()
            {
                Category = "Cat1",
                Description = "TODO", 
                Name = "Recipe name"
            };
            AddRecipe?.Invoke(recipe);
        }
    }
}
