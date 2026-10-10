namespace TaskTracker.Core.Entities;

public class RemarkEntity : EntityBase
{
    public string Text { get; set; }
    public Guid TaskId { get; set; }
    public Guid UserId { get; set; }

    public TaskEntity Task { get; set; }
    public UserEntity User { get; set; }
}