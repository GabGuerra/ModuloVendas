using Ecommerce.Models.Vitrine;
using Ecommerce.Repositories.Shared;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Vitrine
{
    public class VitrineRepository : DbRepository<VitrineVD>, IVitrineRepository
    {
        public VitrineRepository(IConfiguration config) : base(config) { }
       
    }
}
