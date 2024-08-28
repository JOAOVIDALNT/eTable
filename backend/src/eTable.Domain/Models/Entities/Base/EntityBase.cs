namespace eTable.Domain.Models.Entities.Base
{
    public class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public bool Active { get; set; } = true;
    }
}
