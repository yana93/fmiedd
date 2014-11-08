Консолно приложение със SQL Server  за четене, писане, редактиране, и изтриване (CRUD) на потребители (users).

class UserRepository
    {
        private readonly string dataString = "Server=.\\SQLEXPRESS;Database=users;Trusted_Connection=True;";
    }

Името на съвъра трябва да бъде променане за да работи програмата 
и базата да се attach-не в sql server


attach -> CRUD_311\CRUD\bin\Debug\users.mdf in Sql Server 