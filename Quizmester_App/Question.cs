using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Quizmester_App
{
    [Table("questions")]
    public class Question : BaseModel
    {
        [PrimaryKey("id", false)]
        public long Id { get; set; }

        // Jouw foreign key naar de categorie tabel!
        [Column("category_id")]
        public long CategoryId { get; set; }

        [Column("question_text")]
        public string? QuestionText { get; set; }

        // Jouw eigen toevoeging voor de timer MUST!
        [Column("time_limit")]
        public int TimeLimit { get; set; }

        [Column("correct_answer")]
        public string? CorrectAnswer { get; set; }

        [Column("wrong_answer_1")]
        public string? WrongAnswer1 { get; set; }

        [Column("wrong_answer_2")]
        public string? WrongAnswer2 { get; set; }

        [Column("wrong_answer_3")]
        public string? WrongAnswer3 { get; set; }
    }
}