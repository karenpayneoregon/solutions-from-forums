using System.Data;
using Dapper;

namespace NewtonsoftDateOnlyTimeOnlyApp.Classes;

/// <summary>
/// Provides a custom type handler for mapping <see cref="DateOnly"/> values 
/// to and from database fields using Dapper.
/// </summary>
public class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
{
    public override void SetValue(IDbDataParameter parameter, DateOnly value)
    {
        parameter.Value = value.ToDateTime(new TimeOnly(0, 0));
    }

    public override DateOnly Parse(object value)
    {
        return DateOnly.FromDateTime((DateTime)value);
    }
}