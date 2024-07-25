using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;

namespace BE.Repository.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly CourseOnlContext _context;
        public TransactionRepository(CourseOnlContext context)
        {
            _context = context;
        }

        public async Task AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }
    }
}