namespace TaskTracker.Core.Entities;

public class ProcessEntity : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid AdminId { get; set; }
    public bool IsActive { get; set; }

    public UserEntity Admin { get; set; }
    public ICollection<UserEntity> Users { get; set; }
    public ICollection<TaskEntity> Tasks { get; set; }
    public ICollection<TagEntity> Tags { get; set; }
}
