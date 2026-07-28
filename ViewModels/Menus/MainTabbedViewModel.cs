using FoodDelivery.ViewModels.Tabs;
using Nkraft.MvvmEssentials.Services.FlyoutPages;
using Nkraft.MvvmEssentials.ViewModels;

namespace FoodDelivery.ViewModels.Menus;

public class MainTabbedViewModel(
    RestaurantsTabViewModel restaurantsTab,
    SearchTabViewModel searchTab,
    CartTabViewModel cartTab) : TabHostViewModel, IFlyoutComponent
{
    void IFlyoutComponent.OnFlyoutOpened()
    {
        
    }

    void IFlyoutComponent.OnFlyoutClosed()
    {
        
    }

    Task IFlyoutComponent.OnFlyoutOpenedAsync()
    {
        return Task.CompletedTask;
    }

    Task IFlyoutComponent.OnFlyoutClosedAsync()
    {
        return Task.CompletedTask;
    }

    protected override void OnDispose()
    {
        base.OnDispose();
        
        Console.WriteLine("MainTabbedViewModel.OnDispose()");
    }

    protected override TabViewModel[] Tabs => [restaurantsTab, searchTab, cartTab];

    public RestaurantsTabViewModel RestaurantsTabViewModel => restaurantsTab;

    public SearchTabViewModel SearchTabViewModel => searchTab;

    public CartTabViewModel CartTabViewModel => cartTab;
}
