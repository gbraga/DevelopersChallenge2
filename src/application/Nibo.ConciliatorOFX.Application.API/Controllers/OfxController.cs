using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nibo.ConciliatorOFX.Application.API.DTOs;
using Nibo.ConciliatorOFX.Application.API.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nibo.ConciliatorOFX.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfxController : ControllerBase
    {
        private readonly IOfxParser _ofxParser;

        public OfxController(IOfxParser ofxParser)
        {
            _ofxParser = ofxParser;
        }

        [HttpPost("Import")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Import(IFormFile file, CancellationToken cancellationToken)
        {
            BankStatementDTO bankStatementDTO;

            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string decodedString = Encoding.UTF8.GetString(fileBytes);
                    bankStatementDTO = _ofxParser.ConvertToBankStatement(decodedString);
                }
            }

            return Ok();
        }
    }
}
