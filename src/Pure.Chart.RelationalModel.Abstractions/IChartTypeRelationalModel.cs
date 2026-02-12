using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.Chart.RelationalModel.Abstractions;

public interface IChartTypeRelationalModel
{
    public IGuid Id { get; }

    public IString Name { get; }
}
