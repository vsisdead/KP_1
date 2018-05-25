namespace Test3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USERS
    {
        [Key]
        [StringLength(100)]
        public string USERNAME { get; set; } // primary key ������� USERS. ������ ����� ������������.

        [Required]
        [StringLength(100)]
        public string PASS { get; set; } // ������ ������ ������������.

        [Required]
        [StringLength(20)]
        public string ROLE { get; set; } // ������ ���� ������������.

        public int? STATUS { get; set; } // ������ ������ ������������.
    }
}
