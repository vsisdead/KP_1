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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int USER_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string DOCTOR_NAME { get; set; }

        [StringLength(20)]
        public string DOCTOR_FAMIL { get; set; }

        [StringLength(20)]
        public string DOCTOR_MIDDLE { get; set; }

        [Required]
        [StringLength(20)]
        public string OSMOTR_NAME { get; set; }

        public virtual OSMOTR OSMOTR { get; set; }
    }
}
