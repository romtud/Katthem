using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace WpfMVVM.Models;

[Table("cats")]
public sealed class Cat : BaseModel{
  
  [PrimaryKey("id", false)]
  public long Id { get; set; }

  [Column("shelter_id")]
  public long ShelterId { get; set; }

  [Column("name")]
  public string Name { get; set; } = string.Empty;

  [Column("age")]
  public int? Age { get; set; }

  [Column("color")]
  public string? Color { get; set; }

  [Column("adopted")]
  public bool Adopted { get; set; }

  [Column("image_url")]
  public string? ImageUrl { get; set; }

  public override string ToString() => Name;
}