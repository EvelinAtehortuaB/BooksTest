using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Implementation
{
    [Table("Authors")]
    public class Author
    {
        [Key]
        [Required]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("City")]
        public string City { get; set; }

        [Required]
        [MaxLength(300)]
        [Column("Email")]
        public string Email { get; set; }

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
