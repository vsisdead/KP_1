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
        [StringLength(20)]
        public string TRENEROVKA_NAME { get; set; } // ’ранит название тренеровки. явл€етс€ primary key.

        [StringLength(20)]
        public string SOSTAV_NAME { get; set; } // ’ранит название состава.

        [StringLength(20)]
        public string TRENEROVKA_DATE { get; set; } // ’ранит дату тренеровки.

        public virtual SOSTAV SOSTAV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRENER> TRENER { get; set; }
    }
}
