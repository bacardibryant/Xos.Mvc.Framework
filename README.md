<h1>XOS.MVC.Framework</h1>

<p>
A set of .NET (C#) base classes, extensions, javascript and css helpers to aid in rapid web application development.
</p>

<h3> Getting Started</h3>
<p><em>Installation</em></p>
<p>
  To install the latest version from <a href="https://www.nuget.org/packages/XOS.MVC.Framework/" target="_blank">NuGet</a> using the Package Manager Console in <a href="https://www.visualstudio.com/" target="_blank">Visual Studio</a>, use the command:<br />
  <code>PM> install-package xos.mvc.framework</code>
 </p>
 <p>While earlier versions of the source code are not archived, earlier nuget package versions remain active. In order to install a specific version of the package, use the command:</p>
  <p><code>PM> install-package xos.mvc.framework -version x.x.x</code><br />
  where x.x.x is the desired version.
</p>
  <p>For example:<br />
  <code>PM> install-package xos.mvc.framework -version 3.1.0</code><br />
  will install the version just prior to the latest as of this writing.
</p>
 
<p><em>Uninstalling</em></p>
<p>
  To remove the package installed via the Package Manager Console, use the command:<br />
  <code>PM> uninstall-package xos.mvc.framework</code>
</p>
<p>
  If the source was added to your project manually, simply delete the <code>~/Framework</code> folder just so long as it is the folder containing the source code for Xos.Mvc.Framework.
</p>

<h3>Summary</h3>
<p>
The Xos.Mvc.Framework project aims to speed up development by providing useful base classes, extensions, filters, and scripts for ASP.NET MVC applications. While the features are not exhaustive (in some cases only the plumbing for a feature exists, it hasn't been implemented), these components may serve as templates for implementation in an application.
</p>
<p>
When installed, the host project maintains its original structure and Xos.Mvc project simply adds a folder named Framework with all necessary sub-directories, classes and other assets. This keeps the tools in one place and allow for clean updates without polluting the project with magic directories and mystery files. Another benefit is that a simple directory delete operation removes the framework from the application (or if installed via the Package Manager Console then <code>uninstall-package xos.mvc.framework</code>.
</p>
<p>
The framework directory contains some sub-directories which are empty. These sub-directories act as stubs for the most logical types of extensions to come. Whether implemented in your own project or by the authors of this project, the sub-directories serve as a structural roadmap for the project.
</p>

<h3>Key Features</h3>

<em>Some key project features are:</em>
<ul>
  <li>
    Extensions to the optimization system by adding a <code>~/Framework/Infrastructure/FrameworkBundleConfig.cs</code> file which adds additonal script and style bundles found
    in the respective subdirectories. The stylesheets are implemented as overrides which should be used to add custom style definitions
    without modifying the base corporate, bootstrap, or other main template.<br /><br />
  </li>
  <li>
    <code>~/Framework/Models/BaseModel.cs</code> and <code>~/Framework/Models/BaseUser.cs</code> are base classes that add common properties when used in derived models.<br /><br />
  </li>
  <li>
    <code>~/Framework/Infrastructure/BaseDbContext.cs</code>, <code>~/Framework/Infrastructure/BaseRepository.cs</code> and <code>~/Framework/Infrastructure/IBaseRepository.cs</code> serve as base classes which implement the repository pattern with generics. This functionality can be leveraged with derived classes such as an <code>ApplicationDbContext.cs</code> and <code>ApplicationRepository.cs</code> classes.<br /><br />
   </li>
   <li>
     Javascript, more specifically jQuery helper functions, found in <code>~/Framework/Scripts/jquery-form-defaults.js</code> provide default form behavior. <code>~/Framework/Scripts/scripts-not-found.js</code> is a fallback script when attempting to load optional javascript libraries such as the <code>jquery.ui.timepicker.js</code> plugin which is supported by the framework but not included by default. <code>~/Framework/Scripts/xos-js-exceptions.js</code> holds the custom javascript exceptions that can be called by the framwork. Finally, <code>~/Framework/Scripts/xos-js-extensions.js</code> provide extensions to javascript types.<br /><br />
    </li>
    <li>
      <code>Extensions.cs</code> provides extensions for .NET system types <code>DateTime</code> and <code>int</code>, as well as the .NET Framework type <code>IEnumerable<<T>></code> which iterates over the collection and performs an Action on each item within the collection.<br /><br />
    </li>
    <li>
      Finally, a set of AttributeFilters found in the Framework/Filters directory folder, that are simply stubbed out to allow for domain specific implementations.<br /><br />
    </li>
  </ul>

<small>
  Copyright 2013-2018 XNODE Solutions, LLC
  Released under MIT License
  All code provided herein is provided AS-IS.
</small>
