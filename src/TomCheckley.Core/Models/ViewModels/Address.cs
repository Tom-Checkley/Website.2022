using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ViewModels
{
    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string TownCity { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }

        public bool HasAddress()
        {
            return !AddressLine1.IsNullOrWhiteSpace()
                || !AddressLine2.IsNullOrWhiteSpace()
                || !TownCity.IsNullOrWhiteSpace()
                || !County.IsNullOrWhiteSpace()
                || !Postcode.IsNullOrWhiteSpace();
        }
    }
}
