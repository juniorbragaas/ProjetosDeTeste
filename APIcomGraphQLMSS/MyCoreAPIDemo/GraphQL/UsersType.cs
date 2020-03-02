using GraphQL.Types;
using MyCoreAPIDemo.Entities;

namespace MyCoreAPIDemo.GraphQL
{
    public class UsersType : ObjectGraphType<Users>
    {
        public UsersType()
        {
            Field(x => x.Id, type: typeof(IdGraphType))
                .Description("Propriedade CategoriaId do objeto categoria.");
            Field(x => x.Login)
                .Description("Propriedade Nome do objeto categoria.");
            Field(x => x.Password)
                .Description("Propriedade ImagemUrl do objeto categoria.");
        }
    }
}
