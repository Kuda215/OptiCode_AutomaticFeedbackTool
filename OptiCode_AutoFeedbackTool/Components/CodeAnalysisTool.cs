using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class CodeAnalysisTool
{
    private static readonly HttpClient client = new HttpClient();

    public async Task<string> GetSummary(string lang, string codeSnippet)
    {
        
        return null;
    }

    public async Task<string> GetGraphs(string lang, string codeSnippet)
    {
        

        return null;
    }

    public async Task<string> GetSources(string lang, string codeSnippet)
    {
       
        return null;
    }

}
