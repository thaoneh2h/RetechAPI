using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.DTOS;

public class UserAddressDTO
{
    public Guid UserAddressId { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 5)]
    public string AddressLine { get; set; }

    [Required]
    [StringLength(100)]
    public string Ward { get; set; }

    [Required]
    [StringLength(100)]
    public string District { get; set; }

    [Required]
    [StringLength(100)]
    public string City { get; set; }

    [Required]
    [StringLength(100)]
    public string Country { get; set; }

    public bool IsPrimary { get; set; }
}
