# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.0.0] - 2025-10-07

### Added
- Multi-targeting support for .NET Framework 4.5, .NET Standard 2.0, .NET 6.0, .NET 8.0, and .NET 9.0
- Comprehensive XML documentation for all public APIs
- Modern SDK-style project format
- Code coverage with 98.31% line coverage and 97.71% branch coverage
- GitHub Actions CI/CD workflow with automated testing
- Modern README with badges and comprehensive documentation
- EditorConfig for consistent code style
- Global.json for SDK version management
- Contributing guidelines (CONTRIBUTING.md)
- 16 new edge case tests for robust validation

### Changed
- **BREAKING**: Upgraded from .NET Framework 4.5 to multi-platform support
- **BREAKING**: Migrated test framework from NUnit 2.6.4 to MSTest v3.6.1
- **BREAKING**: Removed all third-party test dependencies (FluentAssertions)
- All tests now use standard MSTest assertions for maximum simplicity
- Modernized project structure and build system
- Enhanced nullable reference type annotations (disabled for net45 compatibility)
- Updated copyright to 2025
- Package size reduced to 37KB with zero runtime dependencies

### Fixed
- Cross-platform file path handling in tests
- Nullable reference warnings on modern .NET versions
- Removed legacy NUnit and FluentAssertions packages

### Improved
- Better XML documentation coverage across all public APIs
- More consistent coding style with EditorConfig
- Improved package metadata for NuGet publishing
- Comprehensive test suite with 28 tests covering all functionality
- Build system modernization with global.json and Directory.Build.props

## [2.0.0] - 2015

### Added
- Initial release
- JSON array encoding and decoding
- Pretty printing support
- String slicing extension methods
