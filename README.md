# Draco.UserManagement
User Management for Draco (An imaginary company)

The Draco Dwarf is a spheroidal galaxy which was discovered by Albert George Wilson of Lowell Observatory in 1954 on photographic plates of the National Geographic Society's Palomar Observatory Sky Survey.

## Usermanagement

Project read data from json store and displays it on console. With an ability to add custom data provider.

## How to add customer provider
Register UserManagementServices with generic overload
```
AddUserManagementServices<CustomerProvider>()
```

## Future work

- Integration Test
- For big json files I will add some sort of caching where only some of the json will exist in memory and rest of it will still be on disk.
