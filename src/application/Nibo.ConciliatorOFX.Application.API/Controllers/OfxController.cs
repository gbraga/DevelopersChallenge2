using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nibo.ConciliatorOFX.Application.API.DTOs;
using Nibo.ConciliatorOFX.Application.API.Services;
using Nibo.ConciliatorOFX.Data;
using Nibo.ConciliatorOFX.Domain.Entities;
using Nibo.ConciliatorOFX.Domain.Models;
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
    public class OfxController : MainController
    {
        private readonly IOfxParser _ofxParser;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBankStatementRepository _bankStatementRepository;
        private readonly IMapper _mapper;

        public OfxController(
            IOfxParser ofxParser,
            IUnitOfWork unitOfWork,
            IBankStatementRepository bankStatementRepository,
            IMapper mapper)
        {
            _ofxParser = ofxParser;
            _unitOfWork = unitOfWork;
            _bankStatementRepository = bankStatementRepository;
            _mapper = mapper;
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

                try
                {
                    var bankStatement = _mapper.Map<BankStatement>(bankStatementDTO);
                    _bankStatementRepository.Save(bankStatement);
                    _unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    return CustomResponse(ex.Message);
                }
            }

            return CustomResponse();
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<BankStatement>>> Get()
        {
            var bankStatement = await _bankStatementRepository.Get();

            return Ok(bankStatement);
        }

        [HttpPost("Conciliation")]
        public async Task<IActionResult> Conciliation([FromBody] int[] bankStatementIds)
        {
            var bankStatement = await _bankStatementRepository.Conciliation(bankStatementIds);

            return Ok(bankStatement);
        }
    }
}
