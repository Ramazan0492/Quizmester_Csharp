using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Quizmester_App
{
    [Table("categories")]
    public class Category : BaseModel
    {
        [PrimaryKey("id", false)]
        public long Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }
    }
}