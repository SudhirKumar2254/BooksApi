To create classess from existing db in core, please use below command

Scaffold-DbContext "Server=localhost;Database=Test;User=sa;password=Sitecore@123;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities