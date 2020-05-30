using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SuppliesPriceLister.Core.Loaders.Json;
using SuppliesPriceLister.Core.Models;
using Xunit;

namespace SuppliesPriceLister.Core.Tests.Loaders.Json
{
    public class JsonSupplyListParserTests
    {
        [Fact]
        public void GivenCanLoad_WhenProvidedWithList_ThenSupportsJsonFormat()
        {
            var parser = new JsonSupplyListParser();

            parser.CanLoad(new SupplyList {Format = "json"}).Should().BeTrue();
            parser.CanLoad(new SupplyList {Format = "csv"}).Should().BeFalse();
            parser.CanLoad(new SupplyList {Format = "xml"}).Should().BeFalse();

        }

        [Fact]
        public async Task GivenLoadSupplyList_WhenProvidedWithList_ThenFileIsLoaded()
        {
            var parser = new JsonSupplyListParser();

            var list = await parser.LoadSupplyList(new SupplyList
            {
                FilePath = $"{Directory.GetCurrentDirectory()}\\Loaders\\Json\\test.json",
                Currency = "AUD",
                Format = "json"
            });

            list.Should().NotBeNullOrEmpty();
            list.Should().HaveCount(2);

            list.Should().Contain(x => x.Id == "10");
            list.Should().Contain(x => x.Id == "10" && x.Name == "Potato Twister");
            list.Should().Contain(x => x.Id == "10" && x.Price == 80m);
            list.Should().Contain(x => x.Id == "10" && x.Unit == "m2");
            list.Should().Contain(x => x.Id == "10" && x.MaterialType == "Steel");
            list.Should().Contain(x => x.Id == "10" && x.ProviderId == "42");

            list.Should().Contain(x => x.Id == "11");
            list.Should().Contain(x => x.Id == "11" && x.Name == "Unicorn Voyager");
            list.Should().Contain(x => x.Id == "11" && x.Price == 95.25m);
            list.Should().Contain(x => x.Id == "11" && x.Unit == "Parsec");
            list.Should().Contain(x => x.Id == "11" && x.MaterialType == "Glitter");
            list.Should().Contain(x => x.Id == "11" && x.ProviderId == "6*7");



        }

    }
}
