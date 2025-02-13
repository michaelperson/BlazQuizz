using System.Text.Json.Serialization;

namespace BlazQuizz.Models
{
    public class ReponseModel
    {
      
        public string Question { get; set; } = string.Empty;
     
        public string  Answer { get; set; } = string.Empty;

        public bool IsCorrect { get; set; } = false;

        public override string ToString()
        {
            string color = IsCorrect ? "green" : "red";
            return $"<b>{Question}</b>: <p style='color:{color}'>{Answer}</p>";
        }
    }
}
