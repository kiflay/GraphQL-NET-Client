using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_NET
{
    class Program
    {
        static void Main(string[] args)
        {
            var GraphQl       = new GraphQLNETClient();
            string url        = "<Base Url>/admin/api/graphql.json";
            string query      = @"{shop { products(first: 5) {edges {node { id handle }}}}}";
            var jSonResponse  = GraphQl.Execute(url,query);

            Console.WriteLine(jSonResponse);
            Console.ReadKey();
        }
    }
}
