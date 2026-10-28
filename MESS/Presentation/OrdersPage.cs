using System.Collections.ObjectModel;

namespace MESS.Presentation;

public sealed partial class OrdersPage : Page
{
    public OrdersPage()
    {
		var orders = new ObservableCollection<OrderRow>
		{
			new() { OrderId = "1001", Date = new DateTime(2026, 10, 1), Status = "New" },
			new() { OrderId = "1002", Date = new DateTime(2026, 10, 2), Status = "In Progress" },
			new() { OrderId = "1003", Date = new DateTime(2026, 10, 3), Status = "Done" }
		};

		var grid = new Grid
		{
			Margin = new Thickness(12)
		};

		// Create three columns.
		grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
		grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
		grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });

		// Create the header row.
		grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
		for (int i = 0; i < orders.Count; i++)
		{
			grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
		}

		AddCell(grid, 0, 0, "Order ID", true);
		AddCell(grid, 0, 1, "Date", true);
		AddCell(grid, 0, 2, "Status", true);

		for (int i = 0; i < orders.Count; i++)
		{
			var row = orders[i];
			AddCell(grid, i + 1, 0, row.OrderId);
			AddCell(grid, i + 1, 1, row.Date.ToString("yyyy-MM-dd"));
			AddCell(grid, i + 1, 2, row.Status);
		}

		Content = new ScrollViewer
		{
			Content = grid
		};
	}

	private static void AddCell(Grid grid, int row, int column, string text, bool header = false)
	{
		var border = new Border
		{
			BorderThickness = new Thickness(1),
			BorderBrush = new SolidColorBrush(Colors.Gray),
			Padding = new Thickness(8),
			Background = header ? new SolidColorBrush(Colors.LightGray) : null,
			Child = new TextBlock
			{
				Text = text,
				FontWeight = header ? Microsoft.UI.Text.FontWeights.SemiBold : Microsoft.UI.Text.FontWeights.Normal
			}
		};

		Grid.SetRow(border, row);
		Grid.SetColumn(border, column);
		grid.Children.Add(border);
	}

	private sealed class OrderRow
	{
		public string OrderId { get; set; } = string.Empty;
		public DateTime Date { get; set; }
		public string Status { get; set; } = string.Empty;
	}
}
