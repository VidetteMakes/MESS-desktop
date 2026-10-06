namespace MESS.Presentation;

public sealed partial class DefectsPage : Page
{
    public DefectsPage()
    {
        Content = new Grid
        {
            Children =
            {
                new TextBlock
                {
                    Name = "DefectsViewTitle",
                    Text = "Defects",
                    FontSize = 24,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            }
        };
    }
}
