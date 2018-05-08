namespace Test3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOCTOR")]
    public partial class DOCTOR
    {
        [Key]
        [Column("DOCTOR")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DOCTOR1 { get; set; }

        public int? USER_ID { get; set; }

        [StringLength(20)]
        public string DOCTOR_NAME { get; set; }

        [StringLength(20)]
        public string DOCTOR_FAMIL { get; set; }

        [StringLength(20)]
        public string DOCTOR_MIDDLE { get; set; }

        [Required]
        [StringLength(20)]
        public string OSMOTR { get; set; }

        public virtual OSMOTR OSMOTR1 { get; set; }

        public virtual USERS USERS { get; set; }
    }
}
