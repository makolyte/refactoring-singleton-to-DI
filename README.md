# Refactoring steps
1. Starting point = Everything is a singleton with hardcoded dependencies.
2. Refactor to the DI pattern by manually wiring up the dependencies in the program's entry point
4. Refactor to using a DI library (I'll show Ninject)

# References
1. Names and dependencies are from this realistic-looking example: https://docs.simpleinjector.org/en/latest/quickstart.html
2. Singleton pattern: https://refactoring.guru/design-patterns/singleton
3. Ninject examples: https://github.com/ryber/Ninject-Examples
4. Ninject documentation: https://github.com/ninject/Ninject/wiki/Dependency-Injection-With-Ninject
