using Microsoft.UI.Xaml;

namespace TaskTrackerDesktop.Core.Interfaces;

public interface IWindowManagerService
{
    public Window? CurrentWindow { get; }
    public FrameworkElement? CurrentRoot { get; }
    void OpenAuthWindow();
    void OpenMainWindow();
    void SetCurrentWindow(Window window);
    void SetCurrentRoot(FrameworkElement root);
}
