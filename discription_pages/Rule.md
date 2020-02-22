# Rule

The rule. A set of instructions that are used to calculate another fact. Must implement an [IFactRule](../FactFactory/FactFactory/Interfaces/IFactRule.cs) interface.

This interface defines 5 highlights:

- what fact the rule can calculate

- what facts are needed to calculate

- Is it possible to calculate the fact based on the facts contained in the container

- can calculate the fact

- comparison with another rule
