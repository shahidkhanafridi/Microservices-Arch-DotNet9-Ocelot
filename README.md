# Microservices-Arch-DotNet9-Ocelot
Implementation of the Microservices Architecture with API Gateway using .NET 9 and Ocelot

## Postman Collection
The file named "MSA-DotNet9-Ocelot.postman_collection.json" included all the necessary endpoint calls to Gateway as well as direct APIs

## Below are Some Dummy Users you can try:
```csharp
[
    new User("admin", "admin", "Admin", ["users.read", "users.write", "posts.read", "posts.write"]),
    new User("user", "user", "User", null),
    new User("userAuther", "userAuther", "Auther", ["users.write"]),
    new User("userReader", "userReader", "Reader", ["users.read"]),
    new User("userModerator", "userModerator", "Moderator", ["users.read", "users.write"]),
    new User("postAuther", "postAuther", "Auther", ["posts.write"]),
    new User("postReader", "postReader", "Reader", ["posts.read"]),
    new User("postModerator", "postModerator", "Moderator", ["posts.read", "posts.write"])
];
```
