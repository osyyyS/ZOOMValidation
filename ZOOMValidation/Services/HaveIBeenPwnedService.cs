using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZOOMValidation.Extensions;

namespace ZOOMValidation.Services
{
    internal class HaveIBeenPwnedService : IPasswordService
    {
        private const string API_ROUTE = "https://api.pwnedpasswords.com/range/";
        public async Task<bool> IsSecure(string password)
        {
            try
            {
                string sha1Hash = password.ToSha1Hash();
                string hashPrefix = sha1Hash.Substring(0, 5);

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(API_ROUTE + hashPrefix);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        string[] lines = responseContent.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                        string fullHashSuffix = sha1Hash.Substring(5).ToUpper();

                        foreach (string line in lines)
                        {
                            string[] parts = line.Split(':');
                            string hashSuffix = parts[0].ToUpper();

                            if (hashSuffix == fullHashSuffix)
                            {
                                return false;
                            }
                        }

                        return true;
                    }
                }                
            }
            catch (ArgumentException)
            {
                return false;
            }            
            return false;
        }
    }
}
