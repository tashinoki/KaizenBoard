using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanDomain.Context;
using Contract.Entity;

namespace KanbanDomain.UseCases
{
    [ApiController]
    [Route("[controller]")]
    public class FetchKaizenBoard: ControllerBase
    {
        private const string MemberId = "7F1C561F-5354-4241-2FA0-08D98585397B";
        private readonly KanbanContext _context;
        private readonly ILogger<FetchKaizenBoard> _logger;
     
        public FetchKaizenBoard(
            ILogger<FetchKaizenBoard> logger,
            KanbanContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<Member> Get()
        {
            var member = await _context.Members.FindAsync(MemberId);
            return member;
        }
    }
}
