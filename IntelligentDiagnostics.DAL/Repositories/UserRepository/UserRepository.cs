﻿using IntelligentDiagnostics.DAL.Context;
using IntelligentDiagnostics.DAL.Repositories.BaseRepository;
using IntelligentDiagnostics.DataModels.Models;

namespace IntelligentDiagnostics.DAL.Repositories.UserRepository;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
