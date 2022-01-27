using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4HW3.Data.Entities;

namespace Module4HW3.Data.Queries
{
    public class Queries
    {
        private readonly ApplicationContext _context;

        public Queries(ApplicationContext context)
        {
            _context = context;
        }

        public async Task FirstQuery()
        {
            var data = await _context.EemployeeProjects
                .AsNoTracking()
                .Include(x => x.Employee)
                .ThenInclude(x => x.Title).ToListAsync();

            if (data.Any())
            {
                Console.WriteLine("Tables:");
                foreach (var element in data)
                {
                    Console.WriteLine(data);
                }
            }
        }

        public async Task SecondQuery()
        {
            var now = DateTime.UtcNow;
            var data = await _context.Employees
                .AsNoTracking()
                .Select(x => new { x.HiredDate })
                .ToListAsync();

            if (data.Any())
            {
                Console.WriteLine("Date diff:");
                foreach (var element in data)
                {
                    Console.WriteLine(now - element.HiredDate);
                }
            }
        }

        public async Task ThirdQuery()
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == 2);
            client.DateOfBirth = DateTime.UtcNow.AddYears(-30);
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == 4);
            project.Name = project.Name + Guid.NewGuid();

            await _context.SaveChangesAsync();
        }

        public async Task FourthQuery()
        {
            var client = new Employee
            {
                FirstName = "fn",
                LastName = "Warren",
                HiredDate = DateTime.UtcNow.AddYears(-5),
                OfficeId = 1,
                TitleId = 1
            };
            await _context.AddAsync(client);

            await _context.SaveChangesAsync();
        }

        public async Task FifthQuery()
        {
            var employee = await _context.Employees.FirstOrDefaultAsync();
            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();
        }

        public async Task SixthQuery()
        {
            var data = await _context.Employees
                .AsNoTracking()
                .Include(x => x.Title)
                .GroupBy(x => x.Title.Name)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .Where(g => !g.Name.Contains("a"))
                .ToListAsync();

            foreach (var item in data)
            {
                Console.WriteLine($"{item.Name}, {item.Count}");
            }
        }
    }
}
