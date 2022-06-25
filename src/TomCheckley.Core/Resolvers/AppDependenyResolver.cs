namespace TomCheckley.Core.Resolvers
{
    public class AppDependenyResolver
    {
        private static AppDependenyResolver _resolver;
        private readonly IServiceProvider _serviceProvider;

        public static AppDependenyResolver Current
        {
            get
            {
                if (_resolver == null)
                {
                    throw new Exception("AppDependencyResolver not initialized. You should initialize it in Startup class");
                }
                return _resolver;
            }
        }

        public static void Init(IServiceProvider services)
        {
            _resolver = new AppDependenyResolver(services);
        }

        public object GetSevice(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public T GetService<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }

        private AppDependenyResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
