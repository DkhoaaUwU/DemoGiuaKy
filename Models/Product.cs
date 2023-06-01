﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;

namespace DemoGiuaKy.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        [StringLength(500)]
        public string? ProductDescription { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
        [StringLength(50)]
        public string? ProductImage { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
