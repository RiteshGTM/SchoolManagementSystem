using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.API.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        [Column("PersonId", TypeName = "UNIQUEIDENTIFIER")]
        [Display(Name = "Person Id", Description = "Person Id")]
        public Guid PersonId { get; set; }

        [Required]
        [Column("FirstName")]
        [MaxLength(50)]
        [Display(Name = "First Name", Description = "First name of the person")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Column("LastName")]
        [MaxLength(50)]
        [Display(Name = "Last Name", Description = "Last name of the person")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Column("Gender")]
        [MaxLength(10)]
        [Display(Name = "Gender", Description = "Gender of the person")]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [Column("DateOfBirth", TypeName = "DATE")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth", Description = "Birth date of the person")]
        public DateTime DateOfBirth { get; set; }

        [Column("Email")]
        [MaxLength(100)]
        [EmailAddress]
        [Display(Name = "Email", Description = "Email address of the person")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column("Phone")]
        [MaxLength(20)]
        [Phone]
        [Display(Name = "Phone", Description = "Contact number of the person")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [Column("AddressLine1")]
        [MaxLength(100)]
        [Display(Name = "Address Line 1", Description = "Primary address line")]
        public string AddressLine1 { get; set; } = string.Empty;

        [Column("AddressLine2")]
        [MaxLength(100)]
        [Display(Name = "Address Line 2", Description = "Secondary address line")]
        public string? AddressLine2 { get; set; }

        [Required]
        [Column("City")]
        [MaxLength(50)]
        [Display(Name = "City", Description = "City name")]
        public string City { get; set; } = string.Empty;

        [Required]
        [Column("State")]
        [MaxLength(50)]
        [Display(Name = "State", Description = "State name")]
        public string State { get; set; } = string.Empty;

        [Required]
        [Column("ZipCode")]
        [MaxLength(10)]
        [Display(Name = "Zip Code", Description = "Postal code")]
        public string ZipCode { get; set; } = string.Empty;

        [Required]
        [Column("Country")]
        [MaxLength(50)]
        [Display(Name = "Country", Description = "Country name")]
        public string Country { get; set; } = string.Empty;

        [Required]
        [Column("CreatedAt", TypeName = "DATETIME2")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Created At", Description = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //[Required]
        [Column("UpdatedAt", TypeName = "DATETIME2")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Updated At", Description = "Updated At")]
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
