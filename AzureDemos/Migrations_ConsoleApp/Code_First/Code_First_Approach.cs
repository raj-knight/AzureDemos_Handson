using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations_ConsoleApp.Code_First
{
    internal class Code_First_Approach
    {
        // we need to create the database from the model (entities and context) by adding a migration
        // PM> add-migration CreateSchoolDB -Context SchoolContext

        // create the database using the update-database command in the Package Manager Console
        // PM> update-database –Context SchoolContext


    }
}
