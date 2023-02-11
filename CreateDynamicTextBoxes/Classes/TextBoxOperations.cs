namespace CreateDynamicTextBoxes.Classes;

#pragma warning disable CS8618
public class TextBoxOperations
{
    public static List<TextBox> List { get; set; }
    public static int Top { get; set; }
    public static int Left { get; set; }
    public static int Width { get; set; }
    public static int HeightPadding { get; set; }
    public static string BaseName { get; set; }
    public static Control ParentControl { get; set; }
    private static int _index = 1;
    public static void Initialize(Control pControl, int pTop, int pBaseHeightPadding, int pLeft, int pWidth)
    {

        ParentControl = pControl;
        Top = pTop;
        HeightPadding = pBaseHeightPadding;
        Left = pLeft;
        Width = pWidth;
        List = new List<TextBox>();

    }
    private static void Create(string text)
    {

        var button = new TextBox()
        {
            Name = $"{BaseName}{_index}",
            Text = text,
            Width = Width,
            Location = new Point(Left, Top),
            Parent = ParentControl,
            Visible = true,
            Tag = _index
        };


        List.Add(button);

        ParentControl.Controls.Add(button);
        Top += HeightPadding;
        _index += 1;

    }

    public static void Build(string[] lines)
    {
        foreach (var line in lines)
        {
            Create(line);
        }
    }

    public static void Save(string fileName)
    {
        File.WriteAllLines(fileName, List.Select(tb => tb.Text).ToArray());
    }

}