using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerCA.SharedKernel
{
    /// <summary>
    /// 
    /// Interface to be used in every entity
    /// 
    /// </summary>
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}
