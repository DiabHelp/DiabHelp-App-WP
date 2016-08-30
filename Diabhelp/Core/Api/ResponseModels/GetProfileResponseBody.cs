using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabhelp.Core.Api.ResponseModels
{
    public class GetProfileResponseBody
    {
        public bool success { get; set; }
        public User user { get; set; }
        public class User
        {
            public object profilePictureFile { get; set; }
            public string profilePicturePath { get; set; }
            public string profilePictureAbsolutePath { get; set; }
            public string webProfilePicturePath { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string organisme { get; set; }
            public string phone { get; set; }
            public int birthdate { get; set; }
            public int id { get; set; }
            public string username { get; set; }
            public string usernameCanonical { get; set; }
            public string salt { get; set; }
            public string email { get; set; }
            public string emailCanonical { get; set; }
            public string password { get; set; }
            public object plainPassword { get; set; }
            public object lastLogin { get; set; }
            public object confirmationToken { get; set; }
            public List<string> roles { get; set; }
            public bool accountNonExpired { get; set; }
            public bool accountNonLocked { get; set; }
            public bool credentialsNonExpired { get; set; }
            public bool credentialsExpired { get; set; }
            public bool enabled { get; set; }
            public bool expired { get; set; }
            public bool locked { get; set; }
            public bool superAdmin { get; set; }
            public object passwordRequestedAt { get; set; }
            public List<string> groups { get; set; }
            public List<string> groupNames { get; set; }
        }
    }
}
