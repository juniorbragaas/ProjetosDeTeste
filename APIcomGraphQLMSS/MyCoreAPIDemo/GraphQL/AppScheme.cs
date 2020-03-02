
using GraphQL.Types;
using GraphQL;

namespace MyCoreAPIDemo.GraphQL
{
    public class AppScheme : Schema
    {
        public AppScheme(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<AppQuery>();
        }
    }
}
