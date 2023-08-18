namespace AspnetWeb
{
    public static class ConfigurationExtensions
    {
        public static T Get<T>(this IConfiguration config, string key, T defaultValue=default(T))
        {
            var value = config[key];
            if (string.IsNullOrEmpty(value))
                return defaultValue;
            else
                return (T) Convert.ChangeType(value, typeof(T));
        }
    }
}
