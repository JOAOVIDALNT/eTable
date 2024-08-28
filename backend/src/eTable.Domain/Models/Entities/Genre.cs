using eTable.Domain.Models.Entities.Base;

namespace eTable.Domain.Models.Entities
{
    public class Genre : EntityBase
    {
        public string Description { get; set; } = string.Empty;

        public long UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
