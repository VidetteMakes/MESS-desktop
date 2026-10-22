namespace MESS.Presentation;

public sealed partial class TrainingPage : Page
{
    public TrainingPage()
    {
        // Create a tab control with three tabs.
        var tabView = new TabView
        {
            IsAddTabButtonVisible = false,
            TabItems =
            {
                CreateTab("Permissions"),
                CreateTab("Skills"),
                CreateWorkInstructionsTab()
            }
        };

        Content = tabView;
    }

    /// <summary>
    /// Creates a simple placeholder tab with the supplied header text.
    /// </summary>
    private static TabViewItem CreateTab(string header) =>
        new()
        {
            Header = header,
            IsClosable = false
        };

    /// <summary>
    /// Creates the "Work Instructions" tab, which contains the training matrix.
    /// </summary>
    private static TabViewItem CreateWorkInstructionsTab()
    {
        // Create a grid with two rows: a title row and a data row.
        var grid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            }
        };

        // Top row: a text block displaying the title. A TextBlock supports rich
        // text through its Inlines collection but is not user editable, and is
        // implemented on all targeted platforms (unlike RichEditBox /
        // RichTextBlock, which are not fully supported by Uno).
        var title = new TextBlock
        {
            Margin = new Thickness(8),
            Inlines =
            {
                new Microsoft.UI.Xaml.Documents.Run { Text = "Training Matrix" }
            }
        };
        Grid.SetRow(title, 0);
        grid.Children.Add(title);

        // Bottom row: the training matrix itself.
        var matrix = CreateTrainingMatrix();
        Grid.SetRow(matrix, 1);
        grid.Children.Add(matrix);

        return new TabViewItem
        {
            Header = "Work Instructions",
            IsClosable = false,
            Content = grid
        };
    }

    // Sample column headers (work instructions) for the training matrix.
    private static readonly string[] ColumnHeaders =
    [
        "Assembly",
        "Inspection",
        "Soldering",
        "Packaging"
    ];

    // Sample row headers (people) for the training matrix.
    private static readonly string[] RowHeaders =
    [
        "Alice",
        "Bob",
        "Carol"
    ];

    // Sample training level values for each person/work instruction combination.
    private static readonly int[,] Values =
    {
        { 3, 2, 1, 0 },
        { 1, 3, 2, 3 },
        { 0, 1, 3, 2 }
    };

    /// <summary>
    /// Creates a grid-based training matrix where the top row and far-left
    /// column are bold, the top row headers are angled at 45 degrees, and each
    /// data cell shows a number with a background color.
    /// </summary>
    private static Grid CreateTrainingMatrix()
    {
        var matrix = new Grid
        {
            Margin = new Thickness(8),
            RowSpacing = 1,
            ColumnSpacing = 1
        };

        // One column for the row headers plus one per column header.
        matrix.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
        foreach (var _ in ColumnHeaders)
        {
            matrix.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
        }

        // One row for the column headers plus one per row header.
        matrix.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        foreach (var _ in RowHeaders)
        {
            matrix.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        }

        // Top-left corner cell (empty).
        AddCell(matrix, new TextBlock(), 0, 0);

        // Top row: column headers (bold, angled 45 degrees).
        for (var col = 0; col < ColumnHeaders.Length; col++)
        {
            var header = new TextBlock
            {
                Text = ColumnHeaders[col],
                FontWeight = Microsoft.UI.Text.FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                RenderTransformOrigin = new Windows.Foundation.Point(0.5, 1),
                RenderTransform = new RotateTransform { Angle = -45 }
            };
            AddCell(matrix, header, 0, col + 1);
        }

        // Data rows.
        for (var row = 0; row < RowHeaders.Length; row++)
        {
            // Far-left column: row header (bold).
            var rowHeader = new TextBlock
            {
                Text = RowHeaders[row],
                FontWeight = Microsoft.UI.Text.FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center
            };
            AddCell(matrix, rowHeader, row + 1, 0);

            // Data cells: a number with a background color.
            for (var col = 0; col < ColumnHeaders.Length; col++)
            {
                var value = Values[row, col];
                var cell = new Border
                {
                    Background = new SolidColorBrush(GetValueColor(value)),
                    MinWidth = 48,
                    MinHeight = 32,
                    Child = new TextBlock
                    {
                        Text = value.ToString(),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    }
                };
                AddCell(matrix, cell, row + 1, col + 1);
            }
        }

        return matrix;
    }

    /// <summary>
    /// Places an element into the given grid cell.
    /// </summary>
    private static void AddCell(Grid grid, FrameworkElement element, int row, int column)
    {
        Grid.SetRow(element, row);
        Grid.SetColumn(element, column);
        grid.Children.Add(element);
    }

    /// <summary>
    /// Maps a training level value to a background color.
    /// </summary>
    private static Color GetValueColor(int value) => value switch
    {
        3 => Colors.LightGreen,
        2 => Colors.Khaki,
        1 => Colors.LightSalmon,
        _ => Colors.LightGray
    };
}
