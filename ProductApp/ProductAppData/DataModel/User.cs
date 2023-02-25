

using System.ComponentModel.DataAnnotations;

namespace ProductApp.ProductAppData.DataModel;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 8)]
    public string Password { get; set; }

    [Required]
    public bool IsAdmin { get; set; } = false;

    [Required]
    [StringLength(50)]
    public string UserCountry { get; set; }
    public string? AuthToken { get; set; }
}
