using System;

namespace AngularDOTNETCoreJWT.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
