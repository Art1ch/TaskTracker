using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Interfaces;

namespace TaskTrackerDesktop.WinUI.Implementations;

internal sealed class WinUiDialogService : IDialogService
{
    private readonly IWindowManagerService _windowManagerService;

    public WinUiDialogService(IWindowManagerService windowManagerService)
    {
        _windowManagerService = windowManagerService;
    }

    public async Task ShowDialog(string message)
    {

        var contentDialog = new ContentDialog
        {
            Title = "Info",
            Content = message,
            CloseButtonText = "Ok",
            XamlRoot = _windowManagerService.CurrentRoot?.XamlRoot
        };

        await contentDialog.ShowAsync();
    }

    public async Task ShowError(string errorMessage)
    {
        var contentDialog = new ContentDialog
        {
            Title = "Error",
            Content = errorMessage,
            CloseButtonText = "Ok",
            XamlRoot = _windowManagerService.CurrentRoot?.XamlRoot
        };

        await contentDialog.ShowAsync();
    }
}
