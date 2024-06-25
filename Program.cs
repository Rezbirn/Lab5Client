using Lab5Client.API;
using Lab5Client.Models;
using Lab5Client.Enums;

var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUmV6YmlycCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlVzZXIiLCJleHAiOjE3MTk0MTk2NzIsImlzcyI6IlJlemJpcnAifQ.hHdMgwMDWLIULdXdFWDh32dyN7KgQCHFoVpE2HqLwd4";

var addressAPI = new AddressAPI(token);
var addressGetAll = await addressAPI.Get();
var addressGetId3 = await addressAPI.Get(3);
Console.WriteLine(string.Join('\n', addressGetAll));
Console.WriteLine(new string('*', 20));
Console.WriteLine(addressGetId3);
var resultDelete = await addressAPI.Delete(5);
Console.WriteLine(resultDelete);
addressGetAll = await addressAPI.Get();
Console.WriteLine(new string('*', 20));
Console.WriteLine(string.Join('\n', addressGetAll));
var resultPost = await addressAPI.Post(new Address()
{
    Country = Country.Ukraine,
    City = "TestAPI",
    Street = "TestAPI2",
    HouseNumber = "123A",
});
Console.WriteLine(resultPost);

