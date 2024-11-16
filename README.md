# Microservices-Arch-DotNet9-Ocelot
Implementation of the Microservices Architecture with API Gateway using .NET 9 and Ocelot


## Below are Some Dummy Users you can try:
private readonly List<User> _users =
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