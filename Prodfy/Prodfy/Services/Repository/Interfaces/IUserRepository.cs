using Prodfy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodfy.Services.Repository.Interfaces
{
    interface IUserRepository : IRepository<User>
    {
        User ObterPorId(int id);
        void DeletarTodasTabelas();
        List<User> ObterDispositivoId();
    }
}
