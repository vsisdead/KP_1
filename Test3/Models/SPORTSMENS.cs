namespace Test3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SPORTSMENS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int USER_ID { get; set; }

        [StringLength(20)]
        public string SOSTAV_NAME { get; set; }

        [StringLength(20)]
        public string SPORTSMEN_NAME { get; set; }

        [StringLength(20)]
        public string SPORTSMEN_FAMIL { get; set; }

        [StringLength(20)]
        public string SPORTSMEN_MIDDLE { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BDAY { get; set; }

        public virtual SOSTAV SOSTAV { get; set; }

        public virtual USERS USERS { get; set; }
    }
}
