using CustomersApi.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CustomersApi.Repositories
{
    public class CustomerDatabaseContext : DbContext
    {
        //DBset hace referncia a nuestras tablas en la BD, con su get y set, con esto accedemos 
        public DbSet<CustomerEntity> Customer { get; set; }

        //Para coger informacion
        public async Task<CustomerEntity> Get(long id)
        {
            return await Customer.FirstAsync(x => x.Id == id);
        }

        //agregamos un dato
        public async Task<CustomerEntity> Add(CreateCustomerDto customerDto)
        {

            //hacemos el mapeo entre entidad y dto
            CustomerEntity entity = new CustomerEntity()
            {
                Id = null,
                Address = customerDto.Address,
                Email = customerDto.Email,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,

            };


            EntityEntry<CustomerEntity> response = await Customer.AddAsync(entity);

            await SaveChangesAsync();

            return await Get(response.Entity.Id ?? throw new Exception("No se ha podido agregar el elemento"));
        }

    }


    //crear entidad que hace el mapeo

    public class CustomerEntity
    {

        public long? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }


        public string Phone { get; set; }
        public string Address { get; set; }

    }
}
