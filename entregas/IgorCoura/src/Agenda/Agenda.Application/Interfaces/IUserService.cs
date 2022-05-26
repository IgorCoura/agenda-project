using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Application.Model;

namespace Agenda.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> Register(CreateUserModel model);
        Task<UserModel> Edit(UpdateUserModel model);
        Task<UserModel> RecoverById(int id);
        Task<IEnumerable<UserModel>> RecoverAll();
        Task<UserModel> Remove(int id);
    }
}
