namespace EventCase_Part2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VenueSM")]
    public partial class VenueSM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VenueSM()
        {
            BookingSMs = new HashSet<BookingSM>();
            Event_ = new HashSet<Event_>();
        }

        [Key]
        public int VenueID { get; set; }

        [Required]
        [StringLength(350)]
        public string VenueName { get; set; }

        [Required]
        [StringLength(350)]
        public string Location { get; set; }

        public int Capacity { get; set; }

        [StringLength(500)]
        public string Image_Url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingSM> BookingSMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event_> Event_ { get; set; }
    }
}
