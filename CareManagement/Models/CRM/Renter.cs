using CareManagement.Models.SCHDL;


namespace CareManagement.Models.CRM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Renter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Renter()
        {
            this.Assets = new HashSet<Asset>();
        }
    
        public int RenterId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactingNumber { get; set; }
        public string EmergencyContactingNumber { get; set; }
        public string FamilyDoctor { get; set; }
        public string SharingInfo { get; set; }
        public double Income { get; set; }
        public string Employer { get; set; }
        [Required]
        [Range(0, int.MaxValue)]  // No negative numbers
        public int RmNumber;

        [Required]
        [ForeignKey("Invoice")]
        public int InvoiceNo { get; set; } // the actual FK in the table
        public virtual ICollection<Invoice> Invoice { get; set; } // reference for the FK

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset> Assets { get; set; }
    }
}
