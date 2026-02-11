using Pure.Chart.Model.Abstractions;
using Pure.Primitives.Abstractions.Guid;

namespace Pure.Chart.RelationalModel.Abstractions;

public interface IChartRelationalModel : IChart
{
    public IGuid Id { get; }

    public IGuid XAxisId { get; }

    public IGuid YAxisId { get; }
}
