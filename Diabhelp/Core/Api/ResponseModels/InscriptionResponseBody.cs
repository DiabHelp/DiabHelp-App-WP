using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Diabhelp.Core.Api.ResponseModels
{
    public class InscriptionResponseBody
    {
        public bool success { get; set; }
        public List<string> errors { get; set; }
    }
}
