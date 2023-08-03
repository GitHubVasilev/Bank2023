using AutoMapper;
using Bank.Application.Accounts.ViewModels.Base;
using Bank.Application.Interfaces;
using Bank.Application.Interfaces.Accounts;
using Bank.Domain;

namespace Bank.Application.Accounts.Services
{
    /// <summary>
    /// Абстрактный класс описывает методы для управления счетами
    /// </summary>
    /// <typeparam name="K">Тип viewModel для получения</typeparam>
    public class AccountService<K> : IAccountHeandler<K>
        where K : BaseAccountPostViewModel
    {
        protected readonly IApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public AccountService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Открывает счет. Асинхронный метод
        /// </summary>
        /// <param name="account">Данные для открытия счета</param>
        public virtual async Task CreateAccountAsync(K account, CancellationToken token)
        {
            Account model = _mapper.Map<K, Account>(account!);
            await _context.Accounts.AddAsync(model, token);
        }
    }
}
