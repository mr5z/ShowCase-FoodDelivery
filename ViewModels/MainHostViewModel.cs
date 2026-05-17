using Nkraft.MvvmEssentials.ViewModels;

namespace FoodDelivery.ViewModels;

public sealed class MainHostViewModel(MenuViewModel menu, MainTabbedViewModel detail)
    : FlyoutHostViewModel<MenuViewModel, MainTabbedViewModel>(menu, detail);