# web API

#### Run these commands to install necessary packages
Install-Package Microsoft.EntityFrameworkCore.SqlServer 
Install-Package Microsoft.EntityFrameworkCore.Tools 
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design 

#### To create and run migrations enter that commands on PMC
Add-Migration InitialCreate
Update-Database

#### To remove migrations enter this command on PMC
Remove-Migration
