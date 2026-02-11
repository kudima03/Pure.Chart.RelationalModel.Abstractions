using Pure.Chart.Model.Abstractions;
using Pure.Primitives.Abstractions.Guid;

namespace Pure.Chart.RelationalModel.Abstractions;

public interface IAxisRelationalModel : IAxis
{
    public IGuid Id { get; }
}
