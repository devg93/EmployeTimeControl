


using System.Net.NetworkInformation;
using Microsoft.Extensions.Logging;

namespace Shared.Services.Tasks.PingCheker;

    public sealed class PingSender:IPingSender
    {
         private readonly ILogger<PingSender> logger;
        public PingSender(ILogger<PingSender> logger)
         => this.logger = logger;

        public async Task<bool> PingIp(string ipAddress)
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = await ping.SendPingAsync(ipAddress);
                    logger.LogInformation($"Pinged {ipAddress}, Status: {reply.Status}, Roundtrip Time: {reply.RoundtripTime} ms");

                    return reply.Status == IPStatus.Success;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Error pinging {ipAddress}: {ex.Message}");
                return false;
            }
        }

    }
