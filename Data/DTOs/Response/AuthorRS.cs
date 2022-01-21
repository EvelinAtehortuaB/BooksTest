using System;

namespace DataAccess.DTOs.Response
{
    public class AuthorRS
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }
}
