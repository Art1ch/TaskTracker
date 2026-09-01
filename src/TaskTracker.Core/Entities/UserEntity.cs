using Microsoft.AspNetCore.Identity;
using TaskTracker.Core.Enums;

namespace TaskTracker.Core.Entities;

public class UserEntity : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserRole Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ICollection<ProcessEntity> Processes { get; set; }
    public ICollection<TaskEntity> CreatedTasks { get; set; }
    public ICollection<TaskEntity> AssignedTasks { get; set; }
    public ICollection<RemarkEntity> Remarks { get; set; }
}