using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfMVVM.Models
{

    [Table("cats")]
    public class Cat : BaseModel
    {
        [PrimaryKey("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Column("color")]
        public string Color { get; set; }

        [Reference(typeof(Shelter))]
        public Shelter Shelter { get; set; }

    }


}
