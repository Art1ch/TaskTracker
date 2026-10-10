using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace TaskTrackerDesktop.Core.Models;

public abstract partial class ModelBase : ObservableObject
{
    [ObservableProperty]
    private Guid _id;
}
