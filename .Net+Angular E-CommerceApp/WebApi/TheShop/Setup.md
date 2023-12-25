To start this project you will need sql server installed.

You will need two databases one for identity and one for the application data. 

Put the connection string of your database in the appsettings.json file.

Next you need to open package manager console with the DataAccess project, and execute update-database -context StoreContext to add the migrations to the store database and -context AppIdentityDbContext for the identity database.

After the first start of the project the database will be populated from the files in DataAccess/Data/SeedData.

If you want to make some changes to the seed data you can do it in those files.