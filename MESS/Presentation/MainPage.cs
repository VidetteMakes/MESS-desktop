// Declare the namespace containing this page.
namespace MESS.Presentation;

// Define the application's main page.
public sealed partial class MainPage : Page
{
    private readonly Frame _contentFrame = new();
    private readonly TextBlock _statusText = new() { Text = "Ready" };
    private static readonly string[] PrimaryMenuTags =
    [
        "Production",
        "Instructions",
        "Users",
        "Products",
        "Parts",
        "Defects",
        "Orders"
    ];
    private const string SettingsTag = "Settings";
    private static readonly Dictionary<string, Type> MenuDefinitions = new()
    {
        ["Production"] = typeof(ProductionPage),
        ["Instructions"] = typeof(InstructionsPage),
        ["Users"] = typeof(UsersPage),
        ["Products"] = typeof(ProductsPage),
        ["Parts"] = typeof(PartsPage),
        ["Defects"] = typeof(DefectsPage),
        ["Orders"] = typeof(OrdersPage),
        ["Settings"] = typeof(SettingsPage)
    };

    // Constructor that runs when the page is created.
    public MainPage()
    {
        var navigationView = CreateNavigationView();

        _contentFrame.Navigate(typeof(LoginPage));
        navigationView.SelectedItem = null;

        // Associate the page with its MVUX data context (MainViewModel) and configure its layout and appearance.
        this.DataContext<MainViewModel>((page, vm) => page
            // Keep the page alive when navigating away and back.
            .NavigationCacheMode(NavigationCacheMode.Required)

            // Use the current theme's page background color.
            .Background(ThemeResource.Get<Brush>("ApplicationPageBackgroundThemeBrush"))

            // Begin defining the page content.
            .Content(navigationView)
        );
    }

    private NavigationView CreateNavigationView()
    {
        var contentLayout = new Grid();
        contentLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        contentLayout.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        Grid.SetRow(_contentFrame, 0);
        contentLayout.Children.Add(_contentFrame);

        var statusBar = new Border
        {
            Padding = new Thickness(8),
            Background = new SolidColorBrush(Colors.LightGray),
            Child = _statusText
        };

        Grid.SetRow(statusBar, 1);
        contentLayout.Children.Add(statusBar);

        var navigationView = new NavigationView
        {
            IsSettingsVisible = false,
            IsBackButtonVisible = NavigationViewBackButtonVisible.Collapsed,
            PaneDisplayMode = NavigationViewPaneDisplayMode.Left,
            IsPaneToggleButtonVisible = true,
            IsPaneOpen = true,
            AlwaysShowHeader = true,
            Header = CreateTitleBar(),
            Content = contentLayout
        };

        foreach (var tag in PrimaryMenuTags)
        {
            navigationView.MenuItems.Add(CreateNavigationViewItem(tag));
        }

        navigationView.FooterMenuItems.Add(CreateNavigationViewItem(SettingsTag));
        navigationView.SelectionChanged += OnSelectionChanged;

        return navigationView;
    }

    private static TitleBar CreateTitleBar() =>
        new()
        {
            Title = "MESS"
        };

    private static NavigationViewItem CreateNavigationViewItem(string tag) =>
        new()
        {
            Content = tag,
            Tag = tag
        };

    private void OnSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.SelectedItemContainer?.Tag is not string tag)
        {
            return;
        }

        if (!MenuDefinitions.TryGetValue(tag, out var pageType))
        {
            return;
        }

        _contentFrame.Navigate(pageType);
        _statusText.Text = $"{tag} loaded";
    }
}
