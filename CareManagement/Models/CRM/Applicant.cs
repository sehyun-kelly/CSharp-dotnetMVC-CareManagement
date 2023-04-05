namespace CareManagement.Models.CRM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Applicant
    {
        public Applicant()
        {
            this.Assets = new HashSet<Asset>();
        }
        public Guid ApplicantId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactingNumber { get; set; }
        public string SharingInfo { get; set; }
        public double Income { get; set; }
        public string Employer { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
        //[ForeignKey("AssetType")]
        //public Guid AssetTypeId { get; set; }
        //[ForeignKey("AssetType1")]
        //public Guid AssetTypeId2 { get; set; }
        //[ForeignKey("AssetType2")]
        //public Guid AssetTypeId3 { get; set; }
        //[ForeignKey("AssetType3")]
        //public Guid AssetTypeId4 { get; set; }
    
        //public virtual AssetType? AssetType { get; set; }
        //public virtual AssetType? AssetType1 { get; set; }
        //public virtual AssetType? AssetType2 { get; set; }
        //public virtual AssetType? AssetType3 { get; set; }
    }
}
