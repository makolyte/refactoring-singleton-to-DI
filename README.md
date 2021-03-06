# Step 0 - Starting point

You're using the singleton pattern everywhere with hardcoded dependencies. You wanted to make sure there's only a single instance of these classes and using static accessors is really convienent at first. You decide to refactor to use the DI pattern instead.

# Step 1 - Refactor to the DI pattern

1. Remove the singleton pattern by creating a public constructor and passing in dependencies (instead of hardcoding them)
2. Create interfaces for dependencies that might need different concrete implementations (or mocked out). i.e. IOrderRepository, ILogger
3. In the composition root (the main entry point of the program), create single instances and pass in dependencies.

At the end, Main() should look like this:
```
//composition root
var logger = new Logger();
var repository = new InMemoryRepository(logger);
var cancelOrderHandler = new CancelOrderHandler(logger, repository);
    
//using it
cancelOrderHandler.Handle(new CancelOrder(1));
```

# Step 2 - Use a DI library

Wiring up your object graph manually is fine for small projects. It can get out of hand quickly though, and it doesn't take long to have 100's of lines of code just newing up your object graph. This can get tedious. This is where a DI library comes in handy. This abstracts away the tediousness.

1. Add a DI library
2. In the composition root, create a DI container
3. Instead of newing up all your instances, register your types with the DI container _as singletons_ (to fulfill the original requirement of wanting only a single instance of each class)
4. Get an instance of CancelOrderHandler from the DI container and use it

At the end, it should look something like this:
```
//getting the instance from the container
var cancelOrderHandler = container.Get<CancelOrderHandler>();

//using it
cancelOrderHandler.Handle(new CancelOrder(1));
```

# Refactoring practice
1. Clone this repository
2. Open up the Step0-StartingPoint project.
3. Do the refactoring steps

Note: Use whatever DI library you want.

To maximize learning, I suggest starting with the Step0-StartingPoint project, and then taking a look at the Step1 and Step2 projects for reference.

# References
1. Names and dependencies are from this realistic-looking example: https://docs.simpleinjector.org/en/latest/quickstart.html
2. Singleton pattern: https://refactoring.guru/design-patterns/singleton
3. Ninject examples: https://github.com/ryber/Ninject-Examples
4. Ninject documentation: https://github.com/ninject/Ninject/wiki/Dependency-Injection-With-Ninject
