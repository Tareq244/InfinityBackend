﻿using System.ComponentModel.DataAnnotations;

namespace InfinityBack.dataBase
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
