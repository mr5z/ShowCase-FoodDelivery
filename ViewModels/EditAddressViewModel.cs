using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FoodDelivery.Models;
using Nkraft.MvvmEssentials.Attributes;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;

namespace FoodDelivery.ViewModels;

/// <summary>
/// Full-screen modal that edits a delivery address and returns it to the caller.
/// Exit paths:
///   Save            -> Dismiss(result)  -> caller gets the new address
///   Cancel          -> Dismiss()        -> caller gets ErrorCode.Cancelled
///   Back / swipe    -> system dismissal -> caller gets ErrorCode.Cancelled
/// </summary>
public partial class EditAddressViewModel(IModalService modalService)
    : ModalViewModel<DeliveryAddress>(modalService)
{
    [NavigationParameter]
    public string Street { get; set; } = string.Empty;

    [NavigationParameter]
    public string Apartment { get; set; } = string.Empty;

    [NavigationParameter]
    public string City { get; set; } = string.Empty;

    [NavigationParameter]
    public string ZipCode { get; set; } = string.Empty;

    public bool CanSave =>
        !string.IsNullOrWhiteSpace(Street) &&
        !string.IsNullOrWhiteSpace(City) &&
        !string.IsNullOrWhiteSpace(ZipCode);

    protected override void OnPropertyChanged(PropertyChangedEventArgs args)
    {
        base.OnPropertyChanged(args);

        if (args.PropertyName == nameof(CanSave))
            SaveCommand.NotifyCanExecuteChanged();
    }

    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task Save()
    {
        await Dismiss(new DeliveryAddress(Street.Trim(), Apartment.Trim(), City.Trim(), ZipCode.Trim()));
    }
}