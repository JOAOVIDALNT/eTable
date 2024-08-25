using eTable.API.Models.Entities.Base;

namespace eTable.API.Models.Entities
{
    public class Book : EntityBase
    {
        public string Title { get; set; } = string.Empty;
        public string Synopsis { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }

        public long AuthorId { get; set; }
        public virtual Author? Author { get; set; }

        public long GenreId { get; set; }
        public virtual Genre? Genre { get; set; }

        public long UserId{ get; set; }
        public virtual User? User { get; set; }
    }
}
