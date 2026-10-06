namespace MESS.Presentation;

public sealed partial class ProductsPage : Page
{
    public ProductsPage()
    {
        Content = new Grid
        {
            Children =
            {
                new TextBlock
                {
                    Name = "ProductsViewTitle",
                    Text = "Products",
                    FontSize = 24,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            }
        };
    }
}
