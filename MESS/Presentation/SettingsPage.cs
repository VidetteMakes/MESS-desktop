namespace MESS.Presentation;

public sealed partial class SettingsPage : Page
{
	public SettingsPage()
	{
		Content = new Grid
		{
			Children =
			{
				new TextBlock
				{
					Name = "SettingsViewTitle",
					Text = "Settings",
					FontSize = 24,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center
				}
			}
		};
	}
}
