# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

All `dotnet` commands must be run from the `./src` directory.

```bash
dotnet restore
dotnet build --no-restore -warnaserror
dotnet format --verify-no-changes             # check code style (CI enforces this)
dotnet format && csharpier format .           # auto-fix code style
dotnet pack --configuration Release -p:PackageVersion=<version> --output .
```

There are no test projects in this repository — the CI pipeline only builds and checks formatting.

## Architecture

This is an **interfaces-only NuGet library** — no implementations, no tests, no dependencies beyond `Pure.Primitives.Abstractions`. Every file defines exactly one interface.

**Interfaces (all in `Pure.Chart.RelationalModel.Abstractions`):**
- `IChartRelationalModel` — chart entity: `IGuid Id`, `IString Title`, `IString Description`, `IGuid TypeId`, `IGuid XAxisId`, `IGuid YAxisId`
- `IChartTypeRelationalModel` — chart type lookup: `IGuid Id`, `IString Name`
- `IChartSeriesRelationalModel` — chart series: `IGuid Id`, `IGuid ChartId`, `IString Legend`, `IString XAxisSource`, `IString YAxisSource`
- `IAxisRelationalModel` — axis: `IGuid Id`, `IString Legend`

All property types come from [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions) (sibling repo at `../../Pure.Primitives.Abstractions/`). `IGuid` and `IString` are the only primitives used.

**Multi-targeting:** net7.0, net8.0, net9.0, net10.0. All interfaces must remain AOT-compatible (`IsAotCompatible = true`).

**Package validation:** `EnablePackageValidation = true` with `PackageValidationBaselineVersion = 0.1.0-preview.6.0.0`. Breaking API changes fail the build.

**Publishing:** triggered by pushing a semver tag (`*.*.*`). The tag becomes the `PackageVersion`. The `publish-nuget.yml` workflow publishes to both GitHub Packages and NuGet.org.

## Code Style

Enforced via `.editorconfig`, `dotnet format --verify-no-changes`, and `csharpier check .` in CI:

- No `var` — always use explicit types
- Max line length: 90 characters
- File-scoped namespaces (`namespace Foo;` not `namespace Foo { }`)
- Expression-bodied properties are allowed; expression-bodied methods are **not**
- Private fields: `_camelCase` prefix
- Disabled diagnostics: CA1716 (identifier/keyword conflict), CA1859 (use concrete types), CA1305 (IFormatProvider), CA1720 (property name duplicates type name)

## Commit Messages

Do not mention Claude or AI assistance in commit messages.
