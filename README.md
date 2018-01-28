# Portfolio
### Personal Portfolio for .NET Code Review (01.19.2018)

#### By Kimberly Bordon

## Description
_This is an application that showcases my portfolio work. It includes a blog section that can be logged into with an Administrative User (in this case, myself) to manage blog posts, and allows site visitors to add comments to blog posts. The application also allows site visitors to register an account, which allows the logged in visitor to also delete their own comments._

## Specs
| Behavior | Input Example | Output Example |
|-|-|-|
| The app loads up landing page by default. | User goes to homepage url or runs app. | Splash page is displayed. |
| User can navigate website through navigation bar at the top. | User clicks any of the navigation bar's links. | Page scrolls to that section on home page or loads blog section. |
| User can log in as an Admin user to manage blog. | User logs in with Admin username. | Page displays Blog index with Admin username displayed on top of page and Admin access.|
| User can register an account to delete their own comments. | User registers a username. | Page displays Blog index with new account's username displayed at top. |
| User can comment on blog posts. | User clicks speech bubble icon, and submits comment through form. | Comment is recorded onto page with User's account name, or anonymously. |


## Wishlist/ To-Do
* Remove password leniency.
* Integrate Role management page into an Admin specific page.

## Setup/Installation
* Make sure you have [.NET Core 1.1 SDK (Software Development Kit)](https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-win-x64.1.1.4.exe) and [.NET runtime](https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-win-x64.1.1.4.exe) both installed.
* You should also have [Visual Studio](https://www.visualstudio.com/downloads/), and [MAMP](https://www.mamp.info/en/downloads/) or other similar software installed.
* Make sure that MAMP is started, and running on port 8889. You can check this by clicking Preferences, then clicking the Ports tab, and making sure your MySql port is set to 8889.
* Using your terminal or powershell, clone this repository by typing ```>git clone https://github.com/kbordon/dotnet-wk3-code-review-portfolio.git```
    * Alternatively, you can use a browser to download the .zip file from the Github web interface at the URL: https://github.com/kbordon/dotnet-wk3-code-review-portfolio.git
* Open Visual Studio, and navigate to the top level of `dotnet-wk3-code-review-portfolio` and double-click on `portfolio.sln`.
* Using powershell or terminal, navigate to the folder named `dotnet-wk3-code-review-portfolio` by entering the following commands:
  ```
  >cd dotnet-wk3-code-review-portfolio
  >cd portfolio
  ```
***
  ### ATTENTION: Before you run any code beyond this point, please read the following.

  This app uses the Github API, and although it doesn't require any authentication to run this application, it will limit requests to **60 per hour**.

  #### If this is sufficient, skip this section.
  ***
  ***
   If you must make more than 60 requests per hour, it will require a **username** and **password**, which must be stored in an `EnvironmentVariables.cs` file in following the path: `Portfolio/Models/EnvironmentVariables.cs`.
   When cloned, this repository does _not_ with come with this file, and will specifically exclude any from commits in the `.gitignore` file.

  * **You must make this file with _your own Github username and password_**. If you do not have an account with GitHub, you can register for one. If you would prefer to not use your password, you can also generate for yourself a personal access token:
    * Start by going to your GitHub account settings.
    * At the bottom of the side menu, click *Developer Settings* and then click *Personal access tokens*.
    * Click the button *Generate new token*, select the settings you'd prefer and make sure to copy down the generated code after submitting.

  * Decide whether you will use a password or a token, then navigate to the Models folder in the Portfolio project, and create an `EnviromentVariables.cs` file.
  * In this file, it should like the following below:

  **Portfolio/Models/EnvironmentVariables.cs**
  ```C#
  using System;

  namespace Portfolio.Models
  {
      public class EnvironmentVariables
      {
          public static string UserAgent = <<REPLACE WITH YOUR USERNAME FOR GITHUB>>;
          public static string Key = <<REPLACE WITH YOUR PASSWORD OR PERSONAL TOKEN>>;
      }
  }
  ```
  * Replace each _<<...>>_ with your the appropriate information as a string (in quotes "YOUR USERNAME").
  * Then go to the `Project.cs` file in the `Portfolio/Models` folder, and on line 30, change the second argument in the AddHeader method from an empty string to the following:
    * `request.AddHeader("User-Agent", EnvironmentVariables.UserAgent);`

  * Remember should you make any commits, or push any code afterwards, when you clone it to a different destination, you will have to recreate this file.

  * If you decide to use a personal token instead of a password, you will have to go to the `Project.cs` file in the `Portfolio/Models` folder.
    * Make sure line 33 is not commented out.
      ```
      request.AddHeader("Authorization", "token " + EnvironmentVariables.Key);
      ```
    * Comment out or remove line 36.
      ```
      client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.UserAgent, EnvironmentVariables.Key);
      ```
***
***
* In terminal, and making sure you're in the Portfolio project folder (where the `Portfolio.csproj` resides), enter the following:
```
>dotnet restore
>dotnet ef database update
```
This will set up database onto the local server.

* Back in Visual Studio, click the button at the top of the application that looks like a Play button, or press <kbd>⌘</kbd> + <kbd>return</kbd> or <kbd>ctrl</kbd> + <kbd>F5</kbd>. This will automatically run application, and open a browser directly on its homepage.
* Running the application will also seed in an administrative, and regular user into the user database. These can be logged into using usernames _Admin_ and _User_, with passwords _admin_ and _user_ respectively.
* Finally, navigate the application as you see fit.

## Known Bugs
* When the user receives the failed log-in page, the navigation links for Home sections Contact and Work will reappear though clicking them will do nothing.

## Technology Used
* ASP.NET
* Visual Studio
* jQuery
* JavaScript
* Sketch
* GitHub
* Icons provided by https://www.flaticon.com

## Contact Details
Email Kimberly @ [kbordon@gmail.com](mailto:kbordon@gmail.com) for comments, questions, or concerns.

## License
**_This software is licensed under the MIT License._**

**Copyright © 2018 Kimberly Bordon**
