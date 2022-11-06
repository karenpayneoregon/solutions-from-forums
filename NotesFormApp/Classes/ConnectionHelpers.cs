using ConfigurationLibrary.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesFormApp.Classes
{
    internal class ConnectionHelpers
    {
        public static void StandardLoggingSqlServer(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(ConfigurationHelper.ConnectionString())
                .EnableSensitiveDataLogging()
                .LogTo(message => Debug.WriteLine(message));

        }
        public static void NoLoggingSqlServer(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString());
        }
    }
}
