namespace ECommerce.Api.Search.Interfaces
{
    public interface ICustomersService
    {
        //  I added these ICustomersService interface.
        //  Here, I'm returning a dynamic object rather than a concrete model object.
        /// <summary>
        /// This is because I'm using the entire customer information
        /// that I'm receiving from the customers microservice.
        /// </summary>
        /// <returns></returns>
        Task<(bool IsSuccess, dynamic Customer, string ErrorMessage)> GetCustomerAsync(int id);


        //C# 4.0 (. NET 4.5) introduced a new type called dynamic that avoids compile-time type checking.
        //A dynamic type escapes type checking at compile-time; instead, it resolves type at run time.
        //A dynamic type variables are defined using the dynamic keyword.
    }
}
