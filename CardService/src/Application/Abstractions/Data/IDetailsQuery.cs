using Domain.Details;

namespace Application.Abstractions.Data;
public interface IDetailsQuery
{
    Task<DetailsCard> GetDetailsCard(string NumeroTarjeta);
}
