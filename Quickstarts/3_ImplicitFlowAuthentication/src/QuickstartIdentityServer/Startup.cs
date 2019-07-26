// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using QuickstartIdentityServer.CustomerChange;

namespace QuickstartIdentityServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var rsaParameter = new RSACryptoServiceProvider(4096).ExportParameters(true);
            var key = new RsaSecurityKey(rsaParameter);
            // configure identity server with in-memory stores, keys, clients and scopes
            services.AddIdentityServer(options =>
            {
                //此处配置授权Url.
                //options.UserInteraction.ConsentUrl
                //配置登陆Url
                //options.UserInteraction.LoginUrl
            })
                .AddSigningCredential(key)
                //替换密钥
                //.AddDeveloperSigningCredential()
                //替换资源存储
                .AddResourceStore<CustomerSourceStore>()
                //.AddInMemoryIdentityResources(Config.GetIdentityResources())
                //.AddInMemoryApiResources(Config.GetApiResources())
                //替换客户端存储
                .AddClientStore<FileClientStore>()
                //.AddInMemoryClients(Config.GetClients())
                //替换跟人信息获取提供服务。
                .AddTestUsers(Config.GetUsers())
                .AddInMemoryPersistedGrants()
                .AddProfileService<CustomerProfileService>();

            services.AddSingleton(Config.GetApiResources());
            services.AddSingleton(Config.GetIdentityResources());
            services.AddSingleton(Config.GetClients());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();
        }
    }
}