using System.IO;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;

using SimpleChat.Hubs;
using SimpleChat.Services;
using SimpleChat.Utils;

using Swashbuckle.AspNetCore.Swagger;

namespace SimpleChat
{
	public sealed class Startup
	{
		public IConfigurationRoot Configuration { get; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", true, true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			var options = new RewriteOptions()
				.AddRedirectToHttps();

			app.UseRewriter(options);

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebpackDevMiddleware(
					new WebpackDevMiddlewareOptions
					{
						HotModuleReplacement = true
					});
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseSignalR(routes => routes.MapHub<ChatHub>("/chathub"));

#if DEBUG

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chat API V1");
			});

#endif

			app.UseMvc(
				routes =>
				{
					routes.MapRoute(
						"default",
						"{controller=Home}/{action=Index}/{id?}");

					routes.MapSpaFallbackRoute(
						"spa-fallback",
						new
						{
							controller = "Home",
							action = "Index"
						});
				});
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddMvc(options =>
				{
					options.RespectBrowserAcceptHeader = true;
				})
				.AddXmlSerializerFormatters();

			services.AddSignalR();

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.AddSingleton<ITimeService, TimeService>();
			services.AddSingleton<IChatMessageStorage, ChatMessageStorage>();
			services.AddSingleton<IChatMessageIdGenerator, ChatMessageIdGenerator>();
			services.AddSingleton<INotificationService, NotificationService>();

			services.AddScoped<IChatService, ChatService>();
			services.AddScoped<IUserInfoProvider, UserInfoProvider>();

			services.Configure<MvcOptions>(options =>
			{
				options.Filters.Add(new RequireHttpsAttribute());
			});

#if DEBUG

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc(
					"v1",
					new Info
					{
						Title = "Chat API",
						Version = "v1"
					});

				var basePath = PlatformServices.Default.Application.ApplicationBasePath;
				var xmlPath = Path.Combine(basePath, "SimpleChat.xml");
				c.IncludeXmlComments(xmlPath);
			});

#endif
		}
	}
}