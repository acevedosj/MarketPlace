
# MarketPlace

Product catalog and shopping cart with Angular.JS and ASP.NET. 
The project is deployed in Azure (Note: it will be available until June 7)
As an AppService the urls respectively are:
* website https://marketplace1.azurewebsites.net
* api site https://marketplace1.azurewebsites.net

Microsoft Azure SQL Database is used for data storage

## Features


* Create product category(this from the product category menu)
* Create products(this from the product menu)
* List products
* Search for products
* Add products to the shopping cart
* Remove product from shopping cart
* see purchase summary

## Frameworks and library

* Boostrap
* toastr
* jquery
* Insight Database
* .Net Frameworks 4.6.1

## Deployment
To locally deploy the project, it is necessary to have IIS (internet information server) and SQL Server.
In sql server create a database called MarketPlace and in this run the scripts that
are in the MarketPlace.Database database project, running the scripts
in the following order:
* those found in the tables folder: 1.ProductCategories.sql and 2.Products.sql
* those found in the Procedures folder
* those found in the Scripts folder: 1.ProductCategories.sql and 2.Insert_Product.sql
In the IIS publish the project called MarketPlace, we navigate them and take note of the url. Note before doing this, configure the project's web config
MarketPlace, the connection string, to point to the database created in the previous point.
Once the MarketPlace project is published, we open the project called MarketPlace.Web and in the services folder we will find a file called ConnectApi
which we are going to edit and in the value of the Connection property, we are going to put the URL of the MarketPlace site in quotes.
Once this is done, I proceed to publish the MarketPlace.Web project in the IIS. we surf it and our site should be online
