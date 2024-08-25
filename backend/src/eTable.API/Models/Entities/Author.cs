﻿using eTable.API.Models.Entities.Base;

namespace eTable.API.Models.Entities
{
    public class Author : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public bool IsUser { get; set; } = false;

        public long UserId{ get; set; }
        public virtual User? User { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
