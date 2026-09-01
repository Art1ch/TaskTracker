using TaskTracker.Core.Enums;

namespace TaskTracker.Core.Entities;

public class TaskEntity : EntityBase
{
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskState State { get; set; }
    public DateTime? Deadline { get; set; }
    public Guid ProcessId { get; set; }
    public Guid CreatedById { get; set; }
    public Guid AssignedToId { get; set; }

    public ProcessEntity Process { get; set; }
    public UserEntity CreatedBy { get; set; }
    public UserEntity AssignedTo { get; set; }
    public ICollection<TagEntity> Tags { get; set; }
    public ICollection<RemarkEntity> Remarks { get; set; }
}
