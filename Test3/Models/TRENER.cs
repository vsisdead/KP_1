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
        [Column("TRENER")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TRENER1 { get; set; }

        public int? USER_ID { get; set; }

        [StringLength(20)]
        public string TRENER_FAMIL { get; set; }

        [StringLength(20)]
        public string TRENER_NAME { get; set; }

        [StringLength(20)]
        public string TRENER_MIDDLE { get; set; }

        [Required]
        [StringLength(10)]
        public string TRENEROVKA { get; set; }

        public virtual TRENEROVKA TRENEROVKA1 { get; set; }

        public virtual USERS USERS { get; set; }
    }
}
