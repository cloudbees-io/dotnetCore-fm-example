using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.Controllers
{
    [ApiController]
    [Route("/")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public WelcomeMessageResponse Get()
        {
            return new WelcomeMessageResponse() { Message="Hello, You created a web app!" };
        }

        [HttpGet]
        [Route("demo")]
        public DemoMessageResponse GetDemo()
        {
            var msg = new DemoMessageResponse() {
                Message="Flag message hidden. Enable the flag in the Cloudbees platform to display it.",
                FontColor=Program.FlagsContainer.FontColor.GetValue(),
                FontSize=Program.FlagsContainer.FontSize.GetValue()
            };
            if (Program.FlagsContainer.ShowMessage.IsEnabled())
            {
		        msg .Message = Program.FlagsContainer.Message.GetValue();
	        }
            return msg;
        }
    }

    public class WelcomeMessageResponse
    {
        public required String Message { get; set; }
    }

    public class DemoMessageResponse
    {
        public required String Message { get; set; }
        public required String FontColor { get; set; }
        public required int FontSize { get; set; }
    }
}
