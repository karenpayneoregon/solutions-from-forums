#pragma warning disable CS8618
using CreateDynamicTextBoxes.Classes;

namespace CreateDynamicTextBoxes;

public partial class Form1 : Form
{
    private readonly string _fileName = "savedWorkout.txt";
    public Form1()
    {
        InitializeComponent();
        panel1.AutoScroll = true;
    }

    private void RunSampleButton_Click(object sender, EventArgs e)
    {
        var lines = File.ReadAllLines(_fileName);

        TextBoxOperations.BaseName = "LineTextBox";

        TextBoxOperations.Initialize(panel1, 20, 30, 10, 400);
        TextBoxOperations.Build(lines);

    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        TextBoxOperations.Save(_fileName);
    }
}