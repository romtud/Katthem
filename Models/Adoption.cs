using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace WpfMVVM.Models;

[Table("adoptions")]
public sealed class Adoption : BaseModel{
    
    [PrimaryKey("id", false)]
    public long Id { get; set; }

    [Column("cat_id")]
    public long CatId { get; set; }

    [Column("date_adopted")]
    public DateTime? DateAdopted { get; set; }

    [Column("date_returned")]
    public DateTime? DateReturned { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [Column("last_name")]
    public string LastName { get; set; } = string.Empty;

    public string AdopterName => $"{FirstName} {LastName}".Trim();

    public string Status => DateReturned.HasValue ? "Returned" : "Current";
}
