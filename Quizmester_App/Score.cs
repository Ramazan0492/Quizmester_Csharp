using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;

namespace Quizmester_App
{
    [Table("scores")]
    public class Score : BaseModel
    {
        [PrimaryKey("id", false)]
        public long Id { get; set; }

        [Column("user_id")]
        public long UserId { get; set; }

        [Column("score")]
        public int ScoreValue { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}