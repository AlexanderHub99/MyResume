#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyResume.Models;

namespace MyResume.Data
{
    
    
        public class WebToDoListContext : DbContext
        {
            public WebToDoListContext(DbContextOptions<WebToDoListContext> options)
                : base(options)
            {
            }

            public DbSet<MyResume.Models.ToDoList> ToDoList { get; set; }
        }
    
}
