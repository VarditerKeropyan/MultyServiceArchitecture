
using Common.Enums;
using Entities;
using Repositories;
using Services.Interfaces;

namespace Services;

public class BankingService : IBankingService
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<TransactionHistory> _transactionHistoryRepository;

    public BankingService(
        IRepository<User> userRepository, 
        IRepository<TransactionHistory> transactionHistoryRepository)
    {
        _userRepository = userRepository;
        _transactionHistoryRepository = transactionHistoryRepository;
    }

    public async Task Credit(int userId, float amount)
    {
        var user = await GetUser(userId);

        user.Balance += amount;
        await _userRepository.UpdateAsync(user);

        var transaction = new TransactionHistory()
        {
            UserId = user.Id,
            Ammount = amount,
            TransactionType = TransactionType.Credit,
        };
        await _transactionHistoryRepository.AddAsync(transaction);
    }

    public async Task Debit(int userId, float amount)
    {
        var user = await GetUser(userId);

        if (user.Balance < amount)
        {
            throw new InvalidOperationException("Insufficient funds!");
        }
        user.Balance -= amount;
        await _userRepository.UpdateAsync(user);

        var transaction = new TransactionHistory()
        {
            UserId = user.Id,
            Ammount = amount,
            TransactionType = TransactionType.Debit,
        };
        await _transactionHistoryRepository.AddAsync(transaction);
    }

    private async Task<User> GetUser(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
        {
            throw new KeyNotFoundException($"User not found with id: {userId}.");
        }
        return user;
    }
}
