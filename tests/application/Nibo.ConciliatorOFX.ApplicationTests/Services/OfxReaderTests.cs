using Nibo.ConciliatorOFX.Application.API.DTOs;
using Nibo.ConciliatorOFX.Application.API.Services;
using Xunit;

namespace Nibo.ConciliatorOFX.ApplicationTests.Services
{
    public class OfxReaderTests : BaseServiceTests
    {
        [Fact]
        public void Convert_OfxFile_ReturnsBankStatementDTO()
        {
            // Arrange
            var extrato1 = ReadOfxFileIntoString("extrato1");
            OfxReader ofxReader = new OfxReader();

            // Act
            BankStatementDTO actualBankTransactions = ofxReader.Convert(extrato1);

            // Assert
            Assert.NotNull(actualBankTransactions);
        }
    }
}
