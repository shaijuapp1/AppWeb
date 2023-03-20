namespace Application.RoleMasters
{
    public class RoleMasterDto
    {
        
      public string Id { get; set; }
      public string Name { get; set; }   
    }

    public class GroupUserDTO
    {
      public string DisplayName { get; set; }
      public string Username { get; set; }
      public string Email { get; set; }
      public string PhoneNumber { get; set; }
      public bool LockoutEnabled { get; set; }
      public bool IsActive { get; set; }  
    }    
}
