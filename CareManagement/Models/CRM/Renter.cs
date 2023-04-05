using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CareManagement.Models.SCHDL;

namespace CareManagement.Models.CRM
{

    public class Renter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Renter()
        {
            this.Invoice = new HashSet<Invoice>();
            this.Assets = new HashSet<Asset>();
        }

        [Key]
        public Guid RenterId { get; set; }

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

        public string Email { get; set; }

        [Required]
        [Range(0, int.MaxValue)]  // No negative numbers
        public int RmNumber { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; } // reference for the FK

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset> Assets { get; set; }
    }
}
