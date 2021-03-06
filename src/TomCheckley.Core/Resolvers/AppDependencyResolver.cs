namespace TomCheckley.Core.Resolvers
{
    public class AppDependencyResolver
    {
        private static AppDependencyResolver _resolver;
        private readonly IServiceProvider _serviceProvider;

        public static AppDependencyResolver Current
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
            _resolver = new AppDependencyResolver(services);
        }

        public object GetSevice(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public T GetService<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }

        private AppDependencyResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
