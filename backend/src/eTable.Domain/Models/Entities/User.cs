using eTable.Domain.Models.Entities.Base;

namespace eTable.Domain.Models.Entities
{
    public class User : EntityBase
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
        public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
        public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}
