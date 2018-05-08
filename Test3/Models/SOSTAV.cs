namespace Test3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SOSTAV")]
    public partial class SOSTAV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SOSTAV()
        {
            GROUPS = new HashSet<GROUPS>();
            OSMOTR = new HashSet<OSMOTR>();
            TRENEROVKA = new HashSet<TRENEROVKA>();
        }

        [Key]
        [Column("SOSTAV")]
        [StringLength(10)]
        public string SOSTAV1 { get; set; }

        [StringLength(20)]
        public string SOSTAV_NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GROUPS> GROUPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OSMOTR> OSMOTR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRENEROVKA> TRENEROVKA { get; set; }
    }
}
