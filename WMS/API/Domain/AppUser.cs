﻿using Microsoft.AspNetCore.Identity;

namespace Domain;

public class AppUser : IdentityUser
{
    public string DisplayName { get; set; }
    public string Bio { get; set; }
    public string Title { get; set; }
    public string Phone { get; set; }
    public ICollection<Roles> Roles { get; set; }
}
