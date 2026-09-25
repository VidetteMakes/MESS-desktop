namespace MESS.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.DataContext<MainViewModel>((page, vm) => page
            .NavigationCacheMode(NavigationCacheMode.Required)
            .Background(ThemeResource.Get<Brush>("ApplicationPageBackgroundThemeBrush"))
            .Content(new Grid()
                .SafeArea(SafeArea.InsetMask.VisibleBounds)
                .Children(
                    new TextBlock()
                        .Text("Hello Uno Platform!")
                        .AutomationProperties(automationId: "HelloTextBlock")
                        .FontSize(20)
                        .HorizontalAlignment(HorizontalAlignment.Center)
                        .VerticalAlignment(VerticalAlignment.Center)))
        );
    }
}
