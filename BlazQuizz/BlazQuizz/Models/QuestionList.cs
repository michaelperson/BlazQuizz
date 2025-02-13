using System.Text.Json.Serialization;

namespace BlazQuizz.Models
{
    public class QuestionList
    {
        [JsonPropertyName("questions")]
        public List<QuestionModel> Questions { get; set; } = new();
    }
}
