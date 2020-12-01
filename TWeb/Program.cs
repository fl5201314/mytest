using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace TWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {


            using (MyDbContext ctx = new MyDbContext())
            {
                //ctx.Persons.Add(new Person {  Age=1 , Name= "xx"});

               ctx.Students

                ctx.SaveChanges();
            }




                CreateHostBuilder(args).Build().Run();





        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
