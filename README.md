
#CODE FIRST APPROCH 

# Package required 

1. Microsoft.EntityFrameworkCore
2. Microsoft.EntityFrameworkCore.Design
3. DB what you are using in my case Microsoft.EntityFrameworkCore.SqlServer
4. Microsoft.EntityFrameworkCore.Tools > for Migration creattion add and update Datbase tools required 

# ADD DB Conntext 

1. Class DB Context added TestEntityContext inherited DBContext from EntityFrameworkCore
2. Tables added in DBSet 
3. Constructor setup is required else migration command Add-Migration will fail.
 # TestEntityContext(DbContextOptions<TestEntityContext> contextOptions)
        : base(contextOptions)
4. Configure in Program class get connection string for TestEntityContext class 

# Run Migration command 
1. Add-Migration InitialCreate 
- This creates a migration based on your DbContext and DbSets.
- The name InitialCreate can be anything descriptive.

2. Update-Database
- This applies the migration to SQL Server.
- It will create the database if it doesn’t exist.

# If table Updated 
1. Add-Migration AddNewFieldsToMyTable
2. Update-Database
 
