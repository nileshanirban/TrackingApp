using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriggerApp.AuthticationHelper
{
    public class AzureAdOptions
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string AuthEndpoint { get; set; }

        public string Domain { get; set; }

        public string TenantId { get; set; }

        public string CallbackPath { get; set; }
    }
}
