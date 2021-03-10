using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerCA.Core.Interfaces
{
    public interface IPasswordEncrypt
    {
        string EncryptPassword(string key, string plainText);
        string DecryptPassword(string key, string cypherText);
    }
}
