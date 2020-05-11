using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using com.b_velop.coffee_O_mat.Application.Contracts;

namespace com.b_velop.coffee_O_mat.Application.Services
{
    public class ForwardService : IForwardService
    {
        private readonly HttpClient _client;

        public ForwardService(HttpClient client)
        {
            _client = client;
        }

        private string GetLine(string point, double value)
        {
            return $"{point},user=marcel-b,maschine=rancilio value={value}";
        }
        
        public async Task Send(Domain.Models.Brew brew)
        {
            var c = new StringBuilder();
            c.AppendLine(GetLine("temp", brew.Temperature));
            c.AppendLine(GetLine("output", brew.Output));
            c.AppendLine(GetLine("kp", brew.KP));
            c.AppendLine(GetLine("ki", brew.KI));
            c.AppendLine(GetLine("kd", brew.KD));
            c.AppendLine(GetLine("solltemp", brew.TargetTemperature));
            var str = new StringContent(c.ToString(), Encoding.UTF8, "text/plain");
            var res = await _client.PostAsync("/write?db=ranciliopid", str);
        }
    }
}