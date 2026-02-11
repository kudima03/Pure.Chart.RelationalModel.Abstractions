using Pure.Chart.Model.Abstractions;
using Pure.Primitives.Abstractions.Guid;

namespace Pure.Chart.RelationalModel.Abstractions;

public interface ISeriesRelationalModel : ISeries
{
    public IGuid Id { get; }

    public IGuid ChartId { get; }
}
