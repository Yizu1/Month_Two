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
            services.AddScoped<IJianCeRepository<JianCe>, JianCeRepository>();
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


            // ���ÿ���������������Դ
            services.AddCors(options =>
            options.AddPolicy("cors",
            p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

            ////���ÿ���������������Դ
            services.AddCors(options => options.AddPolicy("cors", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
            ////1.���ÿ���������������Դ�� 
            //services.AddCors(options =>
            //    options.AddPolicy("�Զ���Ŀ����������", p => p.AllowAnyOrigin())
            //);
            //  //���cors ���� ���ÿ�����   
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.WithMethods("GET", "POST", "HEAD", "PUT", "DELETE", "OPTIONS")
                    //.AllowCredentials()//ָ������cookie
                .AllowAnyOrigin(); //�����κ���Դ����������
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

            ////��������
            app.UseCors("cors");


            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            //����Cors
            app.UseCors("any");
        }
    }
}
