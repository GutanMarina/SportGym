#  SportGym – Support for Your Body and Mind

---

## 📑 Table of Contents

- [About](#about)  
- [How to Build](#how-to-build)  
- [Contributors](#contributors)  
---

## 🔬 About
**SportGym** is a modern fitness application built with **C# and .NET** that empowers users to achieve their fitness goals through personalized workout plans, BMI tracking, and informative content. Designed with a clean and intuitive UI, the app provides a seamless experience for both beginners and experienced gym-goers.

> The goal of SportGym is to support a healthy lifestyle by providing essential tools for self-monitoring, motivation, and continuous improvement.

The visual part of the site comes from a free template. For this, we integrated it into the project through boundles and other methods.
![mainPage](https://github.com/user-attachments/assets/4c259e83-fff4-44e8-ad53-df0fbf057e9d)

      Figure 1 - General presentation of the site
  Figure 1 shows the general layout of the site, which includes at least 10 pages: Registration, Login, Main Page, Our Blog, BMI, About Us, Contact, Classes, Services, The Team, Gallery, and Search. Additionally, there are two management pages accessible only to the administrator. The Main Page features several layout sections, integrating elements from the other pages to create a cohesive user experience.

# User registration and login

  Below, the functionality and structure of the login and registration pages, as well as the operation with the database, in this context, are presented.
  <p align="center">

  <img src="https://github.com/user-attachments/assets/91f3f2cc-5f3c-4555-84be-7dcef43ab87c" />

       Figure 2 - The session table in the database
  The figure shown shows an SQL query that queries the sessions table of a database named [eUseControl(eStrong.Web)]. The query selects the first 1000 rows from the [Sessions] table and displays the following columns: SessionId, Username, CookieString, and ExpireTime.
<p align="center">
  
  ![registrationSucces](https://github.com/user-attachments/assets/fd7f4042-f705-4517-861f-1728a0eff49a)

</p>
<p align="center">
  
      Figure 3 - Registration page
  As shown in Figure 3 above, the registration page is a form with 3 fields. And after pressing REGISTER we can notice how a new user is added to the database.

<p align="center">
  
  ![login](https://github.com/user-attachments/assets/c951f36c-a68d-4ffa-bf17-15e061246a3a)
        
        Figure 4 - Registration page error
  The figure 4 shows how an error message appears if the user is already in the database

<p align="center">
  
  ![errorLogin](https://github.com/user-attachments/assets/ea31ba56-df13-4380-9fc1-4d8e7ec34ee5)
          
          Figure 5 - Login page error
  The figure 5 shows how an error message appears if the username or password is incorrect.
  
  ![mainPageAfterLogin](https://github.com/user-attachments/assets/5ccf20c9-c304-40ad-bfb7-ffd08f292476)

</p>

      Figure 6 – Successful login
If the user's login is successful, the main page is displayed and the Logout button becomes visible on the screen.


# BMI page
  Logged in users have access to the profile page.
<p align="center">
  
  ![BMI2](https://github.com/user-attachments/assets/95d9225c-40b1-4435-877f-7536664b7a79)
      
      Figure 7 – BMI page
  
  ![BMITable](https://github.com/user-attachments/assets/34b527b4-c0b8-4ba7-9bef-80737d3003da)

      Figure 8 - BMI table In the Data Base
  Figures 7 and 8 show the BMI page, where the user, after logging in, can enter data such as height, weight, age, and gender. The calculated BMI result is then displayed in the table on the left, highlighted in orange. The user can use the calculator as many times as they wish, and the results and data are saved in the BMI table in the database.

# Blog Pages
<p align="center">
 
  <img src="https://github.com/user-attachments/assets/a65912b1-68dc-4679-9d5d-080a102200b6" width="1000" />

      Figure 9 - Blog page
 Figure 9 presents the blog page. The blogs are added using the database and contain both text and dynamic images.

  <img src="https://github.com/user-attachments/assets/18355352-f13a-4bff-a02d-59e3cb1dd411" width="400"/>
  
  <img src="https://github.com/user-attachments/assets/8c9ee188-b7d7-4812-acd3-f299fb63377a" width="400" />
  
</p>
   
      Figure 10 - Blog details page
  Figure 10 shows all the blogs that have been added so far to the database. Each blog includes a title, an image, and a subtitle. By clicking on a blog, a new page opens where the full article is displayed, with dynamically added text and images.
<p align="center">
  <img src="https://github.com/user-attachments/assets/6ac163d4-29ee-4f74-9429-bfd4c8134623" width="1000" />
</p>
   
    Figure 11 - SQL Query for Inserting Blog Entries into the Database
  The next page related to the blog section, displays the SQL query used to insert blog entries into the database. Each blog contains key details such as the title, description, publication date, image path, and full article text.

# Contact and sorting pages
<p align="center">
  
  ![ContactUs](https://github.com/user-attachments/assets/68c75869-08a3-4e7b-af34-00c594444a06)

</p>
     
      Figure 12 – Contact page
 Contact page showing the address, phone numbers, email, an inquiry form, and a map indicating the location.

# Search page
<p align="center">
  
 <img src="https://github.com/user-attachments/assets/d8b37699-19f4-4058-9ac9-d9cdb60ba1c7" width="450" />

</p>

      Figure 13 - Search bar

  <p align="center">

 <img src="https://github.com/user-attachments/assets/f490d160-bf0b-4f0b-8678-6d2ae2e9562d" width="1000" />

 <img src="https://github.com/user-attachments/assets/02458d81-0fef-4e25-a623-1ef88a8e3a42" />

</p>
   
      Figure 14 - Results of search
  The result page is just for blogs. The user can search for any information or words related to blogs, and in this way, the correct blog will appear. If none of the words are found in any of the blogs, the user will be redirected to the blog page where nothing will be displayed.

# Admin pages
<p align="center">
  <img src="https://github.com/user-attachments/assets/28aa2723-a58d-4ab4-a7a7-20eba99e4ec0" width="500" />
      
      Figure 15 - Admin Panel_Blog Management Dashboard
      
<p align="center">
  <img src="https://github.com/user-attachments/assets/5f069067-165b-48d5-b322-2ce1dc37055b" width="500" />

      Figure 16 -  Create New Blog Post Form
  
<p align="center">
  <img src="https://github.com/user-attachments/assets/873b6750-bc22-4472-b770-9a34834c310b" width="500" />

      Figure 17 -  Manage Blog Post Form
  
<p align="center">
  <img src="https://github.com/user-attachments/assets/c449dbb9-5954-499e-9926-fb9050b0f2a3" width="500" />
      
     Figure 18 - Edit Blog Form
 
<p align="center">
  <img src="https://github.com/user-attachments/assets/6417025e-bf12-4ce8-9437-350229e9998b" width="500" />

     Figure 19 -  Delete Blog 
     
<p align="center">
  <img src="https://github.com/user-attachments/assets/f9907ba6-d94d-492b-9d19-dadb8ea4e780" width="500" />

In these figures, the admin dashboard displays a table of blog posts with their IDs, titles, descriptions, and options to edit or delete each entry. If no blogs have been added, the message 'No blogs added at the moment' will appear on the screen. There is also a “Create New” button to add new blog posts to the gym website.  When clicked, it redirects the admin to another page where they can create a new blog by entering all the necessary details. The admin can also edit and delete the blog. 

# Project structure
<p align="center">
  <img src="https://github.com/user-attachments/assets/40612ca0-1cc9-49ba-a378-7dd14ef8e116">
</p>
     
      Figure 20 - Project levels
  As shown in the figure above, the project is divided into 4 levels: BusinessLogic, Domain, Helpers and PresentationLayer.
    
<p align="center">
   <img src="https://github.com/user-attachments/assets/caa8028e-ba0f-4b78-bcc4-5db687d3a5c0" width="350" >
</p>
 
    Figure 21 – Business Logic
  Business Logic is organized as follows: the Core map, the DBModels, where the context of the different entities is located, the Interfaces and classes such as SessionBL, BusinessLogic.
   
<p align="center">
 <img src="https://github.com/user-attachments/assets/99d95ad0-ced8-44e4-b4aa-17a6496a658e" width="350" >
</p>

    Figure 22 – Domain
  Entities such as User, Blog are present at the Domain level.

  <p align="center">
     <img src="https://github.com/user-attachments/assets/f2e4d382-d79c-48f1-beab-5b6c5bd58e7c" width="350">
  </p>
   
    Figure 23 - Helpers 
  The Helpers tier has helper classes for certain functions such as hashing

  <p align="center">
     <img src="https://github.com/user-attachments/assets/880ee2e6-f311-4532-a406-f3b650a01725" width="300" />
     <img src="https://github.com/user-attachments/assets/f0af5dae-d155-4315-bf72-a530dab0a96b" width="300" />
     <img src="https://github.com/user-attachments/assets/63d859b6-22b1-4efa-b26e-9f022e132ab2" width="300" />
  </p>   

    Figure 24 - eStrong.Web

  ## How to Build
To install the application, follow these steps:

1. Clone this repository:
```bash
  git clone https://github.com/GutanMarina/SportGym.git
```

2. Navigate to the project repository:
```bash
  cd path to directory/SportGym
```

3. Additionally, you can connect to SQL Server Management Studio (SSMS), create a new database (e.g., eStrong.Web). Optionally, insert some initial data into the Blogs table.
```bash
<connectionStrings>
  <add name="YOUR_DATABASE_NAME" 
       connectionString="Data Source=YOUR_SERVER_NAME; Initial Catalog=YOUR_DATABASE_NAME; Integrated Security=True; MultipleActiveResultSets=True; App=EntityFramework; TrustServerCertificate=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```
Also, in ApplicationDbContext.cs (located in eStrong.BusinessLogic): Update the constructor call to use your configured connection string name:
```bash
public ApplicationDbContext() :
     base("name=YourBaseName") 
{
}
```
## Contributors

For more details about our project or any general information, feel free to reach out to us.

<a href="https://github.com/Alexandra-Paula"><img src="https://avatars.githubusercontent.com/u/144719877?v=4" title="Manea Alexandra-Paula" width="60" height="60"></a> 
<a href="https://github.com/GutanMarina"><img src="https://avatars.githubusercontent.com/u/149611150?v=4" title="Gutan Marina" width="60" height="60"></a>
<a href="https://github.com/valeriacucoara"><img src="https://avatars.githubusercontent.com/u/182324952?v=4" title="Cucoara Valeria" width="60" height="60"></a>




