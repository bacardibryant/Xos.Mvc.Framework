<h1>Xos.Mvc.Framework</h1>

<p>
A set of base classes, extensions, javascript and css helpers to aid in rapid web application development.
</p>

<h3>Summary</h3>
<p>
The Xos.Mvc.Framework project aims to speed up development by providing useful base classes, extensions, filters, and scripts for ASP.NET MVC applications. While the features are not exhaustive (in some cases only the plumbing for a feature exists, it hasn't been implemented), these components may serve as templates for implementation in an application.
</p>
<p>
When installed, the host project maintains its orginal structure and Xos.Mvc project simply adds a folder named Framework with all necessary sub-directories, classes and other assets. This keeps the tools in one place and alloww for clean updates that do not pollute the project folder structure of the application, while at the same time, allowing for a simple directory delete operation to remove it from the application (although the cleanest way to remove the framework would be to use the package manager console if installed with NuGet).
</p>
<p>
The framework directory contains some sub-directories which are empty. These sub-directories act as stubs for the most logical types of extensions to come. Whether implemented in your own project or by the authors of this project, the sub-directories serve as a structural roadmap for the project.
</p>

<h3>Key Features</h3>

<em>Some key MVC project features are:</em>
<ul>
  <li>
    Extensions to the optimization system by adding a <code>FrameworkBundleConfig.cs</code> file which adds additonal script and style bundles found
    in the respective subdirectories. The stylesheets are implemented as overrides which should be used to add custom style definitions
    without modifying the base corporate, bootstrap, or other main template.<br /><br />
  </li>
  <li>
    BaseModel and BaseUser classes that add common properties for models when used in derived models.<br /><br />
  </li>
  <li>
    <code>BaseDbContext.cs</code> and <code>BaseRepository.cs</code>, <code>IBaseRepository.cs</code> implements the repository pattern, with generics, which can be leveraged
    with derived <code>ApplicationContext.cs</code> and <code>ApplicationRepository.cs</code> classes.<br /><br />
   </li>
   <li>
     Javascript, more specifically jQuery extensions in <code>jquery-form-defaults.js</code> that provide additonal DOM scripting support.<br /><br />
    </li>
    <li>
      <code>Extensions.cs</code> provides extensions for DateTime, int, and Enumerable<T> which allow for an Action to be perform on each item in the collection.<br /><br />
    </li>
    <li>
      Finally, a set of AttributeFilters that are simply stubbed out to allow for domain specific implementations.<br /><br />
    </li>
  </ul>

<small>
  Copyright 2013-2018 XNODE Solutions, LLC
  Released under MIT License
  All code provided herein is provided AS-IS.
</small>
