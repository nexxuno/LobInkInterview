using LobInkInterview.Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace LobInkInterview.Services
{
    public class SignatureHandler : ISignatureHandler
    {
        private readonly string token = "lobtk2256";

        public bool CheckSignature(object signMe, string check)
        {
            return this.CreateSignature(signMe) == check;
        }

        public string CreateSignature(object signMe)
        {
            // create our HMACMD5 object using the token as it's key
            HMACMD5 hmacMD5 = new HMACMD5(Encoding.UTF8.GetBytes(token));

            // stringify the data
            string toSign = JsonSerializer.Serialize(signMe);
            
            // compute the hash for the stringified data and base 64 encode the hash
            byte[] hash = hmacMD5.ComputeHash(Encoding.UTF8.GetBytes(toSign));
            string signature = Convert.ToBase64String(hash);

            // remove the trailing = and return the signature
            return signature.TrimEnd('=');
        }
    }
}
