using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerCA.Core.Services
{
    public class VerificationCode
    {
        public int VerificationCodeNumber { get; set; }

        public VerificationCode(int numberOfDigits)
        {
            Random r = new Random();
            int[] verificationCodeArray = new int[numberOfDigits];

            for (int i = 0; i < numberOfDigits; i++)
            {
                verificationCodeArray[i] = r.Next(1, 10);
            }
            string vc = string.Join("", verificationCodeArray);

            VerificationCodeNumber = Int32.Parse(vc);
        }
    }
}
