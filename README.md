# Nerdle.Ensure
A really simple C# guard clause/validation library


##### A really simple example

```csharp
public void MyMethod(object myObject, int myInt, Guid myGuid, string myString, IList<int> myList)
{
  Ensure.Argument(myObject).NotNull(); // throws ArgumentNullException
  Ensure.Argument(myInt).Between(0, 100); // throws ArgumentOutOfRangeException
  Ensure.Argument(myGuid).NotDefault(); // throws ArgumentException
  Ensure.Argument(myString).HasContent(); // throws ArgumentException
  Ensure.Argument(myList).NotEmpty(); // throws ArgumentException
  
  var myThing = _myService.FetchSomething();
  Ensure.Value(myThing).NotNull(); // throws InvalidOperationException
  Ensure.Value(myThing.SomeValue).Not(55); // throws InvalidOperationException
  
  Ensure.Value(myThing.SomeValue).In(myList, 
      val => new MyException("{0} wasn't in the list", val); // throws MyException

  // etc...
}
```

See the [wiki](https://github.com/edpollitt/Nerdle.Ensure/wiki) for details
