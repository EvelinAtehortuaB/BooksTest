using DataAccess.DTOs.Request;
using DataAccess.DTOs.Response;
using DataAccess.Implementation;
using Logic.Contracts;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Logic.Implementation
{
    public  class BookLogic: IBookLogic
    {
        #region [ Attributes ]
        private IUnitOfWork _unitOfWork;
        private readonly IEditorialLogic _editorialLogic;
        #endregion [ Attributes ]

        #region [ Constructor ]
        public BookLogic(IUnitOfWork unitOfWork, IEditorialLogic editorialLogic)
        {
            _unitOfWork = unitOfWork;
            _editorialLogic = editorialLogic;
        }
        #endregion [ Constructor ]


        #region [ Methods ]
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="source">BookRQ object</param>
        /// <returns>BookRS object</returns>
        public async Task<BookRS> AddAsync(BookRQ source)
        {
            try
            {
                var isInsert = await ValidateAsync(source.EditorialId);
                if (source != null && isInsert)
                {
                    var _book = ToDomain(source);
                    _book.Active = true;
                    _book.CreatedDate = DateTime.Now;

                    if (_book != null)
                    {
                        await _unitOfWork.Book.AddAsync(_book);
                        await _unitOfWork.SaveAsync();
                        await _unitOfWork.CommitAsync();
                        return ToDto(_book);
                    }
                }

                return null;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
                return null;
            }
        }

        /// <summary>
        /// Get user by expression
        /// </summary>
        /// <param name="expression">Where for get user</param>
        public async Task<IEnumerable<BookRS>> GetAsync(Expression<Func<Book, bool>> expression)
        {
            var data = await _unitOfWork.Book.GetAsync(expression);
            if (data != null && data.Any())
            {
                var _result = data.Select(x => ToDto(x));
                return _result;
            }
            else
                return null;
        }

        /// <summary>
        /// Get user by author or title or year
        /// </summary>
        /// <param name="value">Author name or title name or year</param>
        /// <returns>BookRS IEnumerable</returns>
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

        private Book ToDomain(BookRQ dto)
        {
            if (dto != null)
            {
                return new Book
                {
                    Title = dto.Title,
                    Year = dto.Year,
                    Gender = dto.Gender,
                    PageNumber = dto.PageNumber,
                    EditorialId = dto.EditorialId,
                    AuthorId = dto.AuthorId
                };
            }
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
                    EditorialName = entity.Editorial?.Name,
                    AuthorName = entity.Author?.Name
                };
            }
            return null;
        }

        private async Task<bool> ValidateAsync(int editorialId)
        {
            var maximumAllowed = await _editorialLogic.GetMaximumAllowedAsync(editorialId);
            var booksEditorial = await GetAsync(x => x.EditorialId == editorialId);
            var countBooks = booksEditorial.Count();
            return maximumAllowed < countBooks;

        }

        #endregion
    }
}
