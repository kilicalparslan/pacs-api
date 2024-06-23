using AutoMapper;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeDtos;
using ViewLibrary.Pdks.Dtos.Pdks.AccessPointDtos;
using ViewLibrary.Pdks.Dtos.Pdks.CardDtos;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeCardDtos;
using ViewLibrary.Pdks.Dtos.Pdks.SizeDtos;
using ViewLibrary.Pdks.Dtos.Pdks.UserDtos;
using ViewLibrary.Pdks.Dtos.Pdks.CityDtos;
using ViewLibrary.Pdks.Dtos.Pdks.CountryDtos;
using ViewLibrary.Pdks.Dtos.Pdks.CountyDtos;
using ViewLibrary.Pdks.Dtos.Pdks.CompanyDtos;
using ViewLibrary.Pdks.Dtos.Pdks.BranchDtos;
using ViewLibrary.Pdks.Dtos.Pdks.LanguageDtos;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeLanguageDtos;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeReferanceDtos;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeLeaveDtos;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeTitleDtos;
using ViewLibrary.Pdks.Dtos.Pdks.GroupDtos;
using ViewLibrary.Pdks.Dtos.Pdks.LevelDtos;
using ViewLibrary.Pdks.Dtos.Pdks.RevisedLeaveDtos;
using ViewLibrary.Pdks.Dtos.Pdks.RoleDtos;
using ViewLibrary.Pdks.Dtos.Pdks.TitleDtos;
using ViewLibrary.Pdks.Dtos.Pdks.UserRoleDtos;

