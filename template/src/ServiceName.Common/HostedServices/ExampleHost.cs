using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ServiceName.Common.HostedServices
{
    public class ExampleHost : IHostedService
    {
        private readonly ILogger<ExampleHost> _logger;

        public ExampleHost(ILogger<ExampleHost> logger)
        {
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Host being started...");

            _logger.LogInformation("Host has been started");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Host being stopped...");

            _logger.LogInformation("Host has been stopped");
        }
    }
}
