using DataAccess.Common;
using DataAccess.DTOs.Request;
using DataAccess.DTOs.Response;
using DataAccess.Enums;
using Logic.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        #region [ Attributes ]
        private readonly IBookLogic _bookLogic;
        #endregion [ Attributes ]

        #region [ Constructor ]
        public BookController(IBookLogic bookLogic)
        {
            _bookLogic = bookLogic;
        }
        #endregion [ Constructor ]

        #region [ Methods ]
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="request">BookRQ object</param>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="204">Successfully request and do not return any content</response>
        /// <response code="400">The request is invalid</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] BookRQ request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _result = await _bookLogic.AddAsync(request);
                    if (_result != null)
                        return Ok(_result);
                    else
                        return NoContent();

                }
                return BadRequest(new { success = false, message = Messages.GetMessage(ResultCodes.ValidationError) });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, Messages.GetMessage(ResultCodes.InternalServerError));
            }
        }

        /// <summary>
        /// Get list
        /// </summary>
        /// <remarks>
        /// Get  all books by entered value 
        /// </remarks>
        /// <returns>BookRS list</returns>
        /// <response code="200">Ok</response>
        /// <response code="204">Successfully request and do not return any content</response>
        /// <response code="400">The request is invalid</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("GetForValue/{value}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookRS>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllAsync(string value)
        {
            try
            {
                var _data = await _bookLogic.GetForValueAsync(value);
                if (_data != null && _data.Any())
                {
                    return Ok(_data);
                }
                else
                    return NoContent();
            }
            catch 
            {
                return StatusCode(500, Messages.GetMessage(ResultCodes.InternalServerError));
            }
        }
        #endregion [ Methods ]
    }
}
