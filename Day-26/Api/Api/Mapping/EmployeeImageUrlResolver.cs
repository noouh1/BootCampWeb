using Api.Dto;
using Api.Models;
using AutoMapper;

namespace Api.Mapping;

public class EmployeeImageUrlResolver(IHttpContextAccessor httpContextAccessor) : IValueResolver<Employee, EmployeeDto, string>
{
    public string Resolve(Employee source, EmployeeDto destination, string destMember, ResolutionContext context)
    {
        if (string.IsNullOrEmpty(source.ImageUrl))
            return null;

        var request = httpContextAccessor.HttpContext.Request;
        return $"{request.Scheme}://{request.Host}{source.ImageUrl}";
    }
}