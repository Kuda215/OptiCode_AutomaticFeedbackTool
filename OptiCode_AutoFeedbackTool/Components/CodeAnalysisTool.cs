using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static OptiCode_AutoFeedbackTool.Components.Pages.CodeSubmission;

public class CodeAnalysisTool
{
    private static readonly HttpClient client = new HttpClient();

    public static CodeAnalysisResult AnalyzeDuplicacy(string src)
    {
        string[] linesOfCode = src.Split(new[] { "\r\n" }, StringSplitOptions.None);
        var snippetOccurrences = new Dictionary<string, int>();
        var suggestions = new List<string>();

        for (int i = 0; i < linesOfCode.Length; i++)
        {
            string trimmedLine = linesOfCode[i].Trim();

            if (string.IsNullOrEmpty(trimmedLine))
                continue;

            if (snippetOccurrences.ContainsKey(trimmedLine))
            {
                snippetOccurrences[trimmedLine]++;
            }
            else
            {
                snippetOccurrences[trimmedLine] = 1;
            }
        }

        // Prepare the result arrays
        var codeSnippets = new List<string>();
        var occurrences = new List<int>();
        var textSuggestions = new List<string>();

        foreach (var kvp in snippetOccurrences)
        {
            codeSnippets.Add(kvp.Key);
            occurrences.Add(kvp.Value);
            textSuggestions.Add($"Consider refactoring line: {kvp.Key}");
        }

        return new CodeAnalysisResult
        {
            CodeSnippets = codeSnippets.ToArray(),
            Occurrences = occurrences.ToArray(),
            TextSuggestions = textSuggestions.ToArray()
        };
    }

    public static int CalculateCyclomaticComplexity(string code)
    {
        string[] controlFlowKeywords = { "if", "for", "while", "case", "catch", "else", "switch" };

        string[] lines = code.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        int decisionPointCount = 0;

        foreach (var line in lines)
        {
            if (controlFlowKeywords.Any(keyword => line.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
            {
                decisionPointCount++;
            }
        }

        int cyclomaticComplexity = decisionPointCount + 1;
        return cyclomaticComplexity;
    }

    private int LevenshteinDistance(string str1, string str2)
    {
        int len1 = str1.Length;
        int len2 = str2.Length;
        int[,] distance = new int[len1 + 1, len2 + 1];

        for (int i = 0; i <= len1; distance[i, 0] = i++) ;
        for (int j = 0; j <= len2; distance[0, j] = j++) ;

        for (int i = 1; i <= len1; i++)
        {
            for (int j = 1; j <= len2; j++)
            {
                int cost = (str1[i - 1] == str2[j - 1]) ? 0 : 1;
                distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
            }
        }

        return distance[len1, len2];
    }

    public List<string> DetectDuplicatedCode(string sourceCode, int threshold = 10)
    {
        List<string> duplicates = new List<string>();
        string[] lines = sourceCode.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

        var codeBlocks = new List<string>();
        string currentBlock = string.Empty;
        foreach (var line in lines)
        {
            if (line.Trim().StartsWith("public") || line.Trim().StartsWith("private") || line.Trim().StartsWith("void"))
            {
                if (!string.IsNullOrEmpty(currentBlock))
                {
                    codeBlocks.Add(currentBlock);
                    currentBlock = string.Empty;
                }
            }
            currentBlock += line + Environment.NewLine;
        }

        for (int i = 0; i < codeBlocks.Count; i++)
        {
            for (int j = i + 1; j < codeBlocks.Count; j++)
            {
                int distance = LevenshteinDistance(codeBlocks[i], codeBlocks[j]);
                if (distance < threshold)
                {
                    duplicates.Add($"Duplicate found between block {i + 1} and block {j + 1}");
                }
            }
        }

        return duplicates;
    }

    public async Task<string> GetSummary(string lang, string codeSnippet)
    {
        List<String> dupl = DetectDuplicatedCode(codeSnippet);
        int com = CalculateCyclomaticComplexity(codeSnippet);
        dupl.Add(com.ToString());

        return dupl.ToString();
    }

    public async Task<string> GetGraphs(string lang, string codeSnippet)
    {
        List<String> dupl = DetectDuplicatedCode(codeSnippet);
        int com = CalculateCyclomaticComplexity(codeSnippet);
        dupl.Add(com.ToString());

        return dupl.ToString();

    }

    public async Task<string> GetSources(string lang, string codeSnippet)
    {
        List<String> dupl = DetectDuplicatedCode(codeSnippet);
        int com = CalculateCyclomaticComplexity(codeSnippet);
        dupl.Add(com.ToString());

        return dupl.ToString();
    }

}
