// Declare the namespace containing this page.
namespace MESS.Presentation;

// Define the application's main page.
public sealed partial class MainPage : Page
{
    private readonly Frame _contentFrame = new();
    private static readonly (string Title, Type PageType)[] MenuDefinitions =
    [
        ("Production", typeof(ProductionPage)),
        ("Instructions", typeof(InstructionsPage)),
        ("Users", typeof(UsersPage)),
        ("Products", typeof(ProductsPage)),
        ("Parts", typeof(PartsPage)),
        ("Defects", typeof(DefectsPage)),
        ("Orders", typeof(OrdersPage)),
        ("Settings", typeof(SettingsPage))
    ];

    // Constructor that runs when the page is created.
    public MainPage()
    {
        var menuButton = new Button
        {
            Name = "MainMenuButton"
        }
            .Grid(column: 0)
            .Content(new SymbolIcon(Symbol.GlobalNavigationButton));
        menuButton.Flyout = BuildMenuFlyout();

        _contentFrame.Navigate(typeof(LoginPage));

        // Associate the page with its MVUX data context (MainViewModel) and configure its layout and appearance.
        this.DataContext<MainViewModel>((page, vm) => page
            // Keep the page alive when navigating away and back.
            .NavigationCacheMode(NavigationCacheMode.Required)

            // Use the current theme's page background color.
            .Background(ThemeResource.Get<Brush>("ApplicationPageBackgroundThemeBrush"))

// Begin defining the page content.
.Content(
    // Create the main layout container.
    new Grid()
        // Keep content within safe display bounds.
        .SafeArea(SafeArea.InsetMask.VisibleBounds)

        // Create header, content, and status bar rows.
        .RowDefinitions("Auto,*,Auto")

        // Add controls to the main grid.
        .Children(
            // Create the page header.
            new Grid()
                // Place the header in the top row.
                .Grid(row: 0)

                // Create columns for the menu button and title.
                .ColumnDefinitions("Auto,*")

                // Add spacing around the header.
                .Padding(10)

                // Add controls to the header.
                .Children(
                    // Create the hamburger menu button.
                    menuButton,

                    // Create the page title.
                    new TextBlock()
                        // Place the title in the second column.
                        .Grid(column: 1)

                        // Display the application name.
                        .Text("MESS")

                        // Make the title larger.
                        .FontSize(24)

                        // Center the title vertically.
                        .VerticalAlignment(VerticalAlignment.Center)
                ), // End header grid.

            // Create the content area container.
            new Border()
                // Place it in the content row.
                .Grid(row: 1)

                // Specify what appears inside the content area.
                .Child(
                    // Host navigated content pages.
                    _contentFrame
                ), // End content area.

            // Create the status bar container.
            new Border()
                // Place it in the bottom row.
                .Grid(row: 2)

                // Add spacing around the text.
                .Padding(8)

                // Give the status bar a visible background.
                .Background(new SolidColorBrush(Colors.LightGray))

                // Specify what appears in the status bar.
                .Child(
                    // Create the status text control.
                    new TextBlock()

                        // Display the initial status.
                        .Text("Ready")
                ) // End status bar content.
        ) // End main grid children.
) // End page content.
        );
    }

    private MenuFlyout BuildMenuFlyout()
    {
        var flyout = new MenuFlyout();

        foreach (var (title, pageType) in MenuDefinitions)
        {
            flyout.Items.Add(CreateMenuItem(title, pageType));
        }

        return flyout;
    }

    private MenuFlyoutItem CreateMenuItem(string title, Type pageType)
    {
        var item = new MenuFlyoutItem
        {
            Text = title,
            Tag = title
        };

        item.Click += (_, _) => _contentFrame.Navigate(pageType);

        return item;
    }
}
