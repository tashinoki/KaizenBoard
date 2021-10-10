﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanDomain.Context;
using Contract.Entity;
using Microsoft.EntityFrameworkCore;

namespace KanbanDomain.UseCases
{
    [ApiController]
    [Route("[controller]")]
    public class KaizenBoardController: ControllerBase
    {
        private readonly string MemberId = "7F1C561F-5354-4241-2FA0-08D98585397B";
        private readonly KanbanContext _context;
        private readonly ILogger<KaizenBoardController> _logger;
     
        public KaizenBoardController(
            ILogger<KaizenBoardController> logger,
            KanbanContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<Member> Get()
        {
            var member = await _context.Members
                .Select(m => m)
                .Include(m => m.KanbanBoards)  // ここの Orde By はどうやれば良いのだろうか
                .ThenInclude(kb => kb.Kanbans)
                .FirstOrDefaultAsync();
            return member;
        }
    }
}
