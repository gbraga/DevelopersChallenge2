namespace Nibo.ConciliatorOFX.ApplicationTests.Services
{
    public abstract class BaseServiceTests
    {
        protected string ReadOfxFileIntoString(string filename) =>
            System.Text.Encoding.Default.GetString(Resources.extrato1);
    }
}
