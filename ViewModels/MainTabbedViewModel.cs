using Nkraft.MvvmEssentials.Services.Navigation;
using Nkraft.MvvmEssentials.ViewModels;

namespace FoodDelivery.ViewModels;

public class MainTabbedViewModel(
    RestaurantsTabViewModel restaurantsTab,
    SearchTabViewModel searchTab,
    CartTabViewModel cartTab) : TabHostViewModel, IFlyoutComponent
{
    protected override TabViewModel[] Tabs { get; } = [restaurantsTab, searchTab, cartTab];

    public RestaurantsTabViewModel RestaurantsTabViewModel { get; } = restaurantsTab;

    public SearchTabViewModel SearchTabViewModel { get;  } = searchTab;

    public CartTabViewModel CartTabViewModel { get; } = cartTab;
    
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
}
