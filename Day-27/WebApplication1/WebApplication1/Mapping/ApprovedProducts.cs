using AutoMapper;
using WebApplication1.Dto;

namespace WebApplication1.Mapping;

public class ApprovedProducts : Profile
{
    public ApprovedProducts()
    {
        CreateMap<ApprovedProductDto,ApprovedProducts>();
    }
    
}