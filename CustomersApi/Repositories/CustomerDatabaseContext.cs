using Microsoft.EntityFrameworkCore;

namespace CustomersApi.Repositories
{
    public class CustomerDatabaseContext : DbContext
    {
        public DbSet<CustomerEntity> Customer { get; set; }

        public async Task<CustomerEntity> Get(long id)
        {
            return await Customer.FirstAsync(x => x.Id == id);
        }

    }


    //crear entidad que hace el mapeo

    public class CustomerEntity
    {

        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }


        public string Phone { get; set; }
        public string Address { get; set; }

    }
}
