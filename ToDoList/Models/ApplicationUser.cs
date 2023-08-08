using Microsoft.AspNetCore.Identity;

namespace ToDoList.Models;

public class ApplicationUser : IdentityUser
{
    public string CustomTag { get; set; }
}

/*
Create users
Use email and password to authenticate
=> aspnetusers (table) || ApplicationUser

https://www.learnhowtoprogram.com/c-and-net/authentication-with-identity/further-exploration-opportunities-with-identity
*/

/*  Inherited Properties
    
    TKey Id

    User
    Role
    UserClaim
    UserToken
    UserLogin
    - used for third-party provider logins
    RoleClaim
    UserRole

        User < UserClaims
        User < UserLogins
        User < UserTokens

        Role < RoleClaims

        User <> Role => UserRole

    int AccessFailedCount
    string Email
    string NormalizedEmail (case-insensitive)
    string UserName
    string NormalizedUserName
    string PasswordHash
    string PhoneNumber

    bool LockoutEnabled
    - true if user can be locked out
    DateTime LockoutEnd
    
    bool EmailConfirmed
    bool PhoneNumberConfirmed
    bool TwoFactorEnabled

    List<Login> Logins { get; }
    List<Role> Roles { get; }

    Lookup: string SecurityStamp
*/