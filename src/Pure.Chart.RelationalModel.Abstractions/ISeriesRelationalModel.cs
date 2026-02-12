using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.Chart.RelationalModel.Abstractions;

public interface ISeriesRelationalModel
{
    public IGuid Id { get; }

    public IGuid ChartId { get; }

    public IString Legend { get; }

    public IString XAxisSource { get; }

    public IString YAxisSource { get; }
}
