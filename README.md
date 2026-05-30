<div align="center">
  <h1>BeyondNet.Factory</h1>
  <p><strong>A configuration-driven Factory pattern library for .NET</strong></p>

  <p>
    <a href="README.en.md">🇬🇧 English</a> | <a href="README.es.md">🇪🇸 Español</a>
  </p>

  <p>
    <a href="https://www.nuget.org/profiles/BeyondNetCode">
      <img src="https://img.shields.io/badge/NuGet-BeyondNetCode-blue" alt="NuGet" />
    </a>
    <a href="https://github.com/beyondnetcode/Shell.Factory/actions">
      <img src="https://github.com/beyondnetcode/Shell.Factory/workflows/CI%20/%20CD/badge.svg" alt="Build" />
    </a>
  </p>
</div>

---

Welcome to **BeyondNet.Factory**! A .NET library aimed at improving the factory and abstract factory patterns by introducing configuration-driven behavior.

## Installation

### NuGet Packages

```bash
# Core factory library
dotnet add package BeyondNetCode.Shell.Factory

# Dependency Injection installer
dotnet add package BeyondNetCode.Shell.Factory.Installer
```

### Packages Overview

| Package | Description | NuGet |
|---------|-------------|-------|
| `BeyondNetCode.Shell.Factory` | Core factory patterns with fluent API | [link](https://www.nuget.org/packages/BeyondNetCode.Shell.Factory) |
| `BeyondNetCode.Shell.Factory.Installer` | Microsoft.Extensions.DependencyInjection extensions | [link](https://www.nuget.org/packages/BeyondNetCode.Shell.Factory.Installer) |

## Features

- **Configuration-Driven Factory**: Create factories with setup records for cleaner instantiation
- **Fluent API**: Chain configuration with an expressive builder interface
- **Interceptor Support**: Add custom logic before/after object creation
- **DI Integration**: Seamless integration with Microsoft.Extensions.DependencyInjection
- **Generic Support**: Work with generic types for better type safety
- **Extensible**: Easily add custom setup sources and interceptors

## Quick Start

### Define a Factory Record

```csharp
public interface IDoSomething
{
    string DoIt(string name);
}

public class DoSomething : IDoSomething
{
    public string DoIt(string name) => $"Hello, {name}!";
}
```

### Configure and Use

```csharp
// Using fluent API
var factory = new FactorySetupCreateBuilder<IFactory>()
    .Create<DoSomething>()
    .When<Criteria>(c => c.Age > 18)
    .Build();

var service = factory.Create<DoSomething>();
var result = service.DoIt("World"); // "Hello, World!"
```

### Register with DI

```csharp
services.AddFactory(factory =>
{
    factory.Create<DoSomething>()
        .When<Criteria>(c => c.Age > 18)
        .Create<DoSomethingLessThan18>()
        .When<Criteria>(c => c.Age <= 18);
});
```

## Documentation

For detailed documentation, see the language-specific README files:
- [English](README.en.md)
- [Español](README.es.md)

## Migration from Ums.Shell.Factory

If you were using `Ums.Shell.Factory`, update your NuGet references:

```bash
# Before (Ums.Shell.Factory)
dotnet add package Ums.Shell.Factory

# After (BeyondNetCode.Shell.Factory)
dotnet add package BeyondNetCode.Shell.Factory
```

Update namespaces in your code:
```csharp
// Before
using Ums.Shell.Factory;

// After
using BeyondNetCode.Shell.Factory;
```

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for GitFlow workflow, commit conventions, and coding standards.

## Versioning

See [VERSIONING.md](VERSIONING.md) for SemVer strategy and release process.

## License

Licensed under the MIT License. See [LICENSE](LICENSE) for details.

## Acknowledgments

See [DISCLAIMER.md](DISCLAIMER.md) for original code authorship attribution.