namespace ConceptArchitect.Async
{
  

    public class AsyncFunction<Return>
    {
        Thread thread;
        Return result;
        
        public Return Result
        {
            get
            {
                if (thread.IsAlive)
                    thread.Join();
                return result;
            }
        }

        public AsyncFunction( Func<Return> func)
        {
            thread = new Thread(() =>result= func());
            thread.Start();

        }

        public void Wait()
        {
            thread.Join();
        }

    }
}