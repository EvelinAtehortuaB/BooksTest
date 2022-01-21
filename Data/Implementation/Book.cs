using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Implementation
{
    [Table("Books")]
    public class Book
    {
        [Key]
        [Required]
        [Column("Id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(300)]
        [Column("Title")]
        public string Title { get; set; }

        [Required]
        [MaxLength(4)]
        [Column("Year")]
        public string Year { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("Gender")]
        public string Gender { get; set; }

        [Required]
        [Column("PageNumber")]
        public int PageNumber { get; set; }

        [Required]
        [Column("EditorialId")]
        [ForeignKey("Editorial")]
        public int EditorialId { get; set; }

        [Required]
        [Column("AuthorId")]
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("Active")]
        public bool Active { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        public virtual Editorial Editorial { get; set; }
        public virtual Author Author { get; set; }
    }
}
