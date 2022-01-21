using DataAccess.DTOs.Request;
using DataAccess.DTOs.Response;
using DataAccess.Implementation;
using Logic.Contracts;
using Repository.Contracts;
using System;
using System.Threading.Tasks;

namespace Logic.Implementation
{
    public class AuthorLogic: IAuthorLogic
    {
        #region [ Attributes ]
        private IUnitOfWork _unitOfWork;
        #endregion [ Attributes ]

        #region [ Constructor ]
        public AuthorLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion [ Constructor ]

        #region [ Methods ]
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="source">AuthorRQ object</param>
        /// <returns>AuthorRS object</returns>
        public async Task<AuthorRS> AddAsync(AuthorRQ source)
        {
            try
            {
                if (source != null)
                {
                    var _author = ToDomain(source);
                    _author.Active = true;
                    _author.CreatedDate = DateTime.Now;

                    if (_author != null)
                    {
                        await _unitOfWork.Author.AddAsync(_author);
                        await _unitOfWork.SaveAsync();
                        await _unitOfWork.CommitAsync();
                        return ToDto(_author);
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

        private Author ToDomain(AuthorRQ dto)
        {
            if (dto != null)
            {
                return new Author
                {
                    Name = dto.Name,
                    DateOfBirth = dto.DateOfBirth,
                    City = dto.City,
                    Email = dto.Email
                };
            }
            return null;
        }

        private AuthorRS ToDto(Author entity)
        {
            if (entity != null)
            {
                return new AuthorRS
                {
                    Name = entity.Name,
                    DateOfBirth = entity.DateOfBirth,
                    City = entity.City,
                    Email = entity.Email
                };
            }
            return null;
        }
        #endregion
    }
}
