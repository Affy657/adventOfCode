using System.Text.Json.Serialization;

namespace API
{
    public class Day
    {
        [JsonPropertyName("day")]

        public int DayNumber { get; set; }
        [JsonPropertyName("bonus")]

        public bool Bonus { get; set; }
    }

    public class Solution
    {
        [JsonPropertyName("year")]

        public int Year { get; set; }
        [JsonPropertyName("days")]

        public List<Day> Days { get; set; }
    }

    public class ResponseModel
    {
        [JsonPropertyName("solutions")]

        public List<Solution> Solutions { get; set; }
    }
}

