namespace ReactFS

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection

type Startup () =
    new (configuration: IConfiguration) as this =
        Startup() then
        this.Configuration <- configuration

    member this.ConfigureServices(services: IServiceCollection) =
        // Add framework services.
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1) |> ignore
        services.AddSpaStaticFiles(fun configuration ->
                configuration.RootPath <- "ClientApp/build"
            ) |> ignore

    member this.Configure(app: IApplicationBuilder, env: IHostingEnvironment) =
        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore
        else
            app.UseHsts() |> ignore
            
        app.UseStaticFiles() |> ignore
        
        app.UseSpaStaticFiles() |> ignore
        
        app.UseMvc(fun routes ->
            routes.MapRoute(
                name = "default",
                template = "{controller=Home}/{action=Index}/{id?}") |> ignore
            ) |> ignore

            
        app.UseSpa(fun spa ->
                spa.Options.SourcePath <- "ClientApp"

                if (env.IsDevelopment()) then
                    spa.UseReactDevelopmentServer("start") |> ignore
                else
                    None |> ignore
        ) |> ignore
        
    member val Configuration : IConfiguration = null with get, set