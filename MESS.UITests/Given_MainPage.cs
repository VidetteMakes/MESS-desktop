namespace MESS.UITests;

public class Given_MainPage : TestBase
{
    [Test]
    public async Task When_NavigationViewNavigation()
    {
        await Task.Delay(5000);
        App.WaitForElement("LoginViewTitle");

        NavigateTo("Production", "ProductionViewTitle");
        NavigateTo("Instructions", "InstructionsViewTitle");
        NavigateTo("Users", "UsersViewTitle");
        NavigateTo("Products", "ProductsViewTitle");
        NavigateTo("Parts", "PartsViewTitle");
        NavigateTo("Defects", "DefectsViewTitle");
        NavigateTo("Orders", "OrdersViewTitle");
        NavigateTo("Settings", "SettingsViewTitle");

        TakeScreenshot("After menu navigation");
    }

    private void NavigateTo(string menuItem, string expectedViewTitle)
    {
        App.WaitForElement(menuItem);
        App.Tap(menuItem);
        App.WaitForElement(expectedViewTitle);
    }
}
