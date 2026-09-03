using System;

namespace TaskTrackerDesktop.Core.Interfaces;

public interface INavigationService
{
    void NavigateTo(string viewName, object parameter = null);
    void GoBack();
    bool CanGoBack { get; }
    void ClearHistory();
}