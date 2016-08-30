using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Diabhelp.Core.Api.ResponseModels
{
    public class LoginResponseBody
    {
        public bool success { get; set; }
        public string sessid { get; set; }
        public int id_user { get; set; }
        public List<string> errors { get; set; }
        public List<string> role { get; set; }
    }
}
