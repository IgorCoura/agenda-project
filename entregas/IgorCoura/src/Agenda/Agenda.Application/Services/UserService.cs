using Agenda.Application.Exceptions;
using Agenda.Application.Interfaces;
using Agenda.Application.Model;
using Agenda.Application.Params;
using Agenda.Domain.Entities;
using Agenda.Domain.Entities.Enumerations;
using Agenda.Domain.Interfaces;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Infrastructure.utils;
using AutoMapper;

namespace Agenda.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserModel> Register(CreateUserModel model)
        {
            var entity = _mapper.Map<User>(model);
            entity.Password = PasswordHasher.Hash(model.Password);
            var result = await _userRepository.RegisterAsync(entity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UserModel>(result);
        }

        public async Task<UserModel> Edit(UpdateUserModel model)
        {
            var entity = await _userRepository.FirstAsync(e => e.Id == model.Id) ?? throw new NotFoundRequestException($"Usuario com id: {model.Id} não encontrado.");

            _mapper.Map<UpdateUserModel, User>(model, entity);
            var result = await _userRepository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<UserModel>(result);
        }

        public async Task<UserModel> RecoverById(int id)
        {
            var result = await _userRepository.FirstAsync(filter: c => c.Id == id) ?? throw new NotFoundRequestException($"Usuario com id: {id} não encontrado.");
            return _mapper.Map<UserModel>(result);
        }

        public async Task<IEnumerable<UserModel>> Recover(UserParams query)
        {
            var results = await _userRepository.GetDataAsync(filter: query.Filter());
            return _mapper.Map<IEnumerable<UserModel>>(results);
        }


        public async Task<IEnumerable<UserModel>> RecoverAll()
        {
            var results = await _userRepository.GetDataAsync();
            return _mapper.Map<IEnumerable<UserModel>>(results);
        }

        public async Task<UserModel> Remove(int id)
        {
            var result = await _userRepository.FirstAsync(u => u.Id == id) ?? throw new NotFoundRequestException($"Usuario com id: {id} não encontrado.");
            await _userRepository.DeleteAsync(new User { Id = id});
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UserModel>(result);
        }

    }
}
