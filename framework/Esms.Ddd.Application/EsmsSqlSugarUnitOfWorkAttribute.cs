using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esms.Ddd.Application
{
    public class EsmsSqlSugarUnitOfWorkAttribute: Attribute
    {
        public bool IsEnable { get; set; } = true;
    }
}
