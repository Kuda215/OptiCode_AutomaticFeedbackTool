using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class CodeAnalysisTool
{
    private static readonly HttpClient client = new HttpClient();
    private const string apiKey = "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";

    public async Task<string> GetSummary(string lang, string codeSnippet)
    {
        using var client = new HttpClient();
        var prompt = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
        new { role = "system", content = "You are a highly intelligent code analysis tool that provides detailed evaluations of code quality metrics." },
        new { role = "user", content = $"Analyze the following {lang} code and provide a comprehensive summary. Make the justification atleast 3 sentences each." +
                $"The JSON response should include the following attributes, each with a score, justification, and instances:\n" +
                $"- overall\n" +
                $"- overall_complexity\n" +
                $"- code_readibility" +
                $"- code_structure\n" +
                $"- mantainability\n" +
                $"- data_structure_choice\n" +
                $"- error_handling\n" +
                $"- comment_coverage" +
                $"- duplicate_code\n" +
                $"-adherence_to_coding_standards" +
                $"\nEach attribute should have the following structure:\n" +
                " \"attributeAbove\":{\n" +
                "  \"score\": \"[Score]- scale from Not to Very relatively so .Dont be too harsh or strict , these are first time programmers\",\n" +
                "  \"justification\": \"[Justification ]\",\n" +
                "  \"instances\": [\n" +
                "    {\n" +
                "      \"code\": \"[Code snippet examples]\",\n" +
                "      \"insteadOf\": \"[Recommended alternative for each ]\"\n" +
                "    }\n" +
                "  ]\n" +
                "}\n" +
                "Return a json in this exact format: summary:{objects}.Do this exactly. Do not include any unecessay characters and words , remove ```json and ' characters , I want a pure json result" +
                $"Here is the Code:\n\n```{lang}\n{{{codeSnippet}}}\n```"
                }
            },
            max_tokens = 1400
        };
     
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(prompt);
        var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", requestContent);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetGraphs(string lang, string codeSnippet)
    {
        using var client = new HttpClient();
        var prompt = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
        new { role = "system", content = "You are a highly intelligent data visualization tool that generates structured graph data for code analysis." },
        new { role = "user", content = $"Generate structured graph data for the following {lang} code analysis:\n\n```{lang}\n{{{codeSnippet}}}\n```" },
        new { role = "user", content = "Ensure the response is always a valid JSON in the following format. MAKE IT complete ,check, result should always have the last ]}} at the end.:\n" +
            "Do this exactly. Do not include any unnecessary characters and words, remove ```json and ' characters, I want a pure json result." +
            "\"graphs\":{\n" +
                "  \"graph1\":{\n" +
                "    \"type\": \"line-graph\",\n" +
                "    \"title\": \"Progress Over Time\",\n" +
                "    \"y-title\": \"Scores\",\n" +
                "    \"x-title\": \"Submission Dates\",\n" +
                "    \"y-axis\": [75, 80, 85, 90, 95],\n" +
                "    \"x-axis\": [\"2024-01-01\", \"2024-01-15\", \"2024-02-01\", \"2024-02-15\", \"2024-03-01\"],\n" +
                "    \"bottom_text\": \"Progress over time shows improvement in coding skills.\", \n " +
                "    \"data-point-labels\": [\"Submission 1\", \"Submission 2\", \"Submission 3\", \"Submission 4\", \"Submission 5\"]\n " +
                "  },\n" +
                "  \"graph2\": {\n" +
                "    \"type\": \"bar-graph\",\n" +
                "    \"title\": \"Common Issues Frequency\",\n" +
                "    \"y-title\": \"Number of Instances\",\n" +
                "    \"x-title\": \"Common Issues\",\n" +
                "    \"y-axis\": [5, 10, 3, 8],\n" +
                "    \"x-axis\": [\"Inefficient Loops\", \"Poor Naming\", \"Code Duplication\", \"Error Handling\"],\n" +
                "    \"bottom_text\": \"Identifies trends in mistakes made by the student.\", \n" +
                "    \"data-point-labels\": [\"Mistake 1\", \"Mistake 2\", \"Mistake 3\", \"Mistake 4\"]\n " +
                "  },\n" +
                "   \"graph3\":{\n" +
                "    \"type\": \"line-graph\",\n" +
                "    \"title\": \"Time Complexity Analysis\",\n" +
                "    \"y-title\": \"Time Complexity\",\n" +
                "    \"x-title\": \"Submission Dates\",\n" +
                "    \"y-axis\": [1, 2, 3],\n" + // Numeric representation of time complexities
                "    \"x-axis\": [\"2024-01-01\", \"2024-01-15\", \"2024-02-01\"],\n" +
                "    \"bottom_text\": \"Tracks the efficiency of algorithms over time.\",\n" +
                "    \"data-point-labels\": [\"Submission 1\", \"Submission 2\", \"Submission 3\"]\n " +
                "  },\n" +
                "  \"graph4\": {\n" +
                "    \"type\": \"area-graph\",\n" +
                "    \"title\": \"Learning Curve\",\n" +
                "    \"y-title\": \"Cumulative Score\",\n" +
                "    \"x-title\": \"Submission Dates\",\n" +
                "    \"y-axis\": [50, 70, 80, 90, 100],\n" +
                "    \"x-axis\": [\"2024-01-01\", \"2024-01-15\", \"2024-02-01\", \"2024-02-15\", \"2024-03-01\"],\n" +
                "    \"bottom_text\": \"Shows cumulative score improvements over time.\", \n" +
                "    \"data-point-labels\": [\"Submission 1\", \"Submission 2\", \"Submission 3\", \"Submission 4\", \"Submission 5\"]\n " +
                "  },\n" +
                "  \"graph5\": {\n" +
                "    \"type\": \"radar-chart\",\n" +
                "    \"title\": \"Feature Usage Analysis\",\n" +
                "    \"y-title\": \"Proficiency Level (0-10)\",\n" +
                "    \"x-title\": \"Programming Features\",\n" +
                "    \"y-axis\": [8, 6, 7, 9, 5],\n" +
                "    \"x-axis\": [\"Loops\", \"Functions\", \"Data Structures\", \"Error Handling\", \"Comments\"],\n" +
                "    \"bottom_text\": \"Visualizes strengths and weaknesses in coding skills.\", \n" +
                "    \"data-point-labels\": [\"Loops\", \"Functions\", \"Data Structures\", \"Error Handling\", \"Comments\"]\n " +
                "  }\n" +
                "}" }
    },
            max_tokens = 1200
        };


        var json = Newtonsoft.Json.JsonConvert.SerializeObject(prompt);
        var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", requestContent);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetSources(string lang, string codeSnippet)
    {
        using var client = new HttpClient();
        var prompt = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new { role = "system", content = "You are a knowledgeable research assistant that provides structured references and sources for code analysis." },
                new { role = "user", content = $"Provide sources for the following {lang} code analysis:\n\n```{lang}\n{{{codeSnippet}}}\n```" },
                new { role = "user", content = "Ensure the response is in the following format:\n" +
                            "Do this exactly. Do not include any unecessay characters and words , remove ```json and ' characters , I want a pure json result" +
                    "  \"sites\":{\n" +
                    "    \"site1\": {\n" +
                    "      \"url\": \"[Website URL]\",\n" +
                    "      \"name\": \"[Website Name]\",\n" +
                    "      \"Key Findings\": \"[Summary of Key Findings]\"\n" +
                    "    },\n" +
                    "   \"site2\":  {\n" +
                    "      \"url\": \"[Website URL]\",\n" +
                    "      \"name\": \"[Website Name]\",\n" +
                    "      \"Key Findings\": \"[Summary of Key Findings]\"\n" +
                    "    },\n" +
                    "   \"site3\":  {\n" +
                    "      \"url\": \"[Website URL]\",\n" +
                    "      \"name\": \"[Website Name]\",\n" +
                    "      \"Key Findings\": \"[Summary of Key Findings]\"\n" +
                    "    }\n" +
                    "  },\n" +
                    "  \"books\":[\"[Book Title 1]\", \"[Book Title 2]\", \"[Book Title 3]\"],\n" +
                    "  \"Why Students should follow this\":\"[Reasons for students to follow these sources]\"\n" 
                   }
            },
            max_tokens = 1000
        };


        var json = Newtonsoft.Json.JsonConvert.SerializeObject(prompt);
        var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", requestContent);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

}
