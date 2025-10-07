# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.0.0] - 2025-10-06

### Changed
- **BREAKING**: Removed FluentAssertions dependency from test project
- All test assertions now use standard MSTest assertion methods
- Simplified testing infrastructure with zero third-party test dependencies
- Maintained 98.31% line coverage and 97.71% branch coverage
- Package size: 37KB

### Technical Details
- Converted ~150+ fluent assertions to standard MSTest format
- All 28 tests passing with standard `Assert.AreEqual()`, `Assert.IsTrue()`, etc.
- Test project now depends only on MSTest framework
- No impact on library API or functionality - this is purely a test infrastructure change

## [2.0.0] - 2025-10-06

### Added
- Multi-targeting support for .NET Framework 4.5, .NET Standard 2.0, .NET 6.0, .NET 8.0, and .NET 9.0
- Comprehensive XML documentation for all public APIs
- Modern SDK-style project format
- Code coverage with 97.1% coverage
- GitHub Actions CI/CD workflow
- Modern README with badges and comprehensive documentation
- EditorConfig for consistent code style
- Global.json for SDK version management

### Changed
- Migrated from NUnit to MSTest v3 for unit tests
- Updated FluentAssertions to v6.12.1
- Modernized project structure and build system
- Enhanced nullable reference type annotations
- Updated copyright to 2025

### Fixed
- Cross-platform file path handling in tests
- Nullable reference warnings on modern .NET versions

### Improved
- Better XML documentation coverage
- More consistent coding style with EditorConfig
- Improved package metadata for NuGet

## [1.0.0] - 2015

### Added
- Initial release
- JSON array encoding and decoding
- Pretty printing support
- String slicing extension methods
