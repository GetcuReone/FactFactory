# Welcome to the GetcuReone.FactFactory

Welcome to my Factory of Facts project. This project implements a mechanism for obtaining some facts on the basis of others.

## Basic concepts

### Fact

Some information about something.
The factory cannot alter the facts in any way. It can only manipulate them.

### Rule

A rule is a set of instructions that can calculate a fact.
A rule may use one or more existing facts for calculation or not use them at all.

### Fact factrory

In the framework of the current project, a fact factory is a machine that can receive other facts based on certain facts.
In fact, a factory cannot somehow alter or create facts. She controls only their movement.
If we reduce the capabilities of the factory to simple actions, then it can:

- Find out the possibility of calculating a fact by the rule;
- Perform fact calculation through the rule;
- Extract computed fact from rule;
- Return requested facts.

Using these 4 simple steps as a basis, I was able to implement a machine that can calculate a fact for you or say what facts are not enough to calculate it.

I would also like to note that this project is only one of GetcuReone projects.

You can find more information on [the project wiki](https://github.com/GetcuReone/FactFactory/wiki)
