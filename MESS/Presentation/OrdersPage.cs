namespace MESS.Presentation;

public sealed partial class OrdersPage : Page
{
    public OrdersPage()
    {
        Content = new Grid
        {
            Children =
            {
                new TextBlock
                {
                    Name = "OrdersViewTitle",
                    Text = "Orders",
                    FontSize = 24,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            }
        };
    }
}
