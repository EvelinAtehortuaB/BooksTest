

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Implementation
{
    [Table("Editorials")]
    public class Editorial
    {
        [Key]
        [Required]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("Address")]
        public string Address { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("Phone")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(300)]
        [Column("Email")]
        public string Email { get; set; }

        [Required]
        [Column("MaximumBooks")]
        public int MaximumBooks { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("Active")]
        public bool Active { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }
    }
}
