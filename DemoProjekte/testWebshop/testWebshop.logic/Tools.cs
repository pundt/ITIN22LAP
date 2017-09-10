using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using testITIN22.data;

namespace testWebshop.logic
{
    public class Tools
    {
        public static byte[] ErmittleHashWert(string klartext)
        {
            byte[] hashWert = null;

            SHA512 sha = SHA512.Create();
            byte[] klartextBytes = UTF8Encoding.UTF8.GetBytes(klartext);
            hashWert = sha.ComputeHash(klartextBytes);
            return hashWert;
        }
    }
}
