using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Response
{
    public class BookRS
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Gender { get; set; }
        public int PageNumber { get; set; }
        public string EditorialName { get; set; }
        public string AuthorName { get; set; }
    }
}
