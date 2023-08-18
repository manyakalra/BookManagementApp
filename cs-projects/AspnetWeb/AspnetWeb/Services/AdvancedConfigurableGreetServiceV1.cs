using AspnetWeb;

namespace AspnetWeb.Services
{
    public class AdvancedConfigurableGreetServiceV1 : IGreetService
    {
        private string prefix, suffix;
        bool useTimePrefix;

        private ILogger<ConfigurableGreetService> logger;
        ITimePrefix timePrefix;
        

        public string Prefix
        {
            get
            {
                if (useTimePrefix)
                    return $"Good {timePrefix.Prefix}";
                else
                    return prefix;
            }
        }

        public AdvancedConfigurableGreetServiceV1(ITimePrefix timePrefix, IConfiguration config, ILogger<ConfigurableGreetService> logger)
        {
            //this.prefix = config["Greetings:Prefix"];
            //suffix = config["Greetings:Suffix"];
            //useTimePrefix = bool.Parse(config["Greetings:UseTimedPrefix"]);

            prefix = config.Get("Greetings:Prefix", "Hi");
            suffix = config.Get("Greetings:Suffix", "");
            useTimePrefix = config.Get("Greetings:UseTimedPrefix", false);

            this.timePrefix = timePrefix;
            this.logger = logger;
            logger.LogInformation($"Instance #{GetHashCode()} created");
        }
        public string Greet(string name)
        {
            logger.LogInformation($"[{GetHashCode()}] generating greeting for {name}");

            return $"{Prefix} {name} {suffix}";
        }
    }
}
