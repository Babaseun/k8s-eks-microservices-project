namespace UserService.Entities;

public class User
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }
    

    public DateTime DateOfBirth { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsAdmin { get; set; }

    // The user's status (e.g., active, inactive)
    public string Status { get; set; }

    public string PhoneNumber { get; set; }
}
