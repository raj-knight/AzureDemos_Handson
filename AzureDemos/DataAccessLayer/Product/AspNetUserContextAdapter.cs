using DomainLayer;
using DomainLayer.Prdct;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Prdct
{

    public class AspNetUserContextAdapter : IUserContext
    {
        private static HttpContextAccessor Accessor = new HttpContextAccessor();

        public bool IsInRole(Role role)
        {
            return Accessor.HttpContext.User.IsInRole(role.ToString());
        }
    }

}
