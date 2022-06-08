using System.Data.Entity;
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
using FluentValidation;

namespace Agenda.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidatorFactory _validatorFactory;

        public UserService(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork, IValidatorFactory validatorFactory)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validatorFactory = validatorFactory;
        }

        public async Task<UserModel> Register(CreateUserModel model)
        {
            var validation = await _validatorFactory.GetValidator<CreateUserModel>().ValidateAsync(model);
            if (!validation.IsValid)
                throw new BadRequestException(validation);

            var entity = _mapper.Map<User>(model);
            entity.Password = PasswordHasher.Hash(model.Password);
            var result = await _userRepository.RegisterAsync(entity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UserModel>(result);
        }

        public async Task<UserModel> Edit(int id, UpdateUserModel model)
        {
            var entity = await _userRepository.FirstAsync(e => e.Id == id) ?? throw new NotFoundRequestException($"Usuario com id: {id} não encontrado.");
            var contextValidation = new ValidationContext<UpdateUserModel>(model);
            contextValidation.RootContextData["userId"] = id;
            var validation = await _validatorFactory.GetValidator<UpdateUserModel>().ValidateAsync(contextValidation);
            if (!validation.IsValid)
                throw new BadRequestException(validation);

            _mapper.Map<UpdateUserModel, User>(model, entity);
            var result = await _userRepository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<UserModel>(result);
        }

        public async Task<UserModel> EditPassword(int id, UpdatePasswordModel model)
        {
            var entity = await _userRepository.FirstAsync(e => e.Id == id) ?? throw new NotFoundRequestException($"Usuario com id: {id} não encontrado.");

            var validation = await _validatorFactory.GetValidator<UpdatePasswordModel>().ValidateAsync(model);
            if (!validation.IsValid)
                throw new BadRequestException(validation);

            entity.Password = PasswordHasher.Hash(model.Password);
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
