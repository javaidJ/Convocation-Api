namespace IUSTConvocation.Domain.Enums;

public enum UserRole : byte
{
    Admin = 1,
    Student = 2,
    Employee = 3,
}


public enum Position : byte
{
    Gold = 1,
    Silver = 2,
    Bronze = 3,
}


public enum SeatSection : byte
{
    A = 1,
    B = 2,
    C = 3,
    D = 4,
}


public enum Module : byte
{
    Student = 1,
    Employee = 2,
    Guest = 3,
    Gown = 4,
}


public enum RegistrationStatus : byte
{
    Pending = 1,
    Approved = 2,
    Rejected = 3
}




public enum UserStatus : byte
{
    Active = 1,
    InActive = 2,
    Pending = 3,
    Rejected=4,
}

public enum Gender : byte
{
    Unknown=0,
    Male = 1,
    Female = 2

}

public enum Designation : byte
{
    VC = 1,
    Dean = 2,
    HOD = 3,
    Registrar = 4,
    DuptyRegistrar = 5,
    Professor = 6,
    AssitantProfessor = 7,
    AssociateProfessor = 8,
    SeniorAssistant = 9,
    JuniorAssistant = 10,
    Helpers = 11,
}

public enum JobRole : byte
{
    Organisor = 1,
    Host = 2,
    CrewMember = 3,
    Techinal = 4,
    Other = 5
}

public enum ParticipantRole : byte
{
    //Member=0,
    Singer = 1,
    Poet = 2,
    Dancer = 3,
    StandUpComedian = 4,
    MoralSpeech = 5,
    GeneralSpeech=6,
    Drama=7,
    CheifGuest=8,
    Guest=9,
    Audiance=10,
    Nominee=11,
    Others=12,
}

public enum GownSize : byte
{
    S = 1,
    M = 2,
    L = 3,
    XL = 4,
    XXL = 5,
}

public enum GownStatus : byte
{
    Pending = 1,
    Process = 2,
    Approved = 3,
    Cancelled = 4,
    Return = 5,
    Rejected = 6
}

public enum State
{
    Sringar = 1,
    Budgam = 2,
    Pulwama = 3,
    Shopain = 4,
    Baramullah = 5,
    Ganderbal = 6,
}

public enum District
{
    Sringar = 1,
    Budgam = 2,
    Pulwama = 3,
    Shopain = 4,
    Baramullah = 5,
    Ganderbal = 6,
}

public enum Course : byte
{
    MCA = 1,
    MSCIT = 2,
    MBA = 3,
    IMBA = 4,
    JMC = 5,
    MSCStatistics = 6,
    MSCPhysics = 7,
    MSCChemistry = 8,
    MTechFoodTechnology = 9,
    BSCNursing = 10,
    CE = 11,
    ME = 12,
    ECE = 13,
    CSE = 14,
    EE = 15,
}

public enum PaymentMethod
{
    Card = 1,
    UPI = 2,
    NetBanking = 3,
    Wallet = 4,
    //EMI = 5
}


public enum AppPaymentStatus
{
    Created = 1,
    Authorized = 2,
    Captured = 3,
    Refunded = 4,
    Failed = 5
}

public enum AppOrderStatus
{
    Created = 1,
    Attempted = 2,
    Paid = 3
}

public enum RpRefundStatus
{
    Pending = 1,
    Processed = 2,
    Failed = 3
}