#region using

using AutoMapper;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Domain.Entities;

#endregion

namespace IUSTConvocation.Application.MapperProfile;

public sealed class LoginProfile : Profile
{
    public LoginProfile()
    {
        CreateMap<LoginRequest, User>();
        CreateMap<User, LoginResponse>();
    }
}


public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<StudentSignupRequest, User>();
        CreateMap<StudentSignupRequest, Student>();
        CreateMap<UserSignUpRequest, User>();
        CreateMap<User, SignUpResponse>();
        CreateMap<UserSignUpRequest, SignUpResponse>();
    }
}


public sealed class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<AddressRequest, Address>();
        CreateMap<Address, AddressResponse>();
    }
}


public sealed class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<StudentRequest, Student>();
        CreateMap<Student, StudentResponse>();
        CreateMap<StudentUpdateRequest, Student>();
    }
}


public sealed class DepartmentProfile : Profile
{
    public DepartmentProfile()
    {
        CreateMap<DepartmentRequest, Department>();
        CreateMap<Department, DepartmentResponse>();
        CreateMap<DepartmentUpdateRequest, Department>();
    }
}


public sealed class ConvocationProfile : Profile
{
    public ConvocationProfile()
    {
        CreateMap<ConvocationRequest, Convocation>();
        CreateMap<Convocation, ConvocationResponse>();
        CreateMap<ConvocationUpdateRequest, Convocation>();
    }
}




public sealed class SeatProfile : Profile
{
    public SeatProfile()
    {
        CreateMap<SeatRequest, Seat>();
        CreateMap<SeatUpdateRequest, Seat>();
        CreateMap<Seat, SeatResponse>();
    }
}

public sealed class SeatAllocationProfile : Profile
{
    public SeatAllocationProfile()
    {
        CreateMap<SeatAllocationRequest, SeatAllocation>();
        CreateMap<SeatAllocationUpdateRequest, SeatAllocation>();
        CreateMap<SeatAllocation, SeatAllocationResponse>();
    }
}

public sealed class AttendeProfile : Profile
{
    public AttendeProfile()
    {
        //CreateMap<AttendeRequest, OtherAttendee>();
        //CreateMap<AttendeUpdateRequest, OtherAttendee>();
        //CreateMap<OtherAttendee, AttendeResponse>();
    }
}


public sealed class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeeRequest, Employee>();
        CreateMap<Employee, EmployeeResponse>();
    }
}

public sealed class GuestProfile : Profile
{
	public GuestProfile()
	{
		CreateMap<GuestRequest, Guest>();
		CreateMap<GuestUpdateRequest, Guest>();
		CreateMap<Guest, GuestResponse>();
	}
}

public sealed class MemberProfile : Profile
{
    public MemberProfile()
    {
        CreateMap<MemberRequest, Member>();
        CreateMap<MemberUpdate, Member>();
        CreateMap<Member, MemberResponse>();
    }
}

public sealed class RegistrationProfile : Profile
{
    public RegistrationProfile()
    {
        CreateMap<RegistrationRequest, Registration>();
        CreateMap<RegistrationUpdate, Registration>();
        CreateMap<Registration, RegistrationResponse>();
    }
}


public sealed class VenueProfile : Profile
{
    public VenueProfile()
    {
        CreateMap<VenueRequest, Venue>();
        CreateMap<VenueUpdateRequest, Venue>();
        CreateMap<Venue, VenueResponse>();
    }
}


public sealed class GownProfile : Profile
{
    public GownProfile()
    {
        CreateMap<GownRequest, Gown>();
        CreateMap<GownUpdateRequest, Gown>();
        CreateMap<Gown, GownResponse>();
    }
}


public sealed class AppFileProfile : Profile
{
    public AppFileProfile()
    {
        CreateMap<AppFileRequest, AppFile>();
        CreateMap<AppFile, AppFileResponse>();
    }
}


public sealed class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<AppOrderRequest, AppOrder>();
        CreateMap<AppOrder, AppOrderResponse>();
    }
}

public sealed class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<ContactRequest, Contact>();
        CreateMap<Contact, ContactResponse>();
    }
}