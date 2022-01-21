using DataAccess.DTOs.Response;
using DataAccess.Implementation;
using Logic.Contracts;
using Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.Implementation
{
    public  class BookLogic: IBookLogic
    {
        #region [ Attributes ]
        private IUnitOfWork _unitOfWork;
        #endregion [ Attributes ]

        #region [ Constructor ]
        public BookLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion [ Constructor ]


        #region [ Methods ]
        /// <summary>
        /// Get user by author or title or year
        /// </summary>
        /// <param name="value">Author name or title name or year</param>
        public async Task<IEnumerable<BookRS>> GetForValueAsync(string value)
        {
            var data = await _unitOfWork.Book.GetAsync(x => x.Author.Name.Contains(value) || x.Title.Contains(value) || x.Year == value, includeProperties: "Editorial,Author");
            if (data != null && data.Any())
            {
                var _result = data.Select(x => ToDto(x));
                return _result;
            }
            else
                return null;
        }

        private BookRS ToDto(Book entity)
        {
            if (entity != null)
            {
                return new BookRS
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Year = entity.Year,
                    Gender = entity.Gender,
                    PageNumber = entity.PageNumber,
                    EditorialName = entity.Editorial.Name,
                    AuthorName = entity.Author.Name
                };
            }
            return null;
        }

        #endregion
    }
}
