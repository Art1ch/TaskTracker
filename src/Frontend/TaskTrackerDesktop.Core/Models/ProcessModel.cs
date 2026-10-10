using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace TaskTrackerDesktop.Core.Models;

public sealed partial class ProcessModel : ModelBase
{
    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _description;

    [ObservableProperty]
    private bool _isActive;
}
