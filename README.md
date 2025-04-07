# .NET JWT Sample

<p id="description">This project is a .NET Core Web API that enables user registration and authentication using JWT (JSON Web Tokens). Users can register and then log in to the application. Authenticated users can obtain a token which grants them access to protected endpoints for the duration of the token's validity.</p>

<h2>🛠️ Installation Steps:</h2>

<p>1. Clone the repository</p>

```
https://github.com/aliketan/.net-JWT-sample.git
```

<p>2. Install dependencies</p>

```
dotnet restore
```

<p>3. Open powershell and change folder to</p>

```
API > Infrastructure > API.Persistence
```

<p>4. Create database</p>

```
run dotnet ef database update
```

<p>5. Run the project</p>

```
dotnet run
```

<h2>💻 Built with</h2>

Technologies used in the project:

*   .NET 9
*   MS-SQL
*   Scalar API Docs
