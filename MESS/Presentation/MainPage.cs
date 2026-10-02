// Declare the namespace containing this page.
namespace MESS.Presentation;

// Define the application's main page.
public sealed partial class MainPage : Page
{
    // Constructor that runs when the page is created.
    public MainPage()
    {
        // Associate the page with its MVUX data context (MainViewModel) and configure its layout and appearance.
        this.DataContext<MainViewModel>((page, vm) => page
            // Keep the page alive when navigating away and back.
            .NavigationCacheMode(NavigationCacheMode.Required)

            // Use the current theme's page background color.
            .Background(ThemeResource.Get<Brush>("ApplicationPageBackgroundThemeBrush"))

.Content( // Begin defining the page content.
    new Grid() // Create the main layout container.
        .SafeArea(SafeArea.InsetMask.VisibleBounds) // Keep content within safe display bounds.
        .RowDefinitions("Auto,*,Auto") // Create header, content, and status bar rows.
        .Children( // Add controls to the main grid.

            new Grid() // Create the page header.
                .Grid(row: 0) // Place the header in the top row.
                .ColumnDefinitions("Auto,*") // Create columns for the menu button and title.
                .Padding(10) // Add spacing around the header.
                .Children( // Add controls to the header.

                    new Button() // Create the hamburger menu button.
                        .Grid(column: 0) // Place the button in the first column.
                        .Content(new SymbolIcon(Symbol.GlobalNavigationButton)), // Display the standard hamburger icon.

                    new TextBlock() // Create the page title.
                        .Grid(column: 1) // Place the title in the second column.
                        .Text("MESS") // Display the application name.
                        .FontSize(24) // Make the title larger.
                        .VerticalAlignment(VerticalAlignment.Center) // Center the title vertically.
                ), // End header grid.

            new Border() // Create the content area container.
                .Grid(row: 1) // Place it in the content row.
                .Child( // Specify what appears inside the content area.
                    new TextBlock() // Create placeholder content.
                        .Text("Main Content") // Display placeholder text.
                        .FontSize(18) // Make the text easy to see.
                        .HorizontalAlignment(HorizontalAlignment.Center) // Center horizontally.
                        .VerticalAlignment(VerticalAlignment.Center) // Center vertically.
                ), // End content area.

            new Border() // Create the status bar container.
                .Grid(row: 2) // Place it in the bottom row.
                .Padding(8) // Add spacing around the text.
                .Background(new SolidColorBrush(Colors.LightGray)) // Give the status bar a visible background.
                .Child( // Specify what appears in the status bar.
                    new TextBlock() // Create the status text control.
                        .Text("Ready") // Display the initial status.
                ) // End status bar content.
        ) // End main grid children.
) // End page content.
        );
    }
}
