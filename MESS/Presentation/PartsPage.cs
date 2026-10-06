namespace MESS.Presentation;

public sealed partial class PartsPage : Page
{
    public PartsPage()
    {
        Content = new Grid
        {
            Children =
            {
                new TextBlock
                {
                    Name = "PartsViewTitle",
                    Text = "Parts",
                    FontSize = 24,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            }
        };
    }
}
