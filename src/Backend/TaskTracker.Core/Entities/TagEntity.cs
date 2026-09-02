namespace TaskTracker.Core.Entities;

public class TagEntity : EntityBase
{
    public string Name { get; set; }
    public Guid ProcessId { get; set; }

    public ProcessEntity Process { get; set; }
    public ICollection<TaskEntity> Tasks { get; set; }
}
 