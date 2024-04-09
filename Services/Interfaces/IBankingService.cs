
using Common.Models;

namespace Services.Interfaces;

public interface IBankingService
{
    Task Debit(int userId, float amount);

    Task Credit(int userId, float amount);
}
