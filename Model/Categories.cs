﻿using System.ComponentModel.DataAnnotations;

namespace EjemploEnClase.Model
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        
    }
}
