using System;
using AutoMapper;
using Nop.Core.Infrastructure.Mapper;
using Nop.Plugin.Misc.EmployeeManagement.Domain;
using Nop.Plugin.Misc.EmployeeManagement.Models;
using Nop.Plugin.Misc.EmployeeManagement.Utils;

namespace Nop.Plugin.Misc.EmployeeManagement.Infrastructure.Mapper;
public class MapperConfiguration : Profile, IOrderedMapperProfile
{
    private readonly string _defaultTime = "00:00:00";
    public int Order => 1;
    public MapperConfiguration()
    {
        CreateMap<EmployeeDomain, EmployeeModel>()
        .ForMember(des => des.DateOfBirth, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.DateOfBirth)))
        .ForMember(des => des.JoinedDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.JoinedDate)))
        .ForMember(des => des.LeaveDate, opt => opt.MapFrom(src => src.LeaveDate != null ? DateOnly.FromDateTime(src.LeaveDate.Value) : (DateOnly?)null))
        .ForMember(des => des.EmployeeRoleName, opt => opt.MapFrom(src => src.EmployeeRole.ToString()));

        CreateMap<EmployeeModel, EmployeeDomain>()
            .ForMember(des => des.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Value.ToDateTime(TimeOnly.Parse(_defaultTime))))
            .ForMember(des => des.JoinedDate, opt => opt.MapFrom(src => src.JoinedDate.Value.ToDateTime(TimeOnly.Parse(_defaultTime))))
            .ForMember(des => des.LeaveDate, opt => opt.MapFrom(src => src.LeaveDate.Value.ToDateTime(TimeOnly.Parse(_defaultTime))))
            .ForMember(des => des.EmployeeRole, opt => opt.MapFrom(src => Enum.Parse<EmployeeRole>(src.EmployeeRoleName)));
    }
}
