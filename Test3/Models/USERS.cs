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
        public string USERNAME { get; set; } // primary key таблицы USERS. Хранит логин пользователя.

        [Required]
        [StringLength(100)]
        public string PASS { get; set; } // Хранит пароль пользователя.

        [Required]
        [StringLength(20)]
        public string ROLE { get; set; } // Хранит роль пользователя.

        public int? STATUS { get; set; } // Хранит статус пользователя.
    }
}
