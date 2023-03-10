using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListAsset.DataAccess.Models
{
    public class Asset
    {
        public Guid AssetId { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string AssetType { get; set; }
        public int Quantity { get; set; }

        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