namespace pdksApi.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AccessPointAddDto, AccessPoint>().ReverseMap();
            CreateMap<AccessPointUpdateDto, AccessPoint>().ReverseMap();
            CreateMap<AccessPointDto, AccessPoint>().ReverseMap();

			CreateMap<BranchAddDto, Branch>().ReverseMap();
			CreateMap<BranchUpdateDto, Branch>().ReverseMap();
			CreateMap<BranchDto, Branch>().ReverseMap();

			CreateMap<CardAddDto, Card>().ReverseMap();
			CreateMap<CardUpdateDto, Card>().ReverseMap();
			CreateMap<CardDto, Card>().ReverseMap();

			CreateMap<CityAddDto, City>().ReverseMap();
			CreateMap<CityUpdateDto, City>().ReverseMap();
			CreateMap<CityDto, City>().ReverseMap();

			CreateMap<CompanyAddDto, Company>().ReverseMap();
			CreateMap<CompanyUpdateDto, Company>().ReverseMap();
			CreateMap<CompanyDto, Company>().ReverseMap();

			CreateMap<CountyAddDto, County>().ReverseMap();
			CreateMap<CountyUpdateDto, County>().ReverseMap();
			CreateMap<CountyDto, County>().ReverseMap();
		
            CreateMap<CountryAddDto, Country>().ReverseMap();
            CreateMap<CountryUpdateDto, Country>().ReverseMap();
            CreateMap<CountryDto, Country>().ReverseMap();

			CreateMap<EmployeeAddDto, Employee>().ReverseMap();
            CreateMap<EmployeeUpdateDto, Employee>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().
                ForMember(u => u.County, rtt => rtt.MapFrom(q => q.Counties.Name)).
                ForMember(u => u.City, rtt => rtt.MapFrom(q => q.Counties.City.Name)).
                ForMember(u => u.Country, rtt => rtt.MapFrom(q => q.Counties.City.Country.Name)).
                ForMember(u => u.CountryId, rtt => rtt.MapFrom(q => q.Counties.City.Country.Id)).
                ForMember(u => u.CityId, rtt => rtt.MapFrom(q => q.Counties.City.Id)).
				ForMember(u => u.BranchName, rtt => rtt.MapFrom(q => q.Branch.Name)).
				ForMember(u => u.BranchId, rtt => rtt.MapFrom(q => q.Branch.Id)).
				ForMember(u => u.Title, rtt => rtt.MapFrom(q => q.EmployeeTitles.Select(e=>e.Title.Name).FirstOrDefault())).
				ForMember(u => u.TitleId, rtt => rtt.MapFrom(q => q.EmployeeTitles.Select(e=>e.TitleId).FirstOrDefault())).
				ForMember(u => u.CompanyId, rtt => rtt.MapFrom(q => q.Branch.Company.Id)).
				ForMember(u => u.UserId, rtt => rtt.MapFrom(q => q.Users.Select(e => e.Id).FirstOrDefault())).
				ForMember(u => u.CompanyName, rtt => rtt.MapFrom(q => q.Branch.Company.Name));


			CreateMap<EmployeeCardAddDto, EmployeeCard>().ReverseMap();
			CreateMap<EmployeeCardUpdateDto, EmployeeCard>().ReverseMap();
			CreateMap<EmployeeCardDto, EmployeeCard>().ReverseMap();

			CreateMap<EmployeeLanguageAddDto, EmployeeLanguage>().ReverseMap();
			CreateMap<EmployeeLanguageUpdateDto, EmployeeLanguage>().ReverseMap();
			CreateMap<EmployeeLanguageDto, EmployeeLanguage>().ReverseMap();

			CreateMap<EmployeeLeaveAddDto, EmployeeLeave>().ReverseMap();
			CreateMap<EmployeeLeaveUpdateDto, EmployeeLeave>().ReverseMap();
			CreateMap<EmployeeLeave, EmployeeLeaveDto>().ReverseMap();

			CreateMap<EmployeeReferanceAddDto, EmployeeReferance>().ReverseMap();
			CreateMap<EmployeeReferanceUpdateDto, EmployeeReferance>().ReverseMap();
			CreateMap<EmployeeReferanceDto, EmployeeReferance>().ReverseMap();

			CreateMap<EmployeeTitleAddDto, EmployeeTitle>().ReverseMap();
			CreateMap<EmployeeTitleUpdateDto, EmployeeTitle>().ReverseMap();
			CreateMap<EmployeeTitle, EmployeeTitleDto>().ReverseMap();

			CreateMap<GroupAddDto, Group>().ReverseMap();
			CreateMap<GroupUpdateDto, Group>().ReverseMap();
			CreateMap<GroupDto, Group>().ReverseMap();

			CreateMap<LanguageAddDto, Language>().ReverseMap();
			CreateMap<LanguageUpdateDto, Language>().ReverseMap();
			CreateMap<LanguageDto, Language>().ReverseMap();

			CreateMap<LevelAddDto, Level>().ReverseMap();
			CreateMap<LevelUpdateDto, Level>().ReverseMap();
			CreateMap<LevelDto, Level>().ReverseMap();

			CreateMap<RevisedLeaveAddDto, RevisedLeave>().ReverseMap();
			CreateMap<RevisedLeaveUpdateDto, RevisedLeave>().ReverseMap();
			CreateMap<RevisedLeaveDto, RevisedLeave>().ReverseMap();

			CreateMap<RoleAddDto, Role>().ReverseMap();
			CreateMap<RoleUpdateDto, Role>().ReverseMap();
			CreateMap<RoleDto, Role>().ReverseMap();

			CreateMap<SizeAddDto, Size>().ReverseMap();
			CreateMap<SizeUpdateDto, Size>().ReverseMap();
			CreateMap<SizeDto, Size>().ReverseMap();

			CreateMap<TitleAddDto, Title>().ReverseMap();
			CreateMap<TitleUpdateDto, Title>().ReverseMap();
			CreateMap<Title, TitleDto>().
				ForMember(r => r.EmployeeId, opt => opt.MapFrom(s => s.EmployeeTitles.Select(r => r.EmployeeId).FirstOrDefault()));

			CreateMap<UserAddDto, User>().ReverseMap();
			CreateMap<UserUpdateDto, User>().ReverseMap();
			CreateMap<User, UserDto>().
                ForMember(r => r.EmployeeName, opt => opt.MapFrom(s => s.Employee.Name)).
                ForMember(u => u.EmployeeSurname, rtt => rtt.MapFrom(q => q.Employee.Surname));

			CreateMap<UserRoleAddDto, UserRole>().ReverseMap();
			CreateMap<UserRoleUpdateDto, UserRole>().ReverseMap();
			CreateMap<UserRole, UserRoleDto>().
				ForMember(r => r.Role, opt => opt.MapFrom(s => s.Role.Name));

		}
    }
}
