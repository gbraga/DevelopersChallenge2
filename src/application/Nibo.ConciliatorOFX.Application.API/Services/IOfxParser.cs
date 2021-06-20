﻿using Nibo.ConciliatorOFX.Application.API.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;

namespace Nibo.ConciliatorOFX.Application.API.Services
{
    public interface IOfxParser
    {
        public BankStatementDTO ConvertToBankStatement(string ofxFileContent);
    }
}
