﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class MeetUpContext : IdentityDbContext
    {
        public MeetUpContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Speaker> Speakers { get; set; }
    }
}
