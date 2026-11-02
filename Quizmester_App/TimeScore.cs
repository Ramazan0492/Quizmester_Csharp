using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Quizmester_App
{
    [Table("TimeScore")]
    public class TimeScore : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("UserId")]
        public string UserId { get; set; }

        [Column("TimeInSeconds")]
        public int TimeInSeconds { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
    }
}