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
 - This is a Blazor/ Razor Pages Web Application, Enjoy
 
## Create Reddit Client App - Browse PhotoshopBattles Subreddit

Cleaner UI for browsing photoshopped images, utilizing the same Reddit UI Hierarchy

## CRITERIA SELECTED FROM @CodeLouisville [WIKI](https://github.com/CodeLouisville/Student-Resources/wiki/Project-Requirements)

-  Create another class which inherits one or more properties from its parent
-  Create a class, then create at least one object of that class and populate it with data
   > Card Model for rendering Data
-  Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program
-  Connect to an external/3rd party API and read data into your app
-  Read data from an external file, such as text, JSON, CSV, etc and use that data in your application
   > Using API data, Using user settings for sorting
-  Calculate and display data based on an external factor (ex: get the current date, and display how many days remaining until some event)
   > Will have to convert API.Date to utc; Say how long since posted (EX. 10 days ago)
-  Visualize data in a graph, chart, or other visual representation of data
   > CSharp WebApp

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
      -  [ ] Render in Modal
      -  [ ] \(OPTIONAL) Redirect URL with Article ID as Query
-  [x] Method to return to last search

### Add Some Spicy CSS \(Keep It Simple)

### :shipit: Ship App

> Due Date: July 31, 2020 (12pm EST)
