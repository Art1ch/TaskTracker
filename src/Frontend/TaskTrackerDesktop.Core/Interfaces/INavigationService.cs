using System;

namespace TaskTrackerDesktop.Core.Interfaces;

public interface INavigationService
{
    void NavigateTo(Type pageType);
    void NavigateToMainShell(object parameter = null);
    void NavigateToLoginPage();
}
