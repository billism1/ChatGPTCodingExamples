> What programming language is this?
```
interface User {
  name: string;
  id: number;
}
 
class UserAccount {
  name: string;
  id: number;
 
  constructor(name: string, id: number) {
    this.name = name;
    this.id = id;
  }
}
 
const user: User = new UserAccount("Joe", 1);
```

---

This is TypeScript code.

TypeScript is a programming language that is a superset of JavaScript, meaning that any valid JavaScript code is also valid TypeScript code. However, TypeScript adds additional features such as static typing, interfaces, and classes, which are not available in JavaScript.

In the code you provided, an interface called "User" is defined with two properties: "name" of type string and "id" of type number. Then a class called "UserAccount" is defined with the same properties and a constructor that initializes these properties. Finally, an object called "user" is created as an instance of the "UserAccount" class, with the name "Joe" and the ID "1".

---