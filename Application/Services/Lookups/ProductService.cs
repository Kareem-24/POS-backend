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
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {

            request.ID = await _unitOfWork.Product.GetNextIdAsync();
            var product = _mapper.Map<Product>(request);
            await _unitOfWork.Product.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return Result.SuccessResult(product.ID);
        }

        public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (request.ID <= 0)
            {
                return Result.FailureResult("invalid product ID");
            }

            var product = _mapper.Map<Product>(request);
            await _unitOfWork.Product.UpdateAsync(product);
            await _unitOfWork.CompleteAsync();
            return Result.SuccessResult(product.ID);
        }

        public async Task<Result> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productLst = await _unitOfWork.Product.GetAllAsync();
            return Result.SuccessResult(productLst);
        }

        public async Task<Result> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Product.FindAsync(x => x.ID == request.ID);
            return Result.SuccessResult(product);
        }

        public async Task<Result> Handle(HideProductCommand request, CancellationToken cancellationToken)
        {
            var productResult = await _unitOfWork.Product.FindAsync(x => x.ID == request.ID);
            if (productResult == null)
            {
                return Result.FailureResult("product not found");

            }
           
            var product = productResult.FirstOrDefault();
            if (product == null)
            {
                return Result.FailureResult("product not found");

            }
            if ( product.Quantity > 0 )
            {
                return Result.FailureResult("product has Quantity , can't hide");
            }
            product.IsActive = false;
            await _unitOfWork.Product.UpdateAsync(product);
            await _unitOfWork.CompleteAsync();
            return Result.SuccessResult(product.ID);
        }
    }





    public class GetProductByIdQuery : IRequest<Result>
    {
        public required int ID { get; set; }
    }

    public class GetAllProductsQuery : IRequest<Result>
    {

    }

    public class AddProductCommand : ProductModel, IRequest<Result>
    {
    }

    public class UpdateProductCommand : ProductModel, IRequest<Result>
    {
    }

    public class HideProductCommand : IRequest<Result>
    {
        public required int ID { get; set; }
    }
}
