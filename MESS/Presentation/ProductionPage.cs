namespace MESS.Presentation;

public sealed partial class ProductionPage : Page
{
    public ProductionPage()
    {
        Content = new Grid
        {
            Children =
            {
                new TextBlock
                {
                    Name = "ProductionViewTitle",
                    Text = "Production",
                    FontSize = 24,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            }
        };
    }
}
