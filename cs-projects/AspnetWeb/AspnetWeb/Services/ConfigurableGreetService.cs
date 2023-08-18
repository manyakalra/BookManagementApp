namespace AspnetWeb.Services
{
    public class ConfigurableGreetService : IGreetService
    {
        private string prefix, suffix;
        private ILogger<ConfigurableGreetService> logger;

        public ConfigurableGreetService(IConfiguration config, ILogger<ConfigurableGreetService> logger)
        {
            prefix = config["GreetingPrefix"];
            suffix = config["GreetingSuffix"];
            this.logger = logger;
            logger.LogInformation($"Instance #{GetHashCode()} created");
        }
        public string Greet(string name)
        {
            if(string.IsNullOrEmpty(prefix) )
            {
                logger.LogError($"No Prefix configured. switching to default: Hello");
                prefix = "Hello";
            }
            if (string.IsNullOrEmpty(suffix))
            {
                logger.LogWarning($"No Prefix configured. Ignoring...");                
            }

            logger.LogInformation($"[{GetHashCode()}] generating greeting for {name}");

            return $"{prefix} {name} {suffix}";
        }
    }
}
