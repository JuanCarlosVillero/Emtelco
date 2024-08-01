using Emptelco.Api.IntegrationTest.Base;
using Emtelco.Application.Features.Pokemon.Queries.GetPokemonDetail;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Emptelco.Api.IntegrationTest
{
    public class ClientControllerTests
        : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        public readonly CustomWebApplicationFactory<Program> _factory;

        public ClientControllerTests(CustomWebApplicationFactory<Program> program)
        {
            _factory = program;
        }

        [Fact]
        public async Task ReturnSuccessResult()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/Pokemon/habilidadesOcultas/pikachu");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<List<PokemonDetailVm>>(responseString);

            Assert.IsType<List<PokemonDetailVm>>(result);
            Assert.NotNull(result);
        }
    }
}
