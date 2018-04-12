# ContactManagement_Evolent
Contact Management web application using Asp.net MVC, Enitity Framework and Web API.

Project Description:

Design and implement a production ready application for maintaining contact information. Please choose the frameworks, packages and/or technologies that best suit the requirements.

### Expected functionality:

add a contact

list contacts

edit contact

delete contact


### Required Contact model:

First Name

Last Name

Email

Phone Number

Status (Possible values: Active/Inactive)


# Getting Started

IDE: Visual Studio 2013

Change connection string in .config files to connect to your database.

Web APP:  Web.config Setup
Location: ~\ContactManagement\Web.config

Test APP: app.config Setup
Location: ~\ContactManagement.Tests\App.config

<connectionStrings>
  <add name="ContactsDBEntities" connectionString="metadata=res://*/Models.Entities.ContactDB.csdl|res://*/Models.Entities.ContactDB.ssdl|res://*/Models.Entities.ContactDB.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(LocalDB);initial catalog=ContactsDB;user id=xxx;password=xxx;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
</connectionStrings>

## Thank You
