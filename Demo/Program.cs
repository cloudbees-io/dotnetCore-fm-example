
using Io.Rollout.Rox.Core.Entities;
using Io.Rollout.Rox.Server;

public class Program
{
    static IRoxContainer flagsContainer = new Demo.FeatureManagement.Container();
    public static Demo.FeatureManagement.Container FlagsContainer { get { return (Demo.FeatureManagement.Container) flagsContainer; }}

    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        Rox.Register(flagsContainer);
        // TODO: insert your SDK key from https://cloudbees.io/ below.
        var sdkKey = "<YOUR-SDK-KEY>";
        await Rox.Setup(sdkKey, new RoxOptions(new RoxOptions.RoxOptionsBuilder{
            NetworkConfigurationsOptions = new Io.Rollout.Rox.Core.Client.NetworkConfigurationsOptions(
                "https://api.vpc-install-test.saas-tools.beescloud.com/device/get_configuration",
                "https://rox-conf.vpc-install-test.saas-tools.beescloud.com",
                "https://api.vpc-install-test.saas-tools.beescloud.com/device/update_state_store/",
                "https://rox-state.vpc-install-test.saas-tools.beescloud.com",
                "https://fm-analytics.vpc-install-test.saas-tools.beescloud.com",
                "https://sdk-notification-service.vpc-install-test.saas-tools.beescloud.com/sse"
            )
        }));
        app.Run();
        await Rox.Shutdown();
    }
}
