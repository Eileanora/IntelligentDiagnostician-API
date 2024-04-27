﻿namespace IntelligentDiagnostician.DataModels.Models;

public class Error : PrimaryKeyBaseEntity
{
    public string ProblemCode { get; set; } = string.Empty;
    public TroubleCode TroubleCode { get; set; }
}
