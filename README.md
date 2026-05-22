# Pure.Chart.RelationalModel.Abstractions

Relational-model interfaces for chart entities in the **Pure** ecosystem — immutable, composable contracts for charts, chart types, series, and axes.

[![.NET build & test](https://github.com/kudima03/Pure.Chart.RelationalModel.Abstractions/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Chart.RelationalModel.Abstractions/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Chart.RelationalModel.Abstractions/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Chart.RelationalModel.Abstractions/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Chart.RelationalModel.Abstractions)](https://www.nuget.org/packages/Pure.Chart.RelationalModel.Abstractions)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Chart.RelationalModel.Abstractions` defines minimal, read-only interfaces that represent the relational structure of chart data. Each interface captures the identifiers and scalar properties that a chart entity carries in a relational model — no rendering logic, no state mutation. Properties are typed using primitives from [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions).

## Interfaces

| Interface | Namespace | Description |
|-----------|-----------|-------------|
| `IChartRelationalModel` | `Pure.Chart.RelationalModel.Abstractions` | A chart entity with identity, title, description, type reference, and X/Y axis references |
| `IChartTypeRelationalModel` | `Pure.Chart.RelationalModel.Abstractions` | A chart type with identity and name |
| `IChartSeriesRelationalModel` | `Pure.Chart.RelationalModel.Abstractions` | A chart series with identity, owning chart reference, legend, and X/Y axis source mappings |
| `IAxisRelationalModel` | `Pure.Chart.RelationalModel.Abstractions` | An axis with identity and legend |

### Member reference

**`IChartRelationalModel`**

| Member | Type | Description |
|--------|------|-------------|
| `Id` | `IGuid` | Unique identifier of the chart |
| `Title` | `IString` | Display title |
| `Description` | `IString` | Human-readable description |
| `TypeId` | `IGuid` | Foreign key to `IChartTypeRelationalModel` |
| `XAxisId` | `IGuid` | Foreign key to the X-axis `IAxisRelationalModel` |
| `YAxisId` | `IGuid` | Foreign key to the Y-axis `IAxisRelationalModel` |

**`IChartTypeRelationalModel`**

| Member | Type | Description |
|--------|------|-------------|
| `Id` | `IGuid` | Unique identifier of the chart type |
| `Name` | `IString` | Display name (e.g. "Line", "Bar", "Pie") |

**`IChartSeriesRelationalModel`**

| Member | Type | Description |
|--------|------|-------------|
| `Id` | `IGuid` | Unique identifier of the series |
| `ChartId` | `IGuid` | Foreign key to the owning `IChartRelationalModel` |
| `Legend` | `IString` | Series legend label |
| `XAxisSource` | `IString` | Data source key mapped to the X axis |
| `YAxisSource` | `IString` | Data source key mapped to the Y axis |

**`IAxisRelationalModel`**

| Member | Type | Description |
|--------|------|-------------|
| `Id` | `IGuid` | Unique identifier of the axis |
| `Legend` | `IString` | Axis legend label |

## Design Principles

- **Immutable** — all interfaces expose only `get` properties; no setters, no mutating methods.
- **Composable** — builds on `Pure.Primitives.Abstractions` primitives (`IGuid`, `IString`) rather than raw BCL types.
- **AOT-compatible** — fully compatible with Native AOT compilation.

## Dependencies

- [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions/tree/4.3.0) — immutable, composable abstractions over .NET primitive types (`IGuid`, `IString`, `INumber<T>`, etc.)

## Target Frameworks

- .NET 7
- .NET 8
- .NET 9
- .NET 10

## Installation

```shell
dotnet add package Pure.Chart.RelationalModel.Abstractions
```

## Usage

Implement the interfaces to represent chart entities in your domain or persistence layer:

```csharp
using Pure.Chart.RelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

public sealed class ChartRecord : IChartRelationalModel
{
    public IGuid Id { get; init; }
    public IString Title { get; init; }
    public IString Description { get; init; }
    public IGuid TypeId { get; init; }
    public IGuid XAxisId { get; init; }
    public IGuid YAxisId { get; init; }
}
```

Consume the interfaces in application code without coupling to a concrete implementation:

```csharp
void PrintChart(IChartRelationalModel chart)
{
    Console.WriteLine($"{chart.Title.StringValue} ({chart.Id.GuidValue})");
}
```
