namespace Test3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USERS
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string USERNAME { get; set; }

        [Required]
        [StringLength(100)]
        public string PASS { get; set; }

        [Required]
        [StringLength(20)]
        public string ROLE { get; set; }

        public virtual DOCTOR DOCTOR { get; set; }

        public virtual SPORTSMENS SPORTSMENS { get; set; }

        public virtual TRENER TRENER { get; set; }
    }
}
