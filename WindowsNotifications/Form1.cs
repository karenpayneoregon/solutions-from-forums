using System.ComponentModel;
using Microsoft.Toolkit.Uwp.Notifications;
using Notifications.Classes;

namespace Notifications;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        Shown += OnShown!;
        Closing += OnClosing;
    }

    private void OnClosing(object? sender, CancelEventArgs e)
    {
        ToastNotificationManagerCompat.History.Clear();
    }

    private void OnShown(object sender, EventArgs e)
    {
           
        ToastNotificationManagerCompat.OnActivated += toastArgs =>
        {
            ToastArguments args = ToastArguments.Parse(toastArgs.Argument);

            if (args.Contains("conversationId"))
            {
                if (args["conversationId"] == "9814")
                {
                        
                    Invoke(delegate
                    {
                        Dialogs.Information(ExecuteButton,"Notification triggered", "Woohoo");
                    });
                }
            }

        };
    }

    private void ExecuteButton_Click(object sender, EventArgs e)
    {
        var imageUri = Path.GetFullPath(@"Karen.png");
        new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", 9814)
            .AddText("Karen is up to something")
            .AddAppLogoOverride(new Uri(imageUri)).SetToastDuration(ToastDuration.Long)
            .AddButton(new ToastButton()
                .SetContent("Get the facts from her")
                .AddArgument("action", "viewReport")
                .AddArgument("url", "https://github.com/karenpayneoregon?tab=repositories"))
            .Show(toast =>
            {
                toast.ExpirationTime = DateTime.Now.AddMinutes(2);
            });
    }
}