using Android.App;
using Android.Runtime;

namespace FoodDelivery;

[Application]
public class MainApplication(IntPtr handle, JniHandleOwnership ownership) : MauiApplication(handle, ownership)
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    
    public override void OnCreate()
    {
        base.OnCreate();
        Console.WriteLine("Just log something here, to make sure it prints");
    }
}