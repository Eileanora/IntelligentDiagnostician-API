﻿using System.ComponentModel.DataAnnotations;

namespace IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;

public class CarSystemForUpdateDto
{
    [Required(ErrorMessage = "Name should be filled in")]
    [MaxLength(20)]
    public string CarSystemName { get; set; } = string.Empty;
}
