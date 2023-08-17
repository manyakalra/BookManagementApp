namespace AspnetWeb.Services
{

    public interface IGreetService
    {
        string Greet(string name);
    }


    public interface ITimePrefix
    { 
        string Prefix { get; }
    }


    public class EnglishTimePrefix : ITimePrefix
    {
        public string Prefix
        {
            get
            {
                var hour = DateTime.Now.Hour;
                var timeName = "Morning";
                if (hour > 12 && hour < 18)
                    timeName = "After Noon";
                else if (hour > 18)
                    timeName = "Evening";

                return timeName;

            }
        }


    }


  

    public class TimedGreetService : IGreetService
    {
        ITimePrefix timePrefix;
        static int instanceCount;
        public int Id;

        public TimedGreetService(ITimePrefix prefix)
        {
            timePrefix= prefix;
            Id = ++instanceCount;
        }
        public string Greet(string name)
        {

            var timeName = timePrefix.Prefix;
            return $"Good {timeName}, {name}! Welcome from Service #{Id}";

        }
    }


    public class SimpleGreetService : IGreetService
    {

        static int instanceCount;
        public int Id;

        public SimpleGreetService()
        {
           
            Id = ++instanceCount;
        }
        public string Greet(string name)
        {
            return $"Hello {name}, Welcome from  Service #{Id}";
        }
    }
}
