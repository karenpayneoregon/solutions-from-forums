using System.ComponentModel;
using DynamicButtonsApp.Classes;
using DynamicButtonsApp.Classes.Containers;
using DynamicButtonsApp.Classes.Controls;
using DynamicButtonsApp.Properties;

namespace DynamicButtonsApp;

public partial class Form1 : Form
{
    private BindingList<Product> _productsBindingList;
    private readonly BindingSource _productBindingSource = new ();
    public Form1()
    {
        InitializeComponent();

        Operations.BaseName = "CategoryButton";

        Operations.Initialize(this, 20, 35, 10, 150, CategoryButtonClick);

        ProductsListBox.DoubleClick += ProductsListBoxOnDoubleClick;

        Operations.BuildButtons();
    }
    private void ProductsListBoxOnDoubleClick(object sender, EventArgs e)
    {
        if (_productBindingSource.Current is null)
        {
            return;
        }

        var product = (Product)_productBindingSource.Current;

        MessageBox.Show($"{product.Id}, {product.Name}");
    }

    private void CategoryButtonClick(object sender, EventArgs e)
    {
        Operations.ButtonsList.ForEach(dataButton => dataButton.Image = null);

        var button = (DataButton)sender;

        button.Image = Resources.rightarrow_16x;

        _productsBindingList = new BindingList<Product>(DataOperations.ReadProducts(button.Identifier));
        _productBindingSource.DataSource = _productsBindingList;
        ProductsListBox.DataSource = _productBindingSource;

    }
}
