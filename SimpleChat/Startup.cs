namespace SimpleChat
{
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.SpaServices.Webpack;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Logging;

	using SimpleChat.Services;

	public sealed class Startup
	{
		public IConfigurationRoot Configuration { get; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

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

			app.UseMvc(
				routes =>
				{
					routes.MapRoute(
						name: "default",
						template: "{controller=Home}/{action=Index}/{id?}");

					routes.MapSpaFallbackRoute(
						name: "spa-fallback",
						defaults: new
						{
							controller = "Home",
							action = "Index"
						});
				});

			app.UseWebSockets();
			app.UseSignalR();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddMvc();
			services.AddSignalR();

			services.AddSingleton<ITimeService, TimeService>();
			services.AddSingleton<IChatMessageStorage, ChatMessageStorage>();
			services.AddSingleton<IChatMessageIdGenerator, ChatMessageIdGenerator>();
			services.AddSingleton<INotificationService, NotificationService>();

			services.AddScoped<IChatService, ChatService>();
		}
	}
}