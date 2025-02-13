using System.Data;
using Dapper;

namespace NewtonsoftDateOnlyTimeOnlyApp.Classes;

/// <summary>
/// Provides a custom type handler for mapping <see cref="TimeOnly"/> values 
/// to and from database fields using Dapper.
/// </summary>
public class TimeOnlyTypeHandler : SqlMapper.TypeHandler<TimeOnly>
{
    public override void SetValue(IDbDataParameter parameter, TimeOnly value)
    {
        parameter.Value = value.ToTimeSpan();
    }

    public override TimeOnly Parse(object value)
    {
        return TimeOnly.FromTimeSpan((TimeSpan)value);
    }
}