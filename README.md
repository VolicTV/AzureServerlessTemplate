# Azure Serverless Template

This is a beginner-friendly Azure serverless application template built with C#. It's ideal for learning and quick project setup, featuring best practices and easy deployment using Azure Functions.

## Project Structure

- `src/`: Contains the main application code
  - `Functions/`: Azure Functions (HTTP and Timer triggers)
  - `Models/`: Data models
  - `Services/`: Business logic and services
  - `host.json`: Configuration file for Azure Functions
- `tests/`: Unit tests for the functions

## Features

- HTTP-triggered function with dependency injection
- Timer-triggered function
- Sample service with async operations
- Unit tests for HTTP-triggered function

## Getting Started

1. Clone this repository
2. Open the solution in Visual Studio or your preferred IDE
3. Restore NuGet packages
4. Build the solution
5. Run the project locally or deploy to Azure

## Running Tests

Use your IDE's test runner or run the following command in the terminal:

```
dotnet test
```

## Deployment

To deploy this project to Azure:

1. Create an Azure Function App in the Azure portal
2. Set up your deployment method (e.g., Azure DevOps, GitHub Actions)
3. Configure your app settings in the Azure portal
4. Deploy your code to the Function App

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the LICENSE file for details.