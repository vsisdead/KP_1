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
        public int IDSPORTSMEN { get; set; }

        public int? USER_ID { get; set; }

        public int IDGROUP { get; set; }

        [StringLength(20)]
        public string SPORTSMEN_NAME { get; set; }

        [StringLength(20)]
        public string SPORTSMEN_FAMIL { get; set; }

        [StringLength(20)]
        public string SPORTSMEN_MIDDLE { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BDAY { get; set; }

        public virtual GROUPS GROUPS { get; set; }

        public virtual USERS USERS { get; set; }
    }
}
