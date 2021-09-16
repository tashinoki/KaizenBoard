using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanDomain.UseCases
{
    [ApiController]
    [Route("[controller]")]
    public class FetchKaizenBoard: ControllerBase
    {
        private readonly ILogger<FetchKaizenBoard> _logger;
        public FetchKaizenBoard(ILogger<FetchKaizenBoard> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<int> Get()
        {
            return Enumerable.Range(0, 10);
        }
    }
}
