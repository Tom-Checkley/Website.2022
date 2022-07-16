using TomCheckley.Core.Resolvers;

namespace TomCheckley.Core.Factories.Concrete
{
    public static class FactoryFactory
    {
        public static T GetService<T>()
        {
            return AppDependencyResolver.Current.GetService<T>();
        }
    }
}
