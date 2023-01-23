using System.Drawing;

namespace GreetingsConsoleApp.Classes;
public static class ImageHelper
{
    public static Size RescaleImageToFit(Size imageSize, Size canvasSize)
    {
        // Figure out the ratio
        double ratioX = canvasSize.Width / (double)imageSize.Width;
        double ratioY = canvasSize.Height / (double)imageSize.Height;

        // use whichever multiplier is smaller
        double ratio = Math.Min(ratioX, ratioY);

        // now we can get the new height and width
        int newHeight = Convert.ToInt32(imageSize.Height * ratio);
        int newWidth = Convert.ToInt32(imageSize.Width * ratio);

        Size resizedSize = new(newWidth, newHeight);

        if (resizedSize.Width > canvasSize.Width || resizedSize.Height > canvasSize.Height)
        {
            throw new Exception("ImageHelper.RescaleImageToFit - Resize failed!");
        }

        return resizedSize;
    }
}
