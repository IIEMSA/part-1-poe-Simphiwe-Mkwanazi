namespace EventCase_Part2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookingSM")]
    public partial class BookingSM
    {
        [Key]
        public int BookingID { get; set; }

        public int EventID { get; set; }

        public int VenueID { get; set; }

        [Column(TypeName = "date")]
        public DateTime BookingDate { get; set; }

        public virtual Event_ Event_ { get; set; }

        public virtual VenueSM VenueSM { get; set; }
    }
}
