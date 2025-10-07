# Contributing to Echovoice.JSON

First off, thank you for considering contributing to Echovoice.JSON! It's people like you that make this project better for everyone.

## Code of Conduct

This project and everyone participating in it is governed by our Code of Conduct. By participating, you are expected to uphold this code. Please report unacceptable behavior to the project maintainers.

## How Can I Contribute?

### Reporting Bugs

Before creating bug reports, please check the existing issues list as you might find out that you don't need to create one. When you are creating a bug report, please include as many details as possible:

* **Use a clear and descriptive title** for the issue to identify the problem.
* **Describe the exact steps which reproduce the problem** in as many details as possible.
* **Provide specific examples to demonstrate the steps**.
* **Describe the behavior you observed after following the steps** and point out what exactly is the problem with that behavior.
* **Explain which behavior you expected to see instead and why.**
* **Include code samples** that demonstrate the issue.

### Suggesting Enhancements

Enhancement suggestions are tracked as GitHub issues. When creating an enhancement suggestion, please include:

* **Use a clear and descriptive title** for the issue to identify the suggestion.
* **Provide a step-by-step description of the suggested enhancement** in as many details as possible.
* **Provide specific examples to demonstrate the steps**.
* **Describe the current behavior** and **explain which behavior you expected to see instead** and why.
* **Explain why this enhancement would be useful** to most users.

### Pull Requests

* Fill in the required template
* Do not include issue numbers in the PR title
* Follow the C# coding style used throughout the project
* Include tests that cover your changes
* Ensure all tests pass
* Update documentation as needed
* End all files with a newline

## Development Process

### Setting Up Your Development Environment

1. Fork the repository
2. Clone your fork:
   ```bash
   git clone https://github.com/YOUR-USERNAME/Echovoice.JSON.git
   cd Echovoice.JSON
   ```
3. Add the upstream repository:
   ```bash
   git remote add upstream https://github.com/echovoice/Echovoice.JSON.git
   ```
4. Install .NET 9.0 SDK or later

### Building the Project

```bash
dotnet restore
dotnet build
```

### Running Tests

```bash
dotnet test
```

### Running Tests with Coverage

```bash
dotnet test -c Release /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
```

We aim to maintain at least 80% code coverage (currently at 98.3%). Please ensure your changes don't significantly decrease coverage.

### Code Style

This project uses EditorConfig for consistent coding style. Most modern IDEs will automatically pick up the `.editorconfig` file. Key points:

* Use 4 spaces for indentation
* Use `PascalCase` for public members
* Use `camelCase` for local variables and parameters
* Add XML documentation comments for all public APIs
* Follow existing patterns in the codebase

### Commit Messages

* Use the present tense ("Add feature" not "Added feature")
* Use the imperative mood ("Move cursor to..." not "Moves cursor to...")
* Limit the first line to 72 characters or less
* Reference issues and pull requests liberally after the first line

Example:
```
Add support for JSON object parsing

- Implement JSONObjectDecoder class
- Add comprehensive unit tests
- Update documentation

Closes #123
```

### Testing Guidelines

* Write tests for all new functionality
* Ensure tests are deterministic and don't depend on external resources
* Use descriptive test method names that explain what is being tested
* Follow the Arrange-Act-Assert pattern
* Use FluentAssertions for assertions

### Documentation

* Update README.md if you change functionality
* Add XML documentation comments for all public APIs
* Update CHANGELOG.md following the Keep a Changelog format
* Include code examples for new features

## Project Structure

```
Echovoice.JSON/
├── Echovoice.JSON/          # Main library
│   ├── JSONDecoders.cs      # Decoding functionality
│   ├── JSONEncoders.cs      # Encoding functionality
│   └── Pretty/              # Pretty printing
├── Echovoice.JSON.Tests/    # Unit tests
└── README.md                # Project documentation
```

## Release Process

Releases are handled by project maintainers. The process is:

1. Update version in `Echovoice.JSON.csproj`
2. Update `CHANGELOG.md`
3. Create a git tag
4. Push to GitHub
5. Publish to NuGet

## Questions?

Feel free to open an issue with your question or reach out to the maintainers.

## License

By contributing to Echovoice.JSON, you agree that your contributions will be licensed under the MIT License.
