# Portfolio
### Personal Portfolio for .NET Code Review (01.19.2018)

#### By Kimberly Bordon

## Description
This is an application that showcases my portfolio work. It includes a blog section that can be logged into with an Administrative User (in this case, myself) to manage blog posts, and also allows site visitors to manage their own comments.

## Specs
| Behavior | Input Example | Output Example |
|-|-|-|
| The app loads up landing page by default. | User goes to homepage url or runs app. | Splash page is displayed. |
| Administrative user can navigate website through navigation bar at the top. | User clicks any of the navigation bar's links. | Page scrolls to that section  |
| 

## Wishlist / To DO
* Remove password leniency.
* Seed the database.

## Setup/Installation
* Make sure you have [.NET Core 1.1 SDK (Software Development Kit)](https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-win-x64.1.1.4.exe) and [.NET runtime](https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-win-x64.1.1.4.exe) both installed.
* You should also have [Visual Studio](https://www.visualstudio.com/downloads/), and [MAMP](https://www.mamp.info/en/downloads/) or other similar software installed.
* Make sure that MAMP is started, and running on port 8889.
* Using your terminal or powershell, clone this repository by typing ```>git clone PUT GIT HUB URL HERE```
    * Alternatively, you can use a browser to download the .zip file from the Github web interface at the URL: PUT GIT HUB URL HERE
* Open Visual Studio, and navigate to the top level of PUT GITHUB FOLDER NAME HERE and double-click on portfolio.sln.
* Using powershell or terminal, navigate to the folder named PUT GITHUB FOLDER NAME HERE. Then enter the following commands:
  ```
  >cd PUT GITHUB FOLDER NAME HERE
  >cd portfolio
  >dotnet restore
  >dotnet ef database update
  ```
  This will set up database onto the server.
* Back in Visual Studio, click the button at the top of the application that looks like a Play button, or press <kbd>⌘</kbd> + <kbd>return</kbd> or <kbd>ctrl</kbd> + <kbd>F5</kbd>. This will automatically run application, and open a browser directly on its homepage.
* Navigate the application as you see fit.

## Known Bugs
None at the moment!

## Technology Used
* ASP.NET
* Visual Studio

## Contact Details
Email Kimberly @ [kbordon@gmail.com](mailto:kbordon@gmail.com) for comments, questions, or concerns.

## License
**_This software is licensed under the MIT License._**

**Copyright © 2018 Kimberly Bordon**
