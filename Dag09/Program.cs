using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Dag9
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = JsonConvert.DeserializeObject<List<HashChain>>(File.ReadAllText("Input\\input-hashchain.json"));
            var firstHash = MD5Hash("julekalender");

            var message = "";

            while (input.Count > 0)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    var hash = input[i];
                    var newHash = MD5Hash($"{firstHash}{hash.Ch}");
                    if (newHash == hash.Hash)
                    {
                        firstHash = newHash;
                        message += hash.Ch;
                        input.RemoveAt(i);
                        break;
                    }
                }
            } 
            
            Console.WriteLine(message);
            Console.Read();
        }

        public static string MD5Hash(string input)
        {
            var hash = new StringBuilder();
            var md5provider = new MD5CryptoServiceProvider();
            var bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }

            return hash.ToString();
        }
    }

    public class HashChain
    {
        public string Ch { get; set; }
        public string Hash { get; set; }
    }
}
