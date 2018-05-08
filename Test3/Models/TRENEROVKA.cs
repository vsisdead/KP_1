namespace Test3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRENEROVKA")]
    public partial class TRENEROVKA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRENEROVKA()
        {
            TRENER = new HashSet<TRENER>();
        }

        [Key]
        [Column("TRENEROVKA")]
        [StringLength(10)]
        public string TRENEROVKA1 { get; set; }

        [StringLength(20)]
        public string TRENEROVKA_NAME { get; set; }

        [Required]
        [StringLength(10)]
        public string SOSTAV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TRENEROVKA_DATE { get; set; }

        public TimeSpan? TRENEROVKA_TIME { get; set; }

        public virtual SOSTAV SOSTAV1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRENER> TRENER { get; set; }
    }
}
