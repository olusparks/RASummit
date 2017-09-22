using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileData.Classes
{
    class SharedFunctions
    {

        public static string GenerateMemberID()
        {
            Random rand = new Random();
            Char[] chr1 = new Char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            int charGenerated = rand.Next(chr1.Length - 4, chr1.Length);
            int charGenerated2 = rand.Next(chr1.Length - 2, chr1.Length);
            int numberGenerated = rand.Next(1, 10000);
            string MemberNumber = "MEM-" + chr1[charGenerated].ToString() + chr1[charGenerated2].ToString() + numberGenerated;
            return MemberNumber;
        }

        public static string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
    }
}
