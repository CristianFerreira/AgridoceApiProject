using System.Collections.Generic;

namespace Agridoce.Domain.Configurations
{
    public class ClaimConfiguration
    {
        public ClaimConfiguration()
        {

        }

        public string Type { get; set; }
        public IEnumerable<string> Values { get; set; }
        public IEnumerable<string> AllowedBy { get; set; }
    }
}
