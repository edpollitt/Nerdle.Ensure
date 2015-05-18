# Nerdle.Ensure
A really simple C# guard clause/validation library

```csharp
public void Foo(Bar bar)
{
    Ensure.Argument(bar).NotNull();
}
```

Available via Nuget
```csharp
Install-Package Nerdle.Ensure
```

See the [wiki](https://github.com/edpollitt/Nerdle.Ensure/wiki) for examples


