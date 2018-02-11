# Property Info via Linq

This simple project grabs property name using Linq. Inspired by [this](https://stackoverflow.com/a/2916344/1834787) awesome StackOverFlow post.

[Nuget Link](https://www.nuget.org/packages/GetPropertyInfoViaLinq/)

Get property info via Linq's Expression

```csharp
IGetPropertyInfoViaLinq<Person> _utility = new GetPropertyInfoViaLinq<Person>();

// returns: "Parents.GreatParents.Parents.FatherName"
_utility.GetPropertyName(x => x.Parents.GreatParents.Parents.FatherName);

// returns custom attributes via linq
_utility.GetAttribute(x => x.Parents.GreatParents.Parents.FatherName, typeof(DisplayAttribute));
```

Notes:
* Please see the unit test project for more info on how to use the package.
