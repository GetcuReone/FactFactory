# FactFactoryBase

The base class that implements the logic of the fact factory. Implementation [here](../FactFactory/FactFactory/FactFactoryBase.cs).

Fact factory 4 basic elements:

- Container with facts. More [here](FactContainer.md);

- Rules collection. Simple [rules](Rule.md) collection;

- Methods for requesting facts. [WantFact](../FactFactory/FactFactory/Interfaces/IFactFactory.cs#41);

- Methods for deriving facts. [Derive](../FactFactory/FactFactory/Interfaces/IFactFactory.cs#28).

Work algorithm:

1. Create a fact factory object;

2. Add rules to the factory;

3. Add available facts to container;

4. Request a fact derivation;

5. Derive fact.

Examples [here](../FactFactory/FactFactoryTests/FactFactoryT/FactFactoryTests.cs).

## Additional features

Fact factories inherited from a FactFactoryBase are able to work with special facts by default.

### NotContained

Using this fact, you say: "The fact should not be contained in the container at the time of derive". Implementation [here](../FactFactory/FactFactory/Facts/NotContained/NotContained.cs).

Examples of working with fact [here](../FactFactory/FactFactoryTests/FactFactoryT/NotContainedTests.cs).

### NoDerived

Using this fact, you say: “Fact cannot be calculated on the basis of available information”. Implementation [here](../FactFactory/FactFactory/Facts/NoDerived/NoDerived.cs).

Examples of working with fact [here](../FactFactory/FactFactoryTests/FactFactoryT/NoDerivedTests.cs).

### Default Facts

- [StartDateOfDerive](../FactFactory/FactFactory/Facts/StartDateOfDerive.cs).

- [DerivingFacts](../FactFactory/FactFactory/Facts/DerivingFacts.cs)

- [StartDateOfDeriveCurrentFacts](../FactFactory/FactFactory/Facts/StartDateOfDeriveCurrentFacts.cs).

- [DerivingCurrentFacts](../FactFactory/FactFactory/Facts/DerivingCurrentFacts.cs)

Examples of working with these facts [here](../FactFactory/FactFactoryTests/FactFactoryT/DeriveTests.cs#165).
