using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace TaskTrackerDesktop.Core.Filters;

public abstract partial class FilterFormBase : ObservableObject
{
    [ObservableProperty]
    private int _page = 1;

    [ObservableProperty]
    private int _pageSize = 25;

    [ObservableProperty]
    private DateTime? _from;

    [ObservableProperty]
    private DateTime? _to;
}
