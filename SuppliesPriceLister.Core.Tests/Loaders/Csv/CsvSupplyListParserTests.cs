using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SuppliesPriceLister.Core.Loaders.Csv;
using SuppliesPriceLister.Core.Models;
using Xunit;

namespace SuppliesPriceLister.Core.Tests.Loaders.Csv
{
    public class CsvSupplyListParserTests
    {
        [Fact]
        public void GivenCanLoad_WhenProvidedWithList_ThenSupportsCsvFormat()
        {
            var parser = new CsvSupplyListParser();

            parser.CanLoad(new SupplyList { Format = "csv" }).Should().BeTrue();
            parser.CanLoad(new SupplyList { Format = "json" }).Should().BeFalse();
            parser.CanLoad(new SupplyList { Format = "xml" }).Should().BeFalse();
        }

        [Fact]
        public async Task GivenLoadSupplyList_WhenProvidedWithList_ThenFileIsLoaded()
        {
            var parser = new CsvSupplyListParser();

            var list = await parser.LoadSupplyList(new SupplyList
            {
                FilePath = $"{Directory.GetCurrentDirectory()}\\Loaders\\Json\\test.csv",
                Currency = "AUD",
                Format = "csv"
            });


            // todo: enms


        }
    }
}
