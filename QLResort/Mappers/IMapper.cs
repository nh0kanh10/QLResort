using System.Data;
using System.Collections.Generic;

namespace QLResort.Core.Mappers
{
   
    public interface IMapper<TSource, TDestination> where TDestination : new() //có thể sử dụng chung cho nhiều kiểu nguồn và đích khác nhau
    {
        TDestination Map(TSource source);    
    }

    public interface IDataRowMapper<TDestination> : IMapper<DataRow, TDestination> where TDestination : new() // ví dụ TSource là DataRow, TDestination là Guest
    {

    }
}