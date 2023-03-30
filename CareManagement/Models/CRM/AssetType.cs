namespace CareManagement.Models.CRM
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssetType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AssetType()
        {
            this.Applicants = new HashSet<Applicant>();
            this.Applicants1 = new HashSet<Applicant>();
            this.Applicants2 = new HashSet<Applicant>();
            this.Applicants3 = new HashSet<Applicant>();
            this.Assets = new HashSet<Asset>();
        }
    
        public int AssetTypeId { get; set; }
        public string Name { get; set; }
        public int AvailableNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Applicant> Applicants { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Applicant> Applicants1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Applicant> Applicants2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Applicant> Applicants3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset> Assets { get; set; }
    }
}
