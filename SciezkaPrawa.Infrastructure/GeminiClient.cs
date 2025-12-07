using SciezkaPrawa.Application.AiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SciezkaPrawa.Infrastructure
{
    public class GeminiOptions
    {
        public string ApiKey { get; set; } = default!;
        public string Model { get; set; } = "gemini-1.5-flash-latest";
    }

    public class GeminiClient : IAiClient
    {
        private readonly HttpClient _httpClient;
        private readonly GeminiOptions _options;

        public GeminiClient(HttpClient httpClient, GeminiOptions options)
        {
            _httpClient = httpClient;
            _options = options;
        }

        public async Task<string> SummarizeActAsync(string actText)
        {
            var prompt = """
                Przeczytaj poniższy projekt ustawy i wytłumacz go prostym, zrozumiałym językiem dla zwykłego obywatela.
                Wyjaśnij:
                - czego dotyczy projekt,
                - jakie są najważniejsze zmiany,
                - kogo to dotyczy,
                - jakie mogą być praktyczne skutki.

                Używaj krótkich zdań i unikaj prawniczego żargonu.

                Tekst ustawy:
                """ + Environment.NewLine + actText;

            var requestBody = new GeminiRequest
            {
                Contents = new[]
                {
            new GeminiContent
            {
                Parts = new[]
                {
                    new GeminiPart { Text = prompt }
                }
            }
        }
            };

            // NA SZTYWNO model na test
            var model = "gemini-2.5-flash";

            var url = $"https://generativelanguage.googleapis.com/v1beta/models/{model}:generateContent?key={_options.ApiKey}";

            Console.WriteLine("Gemini URL: " + url);

            var response = await _httpClient.PostAsJsonAsync(url, requestBody);

            var raw = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Gemini status: " + (int)response.StatusCode + " " + response.StatusCode);
            Console.WriteLine("Gemini body: " + raw);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Gemini error {(int)response.StatusCode}: {raw}");
            }

            var responseBody = JsonSerializer.Deserialize<GeminiResponse>(raw);

            var text = responseBody?
                .Candidates?
                .FirstOrDefault()?
                .Content?
                .Parts?
                .FirstOrDefault()?
                .Text;

            return text ?? string.Empty;
        }

        // --- DTO do JSON ---

        private class GeminiRequest
        {
            [JsonPropertyName("contents")]
            public GeminiContent[] Contents { get; set; } = Array.Empty<GeminiContent>();
        }

        private class GeminiContent
        {
            [JsonPropertyName("parts")]
            public GeminiPart[] Parts { get; set; } = Array.Empty<GeminiPart>();
        }

        private class GeminiPart
        {
            [JsonPropertyName("text")]
            public string Text { get; set; } = string.Empty;
        }

        private class GeminiResponse
        {
            [JsonPropertyName("candidates")]
            public Candidate[]? Candidates { get; set; }
        }

        private class Candidate
        {
            [JsonPropertyName("content")]
            public GeminiContent? Content { get; set; }
        }
    }
}
