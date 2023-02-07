using DisableScreenSaverCore.Classes;
using System.Diagnostics;

namespace DisableScreenSaverCore;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void StartButton_Click(object sender, EventArgs e)
    {
        StartTimeLabel.Text = DateTime.Now.ToString("HH:m:s");
        TimerHelper.Interval = 1000 * 60;
        TimerHelper.Triggered += Triggered;
        TimerHelper.Start(Operations.Execute);

    }

    private void Triggered(string time)
    {
        TimeListBox.InvokeIfRequired(lb =>
        {
            lb.Items.Add(time);
            lb.SelectedIndex = lb.Items.Count - 1;
        });
    }

    private void button2_Click(object sender, EventArgs e)
    {
        button2.Text = (Operations.TimeOut / 60).ToString();
    }
}
