# Changelog

All notable changes to Pure.Chart.RelationalModel.Abstractions are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.1.0-preview.6.0.0] — 2026-04-26

### Removed

- `IAxisRelationalModel.ChartId` removed to eliminate a circular dependency
  with `IChartRelationalModel`.

## [0.1.0-preview.5.0.0] — 2026-04-19

### Changed

- `ISeriesRelationalModel` renamed to `IChartSeriesRelationalModel`.

## [0.1.0-preview.4.1.0] — 2026-02-27

### Added

- `IChartRelationalModel.XAxisId` and `IChartRelationalModel.YAxisId`
  restored (previously removed in `0.1.0-preview.4.0.0`).

## [0.1.0-preview.4.0.0] — 2026-02-16

### Removed

- `IChartRelationalModel.XAxisId` and `IChartRelationalModel.YAxisId`
  removed as redundant foreign keys.

## [0.1.0-preview.3.0.0] — 2026-02-14

### Added

- **`IAxisRelationalModel.ChartId`** (`IGuid`).

## [0.1.0-preview.2.0.0] — 2026-02-12

### Fixed

- Removed an incorrect package dependency on `Pure.Chart.Model.Abstractions`;
  the package now depends only on `Pure.Primitives.Abstractions`.

## [0.1.0-preview.1.0.0] — 2026-02-12

### Changed

- **`IChartTypeRelationalModel`**, **`IAxisRelationalModel`**,
  **`ISeriesRelationalModel`**, and **`IChartRelationalModel`** no longer
  inherit from the corresponding `Pure.Chart.Model.Abstractions` interfaces;
  each is now a standalone interface with its own members.
- `IChartTypeRelationalModel` gained `Name` (`IString`).
- `IAxisRelationalModel` gained `Legend` (`IString`).
- `ISeriesRelationalModel` gained `Legend`, `XAxisSource`, and
  `YAxisSource` (`IString`).
- `IChartRelationalModel` gained `Title`, `Description` (`IString`), and
  `TypeId` (`IGuid`).

## [0.1.0-preview.0.1.0] — 2026-02-11

### Added

- Initial release.
- **`IChartTypeRelationalModel`** — extends `IChartType` with `Id` (`IGuid`).
- **`IAxisRelationalModel`** — extends `IAxis` with `Id` (`IGuid`).
- **`ISeriesRelationalModel`** — extends `ISeries` with `Id` and `ChartId`
  (`IGuid`).
- **`IChartRelationalModel`** — extends `IChart` with `Id`, `XAxisId`, and
  `YAxisId` (`IGuid`).
