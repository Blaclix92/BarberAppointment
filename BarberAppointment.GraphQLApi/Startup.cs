using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberAppointment.GraphQLApi.Core;
using BarberAppointment.GraphQLApi.Data;
using BarberAppointment.GraphQLApi.GraphQL;
using BarberAppointment.GraphQLApi.Server;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BarberAppointment.GraphQLApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IBookAppointment, BookAppointmentRepository>();
            services.AddSingleton<IProfile, ProfileRepository>();

            services.AddGraphQL(s => SchemaBuilder.New()
                .AddServices(s)
                .AddType<BookAppointmentType>()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .Create());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL();
            app.UsePlayground();

        }
    }
}
