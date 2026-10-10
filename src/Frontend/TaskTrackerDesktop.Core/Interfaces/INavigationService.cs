using Microsoft.UI.Xaml.Controls;

namespace TaskTrackerDesktop.Core.Interfaces;

public interface INavigationService
{
    void InitializeFrame(Frame frame);
    void NavigateToPage(string pageName, object? parameter = null);
    void GoBack();
    bool CanGoBack { get; }
    void ClearHistory();
}