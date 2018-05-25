namespace Test3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OSMOTR")]
    public partial class OSMOTR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OSMOTR()
        {
            DOCTOR = new HashSet<DOCTOR>();
        }

        [Key]
        [StringLength(20)]
        public string OSMOTR_NAME { get; set; }

        [StringLength(20)]
        public string SOSTAV_NAME { get; set; }

        [StringLength(20)]
        public string OSMOTR_DATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCTOR> DOCTOR { get; set; }

        public virtual SOSTAV SOSTAV { get; set; }
    }
}
