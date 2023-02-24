using WorkingWithSqlServerImages.Classes;

namespace WorkingWithSqlServerImages;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void TruncateButton_Click(object sender, EventArgs e)
    {
        pictureBox1.Image = null;
        ClientPhotoOperations.TruncateTable();
    }

    private void InsertClientButton_Click(object sender, EventArgs e)
    {
        ClientPhotoOperations.InsertImage(File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Images", "bag.png")));
    }

    private void ReadClientButton_Click(object sender, EventArgs e)
    {
        var (container, success) = ClientPhotoOperations.ReadImage(1);
        if (success)
        {
            pictureBox1.Image = container.Picture;
        }
        else
        {
            pictureBox1.Image = null;
            MessageBox.Show("No record");
        }
        
    }

    private void InsertDapperButton_Click(object sender, EventArgs e)
    {
        DapperPhotoOperations.InsertImage(File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "bag.png")));
    }

    private void ReadDapperButton_Click(object sender, EventArgs e)
    {
        var (container, success) = DapperPhotoOperations.ReadImage(1);
        if (success)
        {
            pictureBox1.Image = container.Picture;
        }
        else
        {
            pictureBox1.Image = null;
            MessageBox.Show("No record");
        }
    }
}
