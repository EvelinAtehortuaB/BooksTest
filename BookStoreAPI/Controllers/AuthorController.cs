using DataAccess.Common;
using DataAccess.DTOs.Request;
using DataAccess.Enums;
using Logic.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        #region [ Attributes ]
        private readonly IAuthorLogic _authorLogic;
        #endregion [ Attributes ]

        #region [ Constructor ]
        public AuthorController(IAuthorLogic authorLogic)
        {
            _authorLogic = authorLogic;
        }
        #endregion [ Constructor ]

        #region [ Methods ]
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="request">AuthorRQ object</param>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="204">Successfully request and do not return any content</response>
        /// <response code="400">The request is invalid</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] AuthorRQ request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _result = await _authorLogic.AddAsync(request);
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
        #endregion [ Methods ]
    }
}
