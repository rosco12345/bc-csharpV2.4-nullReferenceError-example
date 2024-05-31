This is a minimal reproduction of an error with the BouncyCastle.Cryptopgraphy C# module.

The project includes NUnit, and BouncyCastle.Cryptography NuGet packages.

Run the `ExampleStringsRoundtrip` unit test with BouncyCastle version 2.3.1 it will pass.

Now run the test using version 2.4.0 it will fail with a `NullReferenceErrorException`.

The exception is raised when trying to retrieve the first recipient. I wonder if this could be related to changes made in [a35474d](https://github.com/bcgit/bc-csharp/commit/a35474d76646504318907bb3bd33e179fbecd997).
