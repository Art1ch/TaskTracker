using Microsoft.UI.Xaml;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.WinUI.Windows;

namespace TaskTrackerDesktop.WinUI.Implementations;

internal sealed class WinUiWindowManagerService : IWindowManagerService
{
    public Window? CurrentWindow { get; set; }

    public FrameworkElement? CurrentRoot { get; set; }

    public void SetCurrentWindow(Window window)
    {
        CurrentWindow = window;
    }

    public void SetCurrentRoot(FrameworkElement root)
    {
        CurrentRoot = root;
    }

    public void OpenAuthWindow()
    {
        var previous = CurrentWindow;

        var window = new AuthWindowView();

        CurrentWindow = window;

        window.Activate();

        previous?.Close();
    }

    public void OpenMainWindow()
    {
        var previous = CurrentWindow;

        var window = new MainWindowView();

        CurrentWindow = window;

        window.Activate();

        previous?.Close();
    }
}
