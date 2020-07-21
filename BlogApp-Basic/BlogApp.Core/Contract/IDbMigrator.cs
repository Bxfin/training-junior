using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Contract
{
    public interface IDbMigrator
    {
        Task RunAsync();
    }
}
