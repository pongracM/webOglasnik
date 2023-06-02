using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace webOglasnik.Misc
{
    public static class PasswordHelper
    {
        public static string IzracunajHash(string password)
        {
            var sBytes = new UTF8Encoding().GetBytes(password);
            byte[] hBytes;
            using (var alg = new System.Security.Cryptography.SHA256Managed())
            {
                hBytes = alg.ComputeHash(sBytes);
            }
            return Convert.ToBase64String(hBytes);
        }
    }
}