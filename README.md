# FluentGuard

FluentGuard is a fluent syntax guard library for use in .Net projects.  The latest version of the library incorporates object pooling for improved performance.  The overhead for using FluentGuard compared to a typical static guard class is minimal (in the range of 50-200 nanoseconds.  That said, if you are obsessed with squeezing every  nanosecond of performance out of your application, I would not recommend a fluent syntax guard library.

The library is heavily tested and contains just over 4000 unit tests.  It contains published dll's for .Net framework 4.0, 4.5, and 4.6 as well as .Net Standard 1.2, 1.4 and 2.0.  The fluent design of the library insures that all guard methods you are presented with are relevant to the data type you are validating.  In most cases you do not need to determine the type of exception to throw, the library decides the appropriate exception based on the guard check.  However, should you wish to throw a custom exception, you are free to do so.

# Examples
Below is an example of checking an object for null.
```csharp
Validate.That(nameof(myObject), myObject).IsNotNull().OtherwiseThrowException();
```

The following is an example of a compound fluent guard statement
```csharp
Validate.That(nameof(myNumber), myNumber).IsGreaterThan(0).And.IsLessThan(10).OtherwiseThrowException();
```
