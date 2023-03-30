namespace CareManagement.Models.CRM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Asset
    {
        public Guid AssetId { get; set; }
        public string Description { get; set; }
        public int AssetTypeId { get; set; }
        public int RenterId { get; set; }
        public string PlateNumber { get; set; }
        public string SuiteNo { get; set; }
    
        public virtual AssetType AssetType { get; set; }
        public virtual Renter Renter { get; set; }
    }
}
