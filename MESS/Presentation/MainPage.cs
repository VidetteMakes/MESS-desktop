// Declare the namespace containing this page.
namespace MESS.Presentation;

// Define the application's main page.
public sealed partial class MainPage : Page
{
	// Frame control used to display the content of the selected menu item.
	private readonly Frame _contentFrame = new();

	// TextBlock control used to display the status of the application.
	private readonly TextBlock _statusText = new()
	{
		Text = "Ready",
		Foreground = GetBrush("StatusBarForegroundBrush")
	};

	// primary menu items tags
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

	// secondary menu items tags
	private static readonly string[] SecondaryMenuTags =
	[
		"Settings",
		"Profile"
	];

	// menu icon map
	private static readonly Dictionary<string, Symbol> MenuIcons = new()
	{
		["Production"] = Symbol.Play,
		["Instructions"] = Symbol.Document,
		["Users"] = Symbol.People,
		["Products"] = Symbol.Shop,
		["Parts"] = Symbol.Library,
		["Defects"] = Symbol.ReportHacked,
		["Orders"] = Symbol.Shop,
		["Settings"] = Symbol.Setting,
		["Profile"] = Symbol.Contact
	};

	// Map menu item tags to their corresponding page types.
	private static readonly Dictionary<string, Type> MenuDefinitions = new()
    {
        ["Production"] = typeof(ProductionPage),
        ["Instructions"] = typeof(InstructionsPage),
        ["Users"] = typeof(UsersPage),
        ["Products"] = typeof(ProductsPage),
        ["Parts"] = typeof(PartsPage),
        ["Defects"] = typeof(DefectsPage),
        ["Orders"] = typeof(OrdersPage),
        ["Settings"] = typeof(SettingsPage),
		["Profile"] = typeof(ProfilePage)
	};

	private static Brush GetBrush(string resourceKey) =>
		(Brush)Application.Current.Resources[resourceKey];

	/// <summary>
	/// Construct the main page, which contains a navigation view and a content frame.
	/// </summary>
	public MainPage()
    {
		// Create the navigation view ("hamburger menu").
		var navigationView = CreateNavigationView();

		// Start at the login page.
        _contentFrame.Navigate(typeof(LoginPage));
        navigationView.SelectedItem = null;

        // Associate the page with its MVUX data context (MainViewModel) and configure its layout and appearance.
        this.DataContext<MainViewModel>((page, vm) => page
            // Keep the page alive when navigating away and back.
            .NavigationCacheMode(NavigationCacheMode.Required)

            // Use the current theme's page background color.
            .Background(GetBrush("ApplicationPageBackgroundThemeBrush"))

            // Begin defining the page content.
            .Content(navigationView)
        );
    }

	/// <summary>
	/// Creates a NavigationView control with a content frame and status bar.
	/// </summary>
	/// <returns>created NavigationView control</returns>
	private NavigationView CreateNavigationView()
    {
		// Create a grid layout to hold the content frame and status bar.
		var contentLayout = new Grid();

		// Define two rows: one for the content frame (takes up remaining space) and one for the status bar (auto-sized).
		contentLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        contentLayout.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

		// Add the content frame to the first row of the grid layout.
		Grid.SetRow(_contentFrame, 0);
        contentLayout.Children.Add(_contentFrame);

		// Add a status bar to the second row of the grid layout.
		var statusBar = new Border
        {
            Padding = new Thickness(8),
			Background = GetBrush("StatusBarBackgroundBrush"),
			Child = _statusText
        };

		// Set the status bar to the second row of the grid layout and add it to the content layout.
		Grid.SetRow(statusBar, 1);
        contentLayout.Children.Add(statusBar);

		// Create the NavigationView control and configure its properties.
		var navigationView = new NavigationView
        {
            IsSettingsVisible = false,
            IsBackButtonVisible = NavigationViewBackButtonVisible.Collapsed,
            PaneDisplayMode = NavigationViewPaneDisplayMode.LeftMinimal,
            IsPaneToggleButtonVisible = true,
            IsPaneOpen = true,
            AlwaysShowHeader = true,
            Header = CreateTitleBar(),
            Content = contentLayout
        };

		// Add primary menu items to the NavigationView.
		foreach (var tag in PrimaryMenuTags)
        {
            navigationView.MenuItems.Add(CreateNavigationViewItem(tag));
        }

		// Add secondary menu items to the NavigationView's footer.
		foreach (var tag in SecondaryMenuTags)
		{
			navigationView.FooterMenuItems.Add(CreateNavigationViewItem(tag));
		}

		// Subscribe to the SelectionChanged event of the NavigationView to handle menu item selection.
		navigationView.SelectionChanged += OnSelectionChanged;

		// Return the configured NavigationView control.
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
            Tag = tag,
			Icon = new SymbolIcon(MenuIcons.TryGetValue(tag, out var icon) ? icon : Symbol.Document)
        };

	/// <summary>
	/// When a menu item is selected, navigate to the corresponding page and updates the status text.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	private void OnSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
		// Ensure that the selected item has a valid tag that corresponds to a page type.
		if (args.SelectedItemContainer?.Tag is not string tag)
        {
            return;
        }

		// Try to get the page type associated with the selected menu item's tag. If not found, do nothing.
		if (!MenuDefinitions.TryGetValue(tag, out var pageType))
        {
            return;
        }

		// Navigate to the selected page.
		_contentFrame.Navigate(pageType);

		// Alert the user
		_statusText.Text = $"{tag} loaded";
    }
}
