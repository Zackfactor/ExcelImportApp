using ExcelImportApp.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace ExcelImportApp.Data
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
    }
}
