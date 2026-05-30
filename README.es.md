# BeyondNet.Factory

<p>
  <a href="README.en.md">English</a> | <strong>Español</strong>
</p>

BeyondNet.Factory es una libreria .NET orientada a mejorar los patrones factory y abstract factory mediante comportamiento dirigido por configuracion. Permite a los desarrolladores crear fabricas estructuradas que simplifican la instanciacion de objetos en diferentes aplicaciones .NET.

## Caracteristicas

- **Factory Dirigida por Configuracion**: Crear fabricas con registros de configuracion para instanciacion mas limpia
- **API Fluida**: Encadenar configuracion con una interfaz de builder expresiva
- **Soporte de Interceptores**: Agregar logica personalizada antes/despues de la creacion de objetos
- **Integracion DI**: Integracion seamless con Microsoft.Extensions.DependencyInjection
- **Soporte Generico**: Trabajar con tipos genericos para mayor seguridad de tipos
- **Extensible**: Agregar facilmente fuentes de configuracion e interceptores personalizados

## Arquitectura

La libreria esta organizada en paquetes modulares:

```
BeyondNetCode.Shell.Factory              # Patrones factory core
BeyondNetCode.Shell.Factory.Installer    # Metodos de extension DI
```

## Instalacion

```bash
# Libreria core
dotnet add package BeyondNetCode.Shell.Factory

# Instalador DI
dotnet add package BeyondNetCode.Shell.Factory.Installer
```

## Uso

### Definir un Registro de Factory

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

### Configurar y Usar

```csharp
// Usando API fluida
var factory = new FactorySetupCreateBuilder<IFactory>()
    .Create<DoSomething>()
    .When<Criteria>(c => c.Age > 18)
    .Build();

var service = factory.Create<DoSomething>();
var result = service.DoIt("World"); // "Hello, World!"
```

### Registrar con DI

```csharp
services.AddFactory(factory =>
{
    factory.Create<DoSomething>()
        .When<Criteria>(c => c.Age > 18)
        .Create<DoSomethingLessThan18>()
        .When<Criteria>(c => c.Age <= 18);
});
```

### Interceptores

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

## Contribuir

Ver [CONTRIBUTING.md](CONTRIBUTING.md) para el flujo de GitFlow y estandares de codificacion.

## Versionado

Ver [VERSIONING.md](VERSIONING.md) para estrategia de SemVer.

## Licencia

MIT - Ver [LICENSE](LICENSE)

## Reconocimientos

Ver [DISCLAIMER.md](DISCLAIMER.md) para atribucion de autoria del codigo original.