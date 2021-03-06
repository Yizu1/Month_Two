using ETL_Common;
using ETL_IRepository;
using ETL_IRepository.IEngine;
using ETL_Model;
using ETL_Repository.etl_task_info;
using ETL_Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETL_IRepository.User;
using ETL_Repository.User;
using ETL_IRepository.role;
using ETL_Repository.role;
using ETL_IRepository.sys_role;
using ETL_IRepository.sys_modules;
using ETL_IRepository.sysy_user_role;
using ETL_IRepository.sys_role_modules;
using ETL_Repository.sys_role;
using ETL_Repository.sys_modules;
using ETL_Repository.sys_role_modules;
using ETL_Repository.sys_user_role;
using ETL_IRepository.sys_user;
using ETL_Repository.sys_user;

namespace ETL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<SQLServerHelper>();
            services.AddScoped<IEngineRepository<Engine>, EngineRepository>();
            services.AddScoped<ITidLxinRepository<TidLxin>, TidLxinRepository>();
            services.AddScoped<ITid1LxinRepository<Tid1Lxin>, Tid1LxinRepository>();
            services.AddScoped<IJianCeRepository<etl_task_info>, JianCeRepository>();
            services.AddScoped<IEngineRizhiRepository<engineRizhi>, EngineRizhiRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ETL", Version = "v1" });
            });

            services.AddScoped<Ietl_task_infoRepository, etl_task_infoRepository>();
            services.AddScoped<ETL_Common.DapperHelper>();
            services.AddScoped<DapperHelper>();
            services.AddScoped<IdictionariesRepository, DictionariesRepository>();
            services.AddScoped<IData_AnalysisRepository, DataAnalysisRepository>();
            services.AddTransient<DapperHelper, DapperHelper>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IRoleRepository, RoleRepository>();

            services.AddScoped<Isys_roleRepository, sys_roleRepository>();
            services.AddScoped<Isys_modulesRepository, sys_modulesRepository>();
            services.AddScoped<Isys_user_roleRepository, sys_user_roleRepository>();
            services.AddScoped<Isys_role_modulesRepository, sys_role_modulesRepository>();
            services.AddScoped<Isys_userRepository, sys_userRepository>();

            // ??????????????????????????
            services.AddCors(options =>
            options.AddPolicy("cors",
            p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

            ////??????????????????????????
            services.AddCors(options => options.AddPolicy("cors", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
            ////1.???????????????????????????? 
            //services.AddCors(options =>
            //    options.AddPolicy("????????????????????", p => p.AllowAnyOrigin())
            //);
            //  //????cors ???? ????????????   
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.WithMethods("GET", "POST", "HEAD", "PUT", "DELETE", "OPTIONS")
                    //.AllowCredentials()//????????cookie
                .AllowAnyOrigin(); //??????????????????????
                });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ETL v1"));
            }

            ////????????
            app.UseCors("cors");


            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            //????Cors
            app.UseCors("any");
        }
    }
}
