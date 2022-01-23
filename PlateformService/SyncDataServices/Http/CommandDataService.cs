using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PlateformService.Configuration;
using PlateformService.Dtos;

namespace PlateformService.SyncDataServices.Http
{
    public class CommandDataService : ICommandDataService
    {
        private readonly HttpClient _client;
        private readonly IOptions<CommandServiceConfiguration> _options;

        public CommandDataService(HttpClient client, IOptions<CommandServiceConfiguration> options)
        {
            _client = client;
            _options = options;
        }
        public async Task SendPlatformToCommand(PlatformReadDto platform)
        {
            System.Console.WriteLine(_options.Value.Url);
            System.Console.WriteLine(_options.Value.PlatformApiEndpoint);
            var httpContent = new StringContent(
                JsonSerializer.Serialize(platform),
                Encoding.UTF8,
                "application/json"
            );
            var response = await _client.PostAsync($"{_options.Value.Url}{_options.Value.PlatformApiEndpoint}", httpContent);
            if(response.IsSuccessStatusCode)
                System.Console.WriteLine("-- async post success...");
            else
                System.Console.WriteLine("-- async post failed...");
        }
    }
}