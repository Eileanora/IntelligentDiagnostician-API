﻿namespace AutoDiag.BL.ResourceParameters;

public class PagedList<TEntity> : List<TEntity>
{
    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }

    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }

    public bool HasPrevious => (CurrentPage > 1);
    public bool HasNext => (CurrentPage < TotalPages);

    public PagedList(List<TEntity> items, int count, int pageNumber, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        AddRange(items);
    }
    public PagedList(List<TEntity> items, int count, int pageNumber, int pageSize, int totalPages)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = totalPages;
        AddRange(items);
    }
}
