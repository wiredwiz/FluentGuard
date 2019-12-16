# FluentGuard

FluentGuard is a fluent syntax guard library for use in .Net projects.  The latest version of the library incorporates object pooling for improved performance.  The overhead for using FluentGuard compared to a typical static guard class is minimal (in the range of 50-200 nanoseconds.  That said, if you are obsessed with squeezing every  nanosecond of performance out of your application, I would not recommend a fluent syntax guard library.

Compound conditionals using 'And' and 'Or' are evaluated in the order in which they occur.  This means you need to be careful about how you chain together compound guard checks.

The library is heavily tested and contains just over 4000 unit tests.  It contains published dll's for .Net framework 4.0, 4.5, and 4.6 as well as .Net Standard 1.2, 1.4 and 2.0.  If you wish to use the library, I recommend adding a reference to the binaries on Nuget.  You can find the library by looking for Edgerunner.FluentGuard.  The fluent design of the library insures that all guard methods you are presented with are relevant to the data type you are validating.  In most cases you do not need to determine the type of exception to throw, the library decides the appropriate exception based on the guard check.  However, should you wish to throw a custom exception, you are free to do so.

# Examples
Below is an example of checking an object for null.
```csharp
Validate.That(nameof(myObject), myObject).IsNotNull().OtherwiseThrowException();
```

The following is an example of a compound fluent guard statement
```csharp
Validate.That(nameof(myNumber), myNumber).IsGreaterThan(0).And.IsLessThan(10).OtherwiseThrowException();
```

Throwing a custom exception is as simple as follows
```csharp
Validate.That(nameof(myNumber), myNumber).IsPositive().OtherwiseThrow(new MyException());
```

Below is an example of a much more complex compound guard statement
```csharp
Validate.That(nameof(myNumber), myNumber)
  .IsEqualTo(10).Or.IsEqualTo(15).Or.IsGreaterThan(100).OtherwiseThrowException();
```
