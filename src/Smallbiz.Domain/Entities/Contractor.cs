using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Smallbiz.Domain.Entities;

public class Contractor
{
    public int Id { get; set; }

    [Required, MaxLength(40)]
    public string Code { get; set; } = "";

    [MaxLength(20)]
    public string? TaxId { get; set; }

    [Required, MaxLength(200)]
    public string Name { get; set; } = "";

    [Required, MaxLength(100)]
    public string Country { get; set; } = "Polska";

    [Required, MaxLength(100)]
    public string City { get; set; } = "";

    [Required, MaxLength(200)]
    public string Street { get; set; } = "";

    [Required, MaxLength(20)]
    public string PostalCode { get; set; } = "";

    [MaxLength(30)]
    public string? Phone { get; set; }

    [MaxLength(150)]
    public string? Email { get; set; }

    public bool IsCustomer { get; set; } = true;
    public bool IsSupplier { get; set; }
    public bool isActive { get; set; } = true;

}
