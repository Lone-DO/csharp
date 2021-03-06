# csharp

Code Louisville, C# 2020 Project

# How to use
 - Clone project
 - Be sure to install any missing dependencies
 - In the Console, run
 ```
   dotnet run
 ```
 - In the Browser, head to https://localhost:5001/
 - This is a Blazor/ Razor Pages Web Application, After adjusting the options, click the "Search" button
 - If a Post has submissions, they will be rendered once you click the "View Submissions" button
 - Enjoy!
 
## Create Reddit Client App - Browse PhotoshopBattles Subreddit

Cleaner UI for browsing photoshopped images, utilizing the same Reddit UI Hierarchy

## CRITERIA SELECTED FROM @CodeLouisville [WIKI](https://github.com/CodeLouisville/Student-Resources/wiki/Project-Requirements)

-  Create another class which inherits one or more properties from its parent
-  Create a class, then create at least one object of that class and populate it with data
   > Controller/Controller.cs
-  Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program
   > RedditComment.cs
   > RedditPost.cs
   > RedditApi.cs
-  Create a call at least 3 functions or methods, at least one of which must return a value that is used in your application
-  Connect to an external/3rd party API and read data into your app
   > Reddit Api
   > (OPTIONAL) Imgure API
-  Read data from an external file, such as text, JSON, CSV, etc and use that data in your application
   > Using API data, 
-  Calculate and display data based on an external factor (ex: get the current date, and display how many days remaining until some event)
   > Will have to convert Post.UTC to time since posted...; (EX. 10 days ago)
-  Visualize data in a graph, chart, or other visual representation of data
   > Blazor Application

## These are the primary files of this application
-  /Controller
-  /Data
-  /Model
-  /Pages/Index.razor
-  /wwwroot/css/

## Order of Operations

### Pull Data From Reddit Api

-  [x] Create Method for handling calls
   -  [x] Default method to GET Articles from initial Subreddit
      -  [x] Sort method to sort Articles based on user selection...
         > ["hot","new","rising","top"]
      -  [x] Load method to GET more Articles via last child's ID...
             `data.data.children[Object.keys(data.data.children).length - 1].data.name;`
-  [x] Create Method to GET Article Comments

### Render data from Api

-  [x] Create Model
-  [x] Loop Data and replicate Model
   -  [x] Filter Data...
   ```
   for (let post in data) {
     let {
         author,
         created_utc: created, // Post Date in POSIX, * 1000
         id, // Post ID
         permalink, //link to post
         score, //Total between upvotes vs downvotes
         url: src, //full res img
         title,
         thumbnail, //tiny res img
       } = data[post].data;
       created *= 1000;
     }
   ```
   -  [x] Call Model...
   ```
   if (thumbnail !== "self" && thumbnail !== "") {
     body.push(
     <section key={id} className="card">
       <p>{`Posted by u/${author}`}</p>
       <p>{moment(created).fromNow()}</p>
       <p>{`Article ID: ${id}`}</p>
       <p>{`Score: ${Rating(score)}`}</p>
       <p>{`Title: ${title}`}</p>
       <img className="preview" src={src} alt="title" />
       <hr></hr>
     </section>
     );
   }
   ```
   -  [x] Set generated HTML to body
   -  [x] Render body to Razor/ View

### Add Event handlers

-  [x] Method/Button for Sorting
-  [x] OnClick on Article
   -  [x] Call Load Method for Article Content/Comments
      -  [x] Render only images
      -  [ ] \(OPTIONAL) Toggle button for showing all comments
   -  [x] View Content
      -  [x] Render in post
      -  [ ] \(OPTIONAL) Render in Modal
      -  [ ] \(OPTIONAL) Redirect URL with Article ID as Query
-  [x] Method to return to last search

### Add Some Spicy CSS \(Keep It Simple)

### :shipit: Ship App

> Due Date: July 31, 2020 (12pm EST)
