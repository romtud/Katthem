using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace WpfMVVM.Models;

[Table("shelters")]
public sealed class Shelter : BaseModel{
  
  [PrimaryKey("id", false)]
  public long Id { get; set; }

  [Column("name")]
  public string Name { get; set; } = string.Empty;

  [Column("city")]
  public string City { get; set; } = string.Empty;

  public override string ToString() => $"{Name} — {City}";
}
