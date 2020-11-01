using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Activity1Part3.Models;
using Activity1Part3.Services.Data;

namespace Activity1Part3.Services.Business
{
    public class SecurityService
    {
        public bool Authenticate(UserModel user) {
            SecurityDAO service = new SecurityDAO();
            return service.FindByUser(user); }
    }
}