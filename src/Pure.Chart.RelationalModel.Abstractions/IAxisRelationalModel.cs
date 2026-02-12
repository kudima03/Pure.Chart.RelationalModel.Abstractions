using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.Chart.RelationalModel.Abstractions;

public interface IAxisRelationalModel
{
    public IGuid Id { get; }

    public IString Legend { get; }
}
