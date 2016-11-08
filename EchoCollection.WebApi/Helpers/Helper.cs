using EchoCollection.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EchoCollection.WebApi.Helpers
{
    public static class Helper
    {
        public static List<Collection> GetCollectionsMockUp()
        {
            List<Collection> collections = new List<Collection>();
            Collection col1 = new Collection()
            {
                Title = "Arnela",
                Description = "Prvi desc",
                IsPrivate = false
            };
            collections.Add(col1);
            Collection col2 = new Collection()
            {
                Title = "Almir",
                Description = "Drugi desc",
                IsPrivate = true
            };
            collections.Add(col2);
            return collections;
        }
    }
}