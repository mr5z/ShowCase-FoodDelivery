using Nkraft.MvvmEssentials.Services;

namespace FoodDelivery;

public partial class App
{
    private readonly AppStartupWindowHook _startupWindowHook;
    public App(AppStartupWindowHook startupWindowHook)
    {
        _startupWindowHook = startupWindowHook;
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        _startupWindowHook.Attach();
        return base.CreateWindow(activationState);
    }
}