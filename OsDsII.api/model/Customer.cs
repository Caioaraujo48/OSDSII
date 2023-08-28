using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace OsDsII.api.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [PrimaryKey(nameof(Id))]
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set;}

        [Required]
        [StringLength(60)]
        [Column("name")]
        [NotNull]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [Column("email")]
        public string Email { get; set; }
        
        [Required]
        [StringLength(20)]
        [Column("phone")]
        public string Phone { get; set; }
    }
}