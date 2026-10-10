using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.WinUI.Pages;

namespace TaskTrackerDesktop.WinUI.Implementations;

internal sealed class WinUiNavigationService : INavigationService
{
    private Frame _frame;
    private readonly Dictionary<string, Type> _viewMap;
    private readonly Stack<string> _navigationHistory;
    private string _currentView;

    public bool CanGoBack => _navigationHistory.Count > 0;

    public WinUiNavigationService()
    {
        _viewMap = new Dictionary<string, Type>()
        {
            ["DashboardPage"] = typeof(DashboardPageView),
            ["UsersPage"] = typeof(UsersPageView),
            ["ProcessesPage"] = typeof(ProcessesPageView),
            ["LoginPage"] = typeof(LoginPageView),
            ["RegisterPage"] = typeof(RegisterPageView),
            ["TasksPage"] = typeof(TasksPageView),
            ["TaskDetail"] = typeof(TaskDetailPageView),
        };

        _navigationHistory = new();
    }

    public void GoBack()
    {
        if (!CanGoBack) 
            return;

        var previousView = _navigationHistory.Pop();
        _currentView = previousView;

        var pageType = _viewMap.GetValueOrDefault(previousView);
        _frame.Navigate(pageType);
    }

    public void ClearHistory()
    {
        _navigationHistory.Clear();
    }

    public void InitializeFrame(Frame frame)
    {
        _frame = frame;
    }

    public void NavigateToPage(string pageName, object? parameter = null)
    {
        var pageType = _viewMap.GetValueOrDefault(pageName);

        _navigationHistory.Push(_currentView);

        _currentView = pageName;
        _frame.Navigate(pageType, parameter);
    }
}