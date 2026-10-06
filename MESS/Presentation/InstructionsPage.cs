namespace MESS.Presentation;

public sealed partial class InstructionsPage : Page
{
    public InstructionsPage()
    {
        Content = new Grid
        {
            Children =
            {
                new TextBlock
                {
                    Name = "InstructionsViewTitle",
                    Text = "Instructions",
                    FontSize = 24,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            }
        };
    }
}
