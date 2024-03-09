namespace Domain.DTOs.Membership;

public class CustomerUpdateDto : UserUpdateDto
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Avatar { get; set; }
}