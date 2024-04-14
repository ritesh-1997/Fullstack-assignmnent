using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Common.Models;
using Microsoft.EntityFrameworkCore;


namespace backend.Common.Data
{
    public class Context : DbContext
    {
        public IConfiguration Configuration { get; }

        public DbSet<UserProfileTBL> UserProfileTBL { get; set; }
        public DbSet<UserTBL> UserTBL { get; set; }
        public DbSet<MutualFundOrderTBL> MutualFundOrderTBL { get; set; }
        public DbSet<PaymentTBL> PaymentTBL { get; set; }
        public string DbPath { get; }
        public Context(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // // Inject connection string from configuration (assuming IConfiguration is injected)
            if (File.Exists("./../../Data/mydatabase.db"))
                Console.WriteLine("Creating database");
            else
                Console.WriteLine("Dekle database");
            // SearchDirectory("../../", "mydatabase.db");
            Console.WriteLine($"Searching mydatabase.db");
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            Console.WriteLine($"Searching mydatabase.db");
        }

        public void SearchDirectory(string directory, string fileName)
        {
            try
            {
                Console.WriteLine($"Searching {fileName}, {directory}");
                // Search for the file in the current directory
                string[] files = Directory.GetFiles(directory, fileName, SearchOption.TopDirectoryOnly);

                // Print the full path if the file is found
                if (files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        Console.WriteLine(file);
                    }
                }

                // Recursively search in all subdirectories
                string[] subdirectories = Directory.GetDirectories(directory);
                foreach (string subdirectory in subdirectories)
                {
                    SearchDirectory(subdirectory, fileName);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Handle unauthorized access to directories
                Console.WriteLine($"Access to directory '{directory}' is denied.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }


}