namespace MESS.Presentation;

public sealed partial class ProfilePage : Page
{
	public ProfilePage()
	{
		Content = new Grid
		{
			Children =
			{
				new TextBlock
				{
					Name = "ProfileViewTitle",
					Text = "Profile",
					FontSize = 24,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center
				}
			}
		};
	}
}
