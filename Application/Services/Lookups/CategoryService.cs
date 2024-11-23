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
    public class CategoryService : IRequestHandler<GetCategoryByIdQuery,Result>,
        IRequestHandler<GetAllCategoriesQuery, Result>,
        IRequestHandler<GetAllCategoriesWithSubCategoryQuery, Result>,
        IRequestHandler<AddCategoryCommand, Result>,
        IRequestHandler<UpdateCategoryCommand, Result>,
        IRequestHandler<DeleteCategoryCommand, Result>
        
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {

            request.ID = await _unitOfWork.Product.GetNextIdAsync();
            var category = _mapper.Map<Category>(request);
            await _unitOfWork.Category.AddAsync(category);
            await _unitOfWork.CompleteAsync();
            return Result.SuccessResult(category.ID);
        }

        public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request.ID <= 0)
            {
                return Result.FailureResult("invalid product ID");
            }

            var category = _mapper.Map<Category>(request);
            await _unitOfWork.Category.UpdateAsync(category);
            await _unitOfWork.CompleteAsync();
            return Result.SuccessResult(category.ID);
        }

        public async Task<Result> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categoryLst = await _unitOfWork.Category.GetAllAsync();
            return Result.SuccessResult(categoryLst);
        }

        public async Task<Result> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Category.FindAsync(x => x.ID == request.ID);
            return Result.SuccessResult(category);
        }

        public async Task<Result> Handle(GetAllCategoriesWithSubCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.Category.GetAllCatgoriesWithSubCategory();

            if (categories == null || !categories.Any())
            {
                return Result.FailureResult("No categories found.");
            }

            var categoryList = _mapper.Map<List<CategoryModel>>(categories);
            return Result.SuccessResult(categoryList);
        }

        public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var subCategories = await _unitOfWork.SubCategory.FindAsync(x => x.CategoryId == request.ID);
            if (subCategories.Count() > 0)
            {
                return Result.FailureResult("Category has subCategories , can't delete");

            }

            var products = await _unitOfWork.Product.FindAsync(x => x.CategoryId == request.ID);
            if (products.Count() > 0)
            {
                return Result.FailureResult("Category has Products , can't delete");

            }

            var category =  _unitOfWork.Category.DeleteAsync(request.ID);
            return Result.SuccessResult(request.ID);
        }

    }




    public class GetCategoryByIdQuery : IRequest<Result>
    {
        public required int ID { get; set; }
    }

    public class GetAllCategoriesQuery : IRequest<Result>
    {

    }

    public class GetAllCategoriesWithSubCategoryQuery : IRequest<Result>
    {

    }

    public class AddCategoryCommand : CategoryModel, IRequest<Result>
    {
    }

    public class UpdateCategoryCommand : CategoryModel, IRequest<Result>
    {
    }

    public class DeleteCategoryCommand : IRequest<Result>
    {
        public required int ID { get; set; }

    }
}
