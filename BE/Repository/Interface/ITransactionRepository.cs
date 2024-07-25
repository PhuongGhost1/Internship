using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface ITransactionRepository
    {
        Task AddTransaction(Transaction transaction);
    }
}