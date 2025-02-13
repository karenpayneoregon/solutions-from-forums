using System;
using System.Windows.Forms;
// location of Recipe class
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private Recipe _currentRecipe;
        public MainForm()
        {
            InitializeComponent();
        }
        private void openChildForm_Click(object sender, EventArgs e)
        {

            RecipeForm recipeForm = new RecipeForm();
            recipeForm.AddRecipe += RecipeForm_AddRecipe;

            try
            {
                MessageBox.Show(recipeForm.ShowDialog() == DialogResult.OK
                    ? $"{_currentRecipe.Category}"
                    : "Nothing added");
            }
            finally
            {
                recipeForm.Dispose();
            }
        }
        private void RecipeForm_AddRecipe(Recipe recipe)
        {
            _currentRecipe = recipe;
        }
    }
}
