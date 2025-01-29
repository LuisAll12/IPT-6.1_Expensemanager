using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensesmanager
{
    public class UserDataContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    }
}
