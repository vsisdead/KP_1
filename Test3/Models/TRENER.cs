namespace Test3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRENER")]
    public partial class TRENER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int USER_ID { get; set; }

        [StringLength(20)]
        public string TRENER_FAMIL { get; set; }

        [StringLength(20)]
        public string TRENER_NAME { get; set; }

        [StringLength(20)]
        public string TRENER_MIDDLE { get; set; }

        [Required]
        [StringLength(20)]
        public string TRENEROVKA_NAME { get; set; }

        public virtual TRENEROVKA TRENEROVKA { get; set; }
    }
}
