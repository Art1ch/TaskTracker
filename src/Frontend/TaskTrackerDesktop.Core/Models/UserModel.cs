using System;
using TaskTrackerDesktop.Core.Enums;

namespace TaskTrackerDesktop.Core.Models;

public sealed class UserModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserRole Role { get; set; }

}