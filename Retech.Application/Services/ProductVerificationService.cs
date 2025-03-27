using AutoMapper;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Application.Services
{
    public class ProductVerificationService : IProductVerificationService
    {
        private readonly IProductVerificationRepository _productVerificationRepository;
        private readonly IDeviceVerificationFormRepository _deviceVerificationFormRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductVerificationService(IProductVerificationRepository productVerificationRepository,
                                          IDeviceVerificationFormRepository deviceVerificationFormRepository,
                                          IProductRepository productRepository,
                                          IMapper mapper)
        {
            _productVerificationRepository = productVerificationRepository;
            _deviceVerificationFormRepository = deviceVerificationFormRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        // Method to schedule a verification request by the seller
        public async Task<DeviceVerificationFormDTO> ScheduleVerificationAsync(DeviceVerificationFormDTO verificationRequest)
        {
            // Map the DTO to the entity model (DeviceVerificationForm)
            var deviceVerificationForm = _mapper.Map<DeviceVerificationForm>(verificationRequest);

            deviceVerificationForm.FormStatus = "Pending";  // Set default value for FormStatus

            // Save the new verification request to the database
            await _deviceVerificationFormRepository.AddAsync(deviceVerificationForm);

            // Map the entity back to DTO to return
            return _mapper.Map<DeviceVerificationFormDTO>(deviceVerificationForm);
        }



        // Method to complete the verification (staff updates result)
        public async Task CompleteVerificationAsync(Guid productId, ProductVerificationDTO verificationResult)
        {
            // Retrieve the product details
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) throw new Exception("Product not found");

            // Retrieve the related DeviceVerificationForm
            var deviceVerificationForm = await _deviceVerificationFormRepository.GetByProductIdAsync(productId);
            if (deviceVerificationForm == null) throw new Exception("Device verification form not found");

            // Create a new product verification entry
            var verification = new ProductVerification
            {
                ProductId = productId,
                UserId = verificationResult.UserId,
                VerificationStatus = "Completed",  // Mark as completed
                VerificationResult = verificationResult.VerificationResult,  // Store verification result
                SuggestPrice = verificationResult.SuggestPrice,  // Suggested price to update selling price
                CreateAt = DateTime.UtcNow
            };

            // Add verification result
            await _productVerificationRepository.AddAsync(verification);

            // Update the product status and price
            product.ProductStatus = verificationResult.VerificationStatus == "Completed" ? "Verified" : "NotVerified";
            product.SellingPrice = verificationResult.SuggestPrice;  // Update selling price with suggested price
            product.Evaluate = verificationResult.VerificationResult;

            // Save changes to the product
            await _productRepository.UpdateAsync(product);

            // Update the device verification form's status
            deviceVerificationForm.FormStatus = verificationResult.VerificationStatus == "Completed" ? "Verified" : "Rejected";

            // Save changes to the device verification form
            await _deviceVerificationFormRepository.UpdateAsync(deviceVerificationForm);
        }

        // Get verification result for a product
        public async Task<ProductVerificationDTO> GetVerificationResultAsync(Guid productId)
        {
            var verification = await _productVerificationRepository.GetByProductIdAsync(productId);
            return _mapper.Map<ProductVerificationDTO>(verification);
        }
    }

}
