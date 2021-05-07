using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace GitHubExplorer
{
	public class Secrets{ public string Token{ get; set; }
    }

        internal static class Program
    {
        static readonly HttpClient httpClient = new HttpClient();

        const string myUserName = "xaLi112";
        static string token;
        
        static Secrets LoadAndValidateSecrets(){
            Secrets secrets;
            if (!File.Exists("secrets.json")){
                secrets = new Secrets();
                File.WriteAllText("secrets.json", JsonSerializer.Serialize(secrets));
            }
 		else{
                secrets = JsonSerializer.Deserialize<Secrets>(File.ReadAllText("secrets.json"));
            }
		if (!string.IsNullOrEmpty(secrets?.Token)) return secrets;
            	throw new Exception($@"ERROR: Needs to define a token in file {Path.Combine(System.Environment 
                .CurrentDirectory, "secrets.json")}");
        }
	static string[] StringSplit(this string stringToSplit)
        {
            var splitString = stringToSplit.Split(",");
            
            return splitString;
        }
}
