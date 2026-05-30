# BeyondNet.Factory

<p>
  <strong>English</strong> | <a href="README.es.md">Español</a>
</p>

BeyondNet.Factory is a .NET library aimed at improving the factory and abstract factory patterns by introducing configuration-driven behavior. It enables developers to create structured factories that simplify object instantiation across different .NET applications.

## Features

- **Configuration-Driven Factory**: Create factories with setup records for cleaner instantiation
- **Fluent API**: Chain configuration with an expressive builder interface
- **Interceptor Support**: Add custom logic before/after object creation
- **DI Integration**: Seamless integration with Microsoft.Extensions.DependencyInjection
- **Generic Support**: Work with generic types for better type safety
- **Extensible**: Easily add custom setup sources and interceptors

## Architecture

The library is organized into modular packages:

```
BeyondNetCode.Shell.Factory              # Core factory patterns
BeyondNetCode.Shell.Factory.Installer    # DI extension methods
```

## Installation

```bash
# Core library
dotnet add package BeyondNetCode.Shell.Factory

# DI installer
dotnet add package BeyondNetCode.Shell.Factory.Installer
```

## Usage

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

### Interceptors

```csharp
public class MyInterceptor : AbstractFactoryInterceptor
{
    public override void OnBeforeCreate(Type type, object[] args)
    {
        Console.WriteLine($"Creating: {type.Name}");
    }
}
```

## Testing

```bash
dotnet test
```

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for GitFlow workflow and coding standards.

## Versioning

See [VERSIONING.md](VERSIONING.md) for SemVer strategy.

## License

MIT - See [LICENSE](LICENSE)

## Acknowledgments

See [DISCLAIMER.md](DISCLAIMER.md) for original code authorship.