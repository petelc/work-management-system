# Work Management System

## Summary

The work management system is a application that enables a user to submit project and/or change requests. These requests will be managed by the Change Management Board and either approved or denied. If approved then the request is placed on a board that is categorized by section from which the task can be either taken by a tech or assigned by manager.

## Persistence

Initially I am using SQLite to develop application. Eventually I want to use SQL Server or Postgres

### **DB Tables**

- [ ] AppUser
- [ ] Assignee
- [ ] Category
- [ ] Change
- [ ] ChangeManager
- [ ] Icon
- [ ] Project
- [ ] ProjectManager
- [ ] Requestor
- [ ] Requests
- [ ] Role
- [ ] Work
- [ ] WorkItem

## Mediator Design Pattern

### What is the Mediator Design Pattern?

A mediator design pattern is one of the important and widely used behavioral design patterns. Mediator enables the decoupling of objects by introducing a layer in between so that the interaction between objects happens via the layer. Real Life

- If the objects interact with each other directly, the system components are tightly coupled with each other making higher maintainability cost and not hard to extend.
- The mediator pattern focuses on providing a mediator between objects for communication and helps in implementing loose coupling between objects.

> _It defines how a mediator object facilitates the interaction between other objects, guiding their behavior and communication without them being directly aware of each other. This pattern emphasizes the behavior and communication patterns among objects._

[^1]: Mediator Design Pattern definition came from [Geeks For Geeks](https://www.geeksforgeeks.org/mediator-design-pattern/)
