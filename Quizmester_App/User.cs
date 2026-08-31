using System.ComponentModel.DataAnnotations.Schema;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Quizmester_App
{
    [Table("users")]
    public class User : BaseModel
    {
        [PrimaryKey("id", false)]
        public long Id { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("is_admin")]
        public bool IsAdmin { get; set; }
    }
}