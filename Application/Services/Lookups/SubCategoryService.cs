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

namespace Application.Services.Lookups
{
    public class SubCategoryService : IRequestHandler<GetSubCategoryByIdQuery,Result>,
         IRequestHandler<GetAllSubCategoriesQuery, Result>,
         IRequestHandler<AddSubCategoryCommand, Result>,
         IRequestHandler<UpdateSubCategoryCommand, Result>,
         IRequestHandler<DeleteSubCategoryCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SubCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Handle(AddSubCategoryCommand request, CancellationToken cancellationToken)
        {

            request.ID = await _unitOfWork.Product.GetNextIdAsync();
            var Subcategory = _mapper.Map<SubCategory>(request);
            await _unitOfWork.SubCategory.AddAsync(Subcategory);
            await _unitOfWork.CompleteAsync();
            return Result.SuccessResult(Subcategory.ID);
        }

        public async Task<Result> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request.ID <= 0)
            {
                return Result.FailureResult("invalid product ID");
            }

            var Subcategory = _mapper.Map<SubCategory>(request);
            await _unitOfWork.SubCategory.UpdateAsync(Subcategory);
            await _unitOfWork.CompleteAsync();
            return Result.SuccessResult(Subcategory.ID);
        }

        public async Task<Result> Handle(GetAllSubCategoriesQuery request, CancellationToken cancellationToken)
        {
            var subCategoryLst = await _unitOfWork.SubCategory.GetAllAsync();
            return Result.SuccessResult(subCategoryLst);
        }

        public async Task<Result> Handle(GetSubCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var subCategory = await _unitOfWork.SubCategory.FindAsync(x => x.ID == request.ID);
            return Result.SuccessResult(subCategory);
        }

       

        public async Task<Result> Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
        {     

            var products = await _unitOfWork.Product.FindAsync(x => x.CategoryId == request.ID);
            if (products.Count() > 0)
            {
                return Result.FailureResult("Category has Products , can't delete");

            }

            var category = _unitOfWork.SubCategory.DeleteAsync(request.ID);
            return Result.SuccessResult(request.ID);
        }

    }





    public class GetSubCategoryByIdQuery : IRequest<Result>
    {
        public required int ID { get; set; }
    }

    public class GetAllSubCategoriesQuery : IRequest<Result>
    {

    }

 

    public class AddSubCategoryCommand : SubCategoryModel, IRequest<Result>
    {
    }

    public class UpdateSubCategoryCommand : SubCategoryModel, IRequest<Result>
    {
    }

    public class DeleteSubCategoryCommand : IRequest<Result>
    {
        public required int ID { get; set; }

    }
}
