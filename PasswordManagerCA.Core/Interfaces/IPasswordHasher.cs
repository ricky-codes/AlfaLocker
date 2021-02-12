using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerCA.Core.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string password, int iterations);
        string Hash(string password);
        bool IsHashSupported(string hashString);
        bool Verify(string password, string hashedPassword);
    }
}
