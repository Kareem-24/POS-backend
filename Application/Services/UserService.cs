using Application.Common;
using AutoMapper;
using Core.Entities;
using Core.Models;
using Core.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork , IMapper mapper ) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Handle(GetUserByIdQuery request , CancellationToken CancellationToken)
        {
            if (request.Id == string.Empty) {
                return Result.FailureResult("User ID cannot be empty.");
            }

            var user = await _unitOfWork.Users.FindAsync(x=>x.Id == request.Id);
            if (user == null)
            {
                return Result.FailureResult("User not found.");
            }
           
            var userModel = _mapper.Map<UserModel>(user);

            return Result.SuccessResult(userModel);
        }


        public async Task<Result> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
           
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            return Result.SuccessResult(user.Id);
        }

        public async Task<Result> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var userLst = await _unitOfWork.Users.GetAllAsync();
            if (userLst == null)
            {
                return Result.FailureResult("User not found.");
            }

            var resultLst = _mapper.Map<List<UserModel>>(userLst);
            return Result.SuccessResult(resultLst);
        }

    }

    public class GetUserByIdQuery : IRequest<Result>
    {
        public required string Id { get; set; }
    }
    public class GetAllUsersQuery : IRequest<Result> { }
    
        public class AddUserCommand : UserModel, IRequest<Result>
        {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        }
}
