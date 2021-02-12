using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerCA.Core.Interfaces
{
    public abstract class BaseCommand
    {
        public bool? isValid { get; internal set; }
    }
}
