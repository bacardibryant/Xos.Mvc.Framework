Xos.Mvc
Copyright 2013 XNODE Solutions, LLC
Released under MIT License
All code provided herein is provided AS-IS.

Summary
The Xos.Mvc Project aims to speed up development by providing useful base classes, extensions, filters, and scripts to ASP.NET MVC applications.
While the features are not exhaustive (in some cases only the plumbing for a feature exists, it hasn't been implemented), the components are a launching pad
for an ASP.NET MVC Application.

The host project maintains its orginal structure and Xos.Mvc adds a Framework folder keeping the tools in one place and allowing for clean updates
that do not pollute the project folder structure as well as allowing for a simple directory delete operation to remove it (although the cleanest way
to remove the framework would be to use the package manager console if installed with NuGet).

The framework directory contains some sub-directories which are empty. These sub-directories act as stubs for the most logical types of extensions to come.
Whether implemented in your own project or by the authors of this project, the sub-directories serve as a structural roadmap for the project.

Version 3.0 Release Notes 14 December 2017

This is a breaking release. This is a major version release because some files and projects have been removed for cleanliness.
- Deletions
	- The Xos.Mvc.Tests project was never used and therefore removed.
	- The respond and html5shiv scripts were not directly used by the framework only referenced for convenience and thus removed.
	- The IDisposable implementation on the Framework\Models\BaseModel.cs class was removed as the model does not need to implement the interface.
	- The Framework\Content\ie8-overrides.css file along with its reference in the FrameworkBundleConfig were removed because IE8 workarounds are deprecated.

- Additions/Updates
	- A README.txt file that provides an overview of the project.
	- Comments to much of the code that explains it usage or potential usage.
	- Changed Framework Target to .NET Framework 4.7.1.
	- Updated all eligible packages to target framework 471 in host project (this has no affect on the framework classes).