using AspnetWeb;

namespace AspnetWeb.Services
{
    public class GreetConfiguration
    {
        public string Prefix { get; set; } = "Hi";
        public string Suffix { get; set; } = "You are welcome";
        public bool UseTimedPrefix { get; set; } = false;
    }

    public class AdvancedConfigurableGreetService : IGreetService
    {
        

        private ILogger<ConfigurableGreetService> logger;
        ITimePrefix timePrefix;
        

        public string Prefix
        {
            get
            {
                if (greetConfiguration.UseTimedPrefix)
                    return $"Good {timePrefix.Prefix}";
                else
                    return greetConfiguration.Prefix;
            }
        }

        GreetConfiguration greetConfiguration;
        public AdvancedConfigurableGreetService(ITimePrefix timePrefix, IConfiguration config, ILogger<ConfigurableGreetService> logger)
        {
            greetConfiguration = new GreetConfiguration();

            config.Bind("Greetings", greetConfiguration);

            this.timePrefix = timePrefix;
            this.logger = logger;
            logger.LogInformation($"Instance #{GetHashCode()} created");
        }
        public string Greet(string name)
        {
            logger.LogInformation($"[{GetHashCode()}] generating greeting for {name}");

            return $"{Prefix} {name} {greetConfiguration.Suffix}";
        }
    }
}
