using GraphQL.Types;
using MyCoreAPIDemo.Entities;
using MyCoreAPIDemo.Repository.Contract;
using MyCoreAPIDemo.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreAPIDemo.GraphQL
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IUsersRepository<Users> repository)
        {
            Field<ListGraphType<UsersType>>(
               "users",
               resolve: context => repository.GetAll()
           ) ;
        }
    }
}
