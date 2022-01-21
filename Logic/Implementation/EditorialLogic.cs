using DataAccess.DTOs.Request;
using DataAccess.DTOs.Response;
using DataAccess.Implementation;
using Logic.Contracts;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementation
{
    public class EditorialLogic: IEditorialLogic
    {
        #region [ Attributes ]
        private IUnitOfWork _unitOfWork;
        #endregion [ Attributes ]

        #region [ Constructor ]
        public EditorialLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion [ Constructor ]

        #region [ Methods ]
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="source">BookRQ object</param>
        /// <returns>BookRS object</returns>
        public async Task<EditorialRS> AddAsync(EditorialRQ source)
        {
            try
            {
                if (source != null)
                {
                    var _editorial = ToDomain(source);
                    _editorial.Active = true;
                    _editorial.CreatedDate = DateTime.Now;

                    if (_editorial != null)
                    {
                        await _unitOfWork.Editorial.AddAsync(_editorial);
                        await _unitOfWork.SaveAsync();
                        await _unitOfWork.CommitAsync();
                        return ToDto(_editorial);
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
        /// Get maximum allowed by editorial
        /// </summary>
        /// <param name="id">Editorialo id</param>
        /// <returns>maximum allowed</returns>
        public async Task<int> GetMaximumAllowedAsync(int id)
        {
            var data = await _unitOfWork.Editorial.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                return data.MaximumBooks;
            }
            else
                return 0;
        }

        private Editorial ToDomain(EditorialRQ dto)
        {
            if (dto != null)
            {
                return new Editorial
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    Phone = dto.Phone,
                    Email = dto.Email,
                    MaximumBooks = (dto.MaximumBooks == 0 ? -1 : dto.MaximumBooks)
                };
            }
            return null;
        }

        private EditorialRS ToDto(Editorial entity)
        {
            if (entity != null)
            {
                return new EditorialRS
                {
                    Name = entity.Name,
                    Address = entity.Address,
                    Phone = entity.Phone,
                    Email = entity.Email,
                    MaximumBooks = entity.MaximumBooks
                };
            }
            return null;
        }
        #endregion
    }
}
