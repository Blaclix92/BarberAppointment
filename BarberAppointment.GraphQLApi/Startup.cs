using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberAppointment.GraphQLApi.Core;
using BarberAppointment.GraphQLApi.Data;
using BarberAppointment.GraphQLApi.GraphQL;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BarberAppointment.GraphQLApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IBookAppointment, BookAppointmentRepository>();
            services.AddSingleton<IProfile, ProfileRepository>();
            services.AddSingleton<IWorkDay, WorkDayRepository>();
            services.AddSingleton<IAppointmentHour, AppointmentHourRepository>();

            services.AddGraphQL(s => SchemaBuilder.New()
                .AddServices(s)
                .AddAuthorizeDirectiveType()
                .AddType<BookAppointmentType>()
                .AddType<WorkDayType>()
                .AddType<ProfileType>()
                .AddType<AppointmentHourType>()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .Create());
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddIdentityServerAuthentication(options =>
                   {

                       // base-address of your identityserver
                       options.Authority = "http://localhost:51351";
                       options.RequireHttpsMetadata = false;
                       options.ApiName = "DemoApi";
                       options.ApiSecret = "MySecret";
                   });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseGraphQL("/api");
            app.UsePlayground();
        
        }
    }
}
