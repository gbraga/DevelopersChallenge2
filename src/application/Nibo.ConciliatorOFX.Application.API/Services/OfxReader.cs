using Nibo.ConciliatorOFX.Application.API.DTOs;
using Nibo.ConciliatorOFX.Application.API.Services.Factories;
using Nibo.ConciliatorOFX.Domain.Entities;
using System;
using System.IO;
using System.Xml;

namespace Nibo.ConciliatorOFX.Application.API.Services
{
    public class OfxReader : IOfxReader
    {
        public OfxReader()
        {

        }

        public BankTransactionsList ReadOfxFile(string filename)
        {
            throw new NotImplementedException();
        }

        public BankStatementDTO Convert(string content)
        {
            BankStatementDTO bankStatement = null;
            string xml = string.Empty;

            using (TextReader sr = new StringReader(content))
            {
                string line = string.Empty;
                
                do
                {
                    line = sr.ReadLine();
                    xml += ProcessLine(line);
                }
                while (line != null);
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);

            bankStatement = OfxElementFactory.CreateElement(xmlDocument);

            return bankStatement;
        }

        private string ProcessLine(string line)
        {
            if (string.IsNullOrEmpty(line)) return null;

            string[] _line = line.Split('>');

            if (IsAnElement(line))
            {
                // Do Nothing
            }
            else if (IsAProperty(line))
            {
                string element = _line[0].Replace("<", "");
                line += $"</{element}>";
            }
            else
            {
                line = "";
            }

            return line;
        }

        private bool IsAnElement(string line) =>
            line.Contains('>') && line.IndexOf('>') == line.Length - 1;

        private bool IsAProperty(string line) =>
            line.Contains('>') && line.IndexOf('>') != line.Length - 1;

    }
}
