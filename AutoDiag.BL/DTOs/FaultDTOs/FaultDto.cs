﻿using AutoDiag.BL.DTOs.TroubleCodeDTOs;

namespace AutoDiag.BL.DTOs.FaultDTOs;
public class FaultDto
{
    public int Id { get; set; }
    public string ProblemCode { get; set; } = string.Empty;
    public string ProblemDescription { get; set; } = string.Empty;
    public int? Severity { get; set; }
    public DateTime CreatedDate { get; set; }
    public ICollection<TroubleCodeLinkDto?> TroubleCodeLinks { get; set; } = new List<TroubleCodeLinkDto>();
}
