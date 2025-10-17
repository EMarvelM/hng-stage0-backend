# HNG STAGE ZERO BACKEND TASK - C# / ASP.NET Core API

A sipole REST API that returns my profile information. the current UTC Tmestamp, and a random cat fact from Cat Fact API

## Features
- Provides a /me endpoint
- Returns profile info (name, email, stack)
- Fetches a live cat fact from [catfact.ninja](https://catfact.ninja/fact)
- Includes dynamic UTC timestamp
- Handles API errors gracefully
- Responds with JSON format

## Tech Stack

- C# / .NET 8
- ASP.NET Core Minimal API
- HttpClient for external API call


## Getting Started (Local Setup)

### Step-by-step setup guide:

1. Clone this repo

```bash
git clone https://github.com/EMarvelM/hng-stage0-backend.git
cd hng-stage0-backend
```

2. Restore dependencies

```bash
dotnet restore
```

3. Run the project
```bash
dotnet run
```

4. Visit -  To Test
```bash
http://localhost:5212/me
```


### Response Sample
> Example of what the /me endpoint returns

```json
{
  "status": "success",
  "user": {
    "email": "maviwurd@gmail.com",
    "name": "Egbe Marvelous Martins",
    "stack": "C# / ASP.NET Core"
  },
  "timestamp": "2025-10-17T18:49:33.183Z",
  "fact": "Cats sleep 70% of their lives."
}
```

## Deployment

Add your live API URL:

#### [Live link]()


## Author

**Name**: Egbe Marvelous Martins

**Email**: maviwurd@gmail.com

**Stack**: C# / ASP.NET Core


## Acknowledgements

- [Cat Facts API](https://catfact.ninja)
- **HNG Internship** Stage 0 guidelines