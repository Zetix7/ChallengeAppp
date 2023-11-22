using ChallengeApp;

var user1 = new User("Greg", "passwordGreg");
var user2 = new User("Liz", "passwordLiz");
var user3 = new User("Natalie", "passwordNatalie");

user1.AddScore(2);
user1.AddScore(5);
var result = user1.Result;
Console.WriteLine(result);
