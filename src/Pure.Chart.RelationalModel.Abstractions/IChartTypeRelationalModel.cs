using Pure.Chart.Model.Abstractions;
using Pure.Primitives.Abstractions.Guid;

namespace Pure.Chart.RelationalModel.Abstractions;

public interface IChartTypeRelationalModel : IChartType
{
    public IGuid Id { get; }
}
