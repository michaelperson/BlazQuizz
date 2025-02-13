using System.Text.Json.Serialization;

namespace BlazQuizz.Models
{
    public class QuestionModel
    {
        [JsonPropertyName("question")]
        public string Question { get; set; } = string.Empty;
        [JsonPropertyName("correct_answer")]
        public string CorrectAnswer { get; set; } = string.Empty;
    }

}
