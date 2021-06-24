using FluentAssertions;
using Moq;
using Nibo.ConciliatorOFX.Application.API.Services;
using Nibo.ConciliatorOFX.Data.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;
using System.Collections.Generic;
using Xunit;

namespace Nibo.ConciliatorOFX.ApplicationTests.Services
{
    public class OfxConciliateTests : BaseServiceTests
    {
        [Fact]
        public void Convert_OfxFile_ReturnsBankStatementDTO()
        {
            // Arrange
            var ofxConciliateMock = new Mock<IOfxConciliate>();

            ofxConciliateMock
                .Setup(s => s.Conciliate(It.IsAny<List<BankStatement>>()))
                .Returns(_listBankTransactionDTO);

            var ofxConciliate = ofxConciliateMock.Object;

            var bankTransactionsList = ConcatAllBackTransactios(_listBankStatements);

            // Act
            List<BankTransactionDTO> actualBankTransactions = ofxConciliate.Conciliate(_listBankStatements);

            // Assert
            actualBankTransactions
                .Should()
                .HaveCount(8);
        }
    }
}
