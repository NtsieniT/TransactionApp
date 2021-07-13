TO RUN APPLICATION

1. MAKE SURE DB CONNECTION STRING IS CHANGED TO POINT TO LOCAL INSTANCE ON THE appsettings.json ON THE "Transaction.API" AND "Transaction.Data"
AND ALSO ON THE "TransactionDataContext" OnConfiguring METHOD

2.
//ADD MIGRATION
dotnet ef migrations add -p C:\Users\Ntsieni\Documents\Projects\TransactionApp\Transaction.API\src\Transaction.Data Initial  

3.
//UPDATE DATABASE
dotnet ef database update -p C:\Users\Ntsieni\Documents\Projects\TransactionApp\Transaction.API\src\Transaction.Data -c TransactionDataContext

4. PROGRAM.CS WILL SEED TYPES INITIALLY IF NO TYPES ARE FOUND ON THE DATABASE
	- TYPES FILE READ IS FOUND ON Transaction.Data\SeedData FOLDER. YOU CAN ADD MORE TYPES BEFORE RUNNING THE APPLICATION
	
5. START APPLICATION API src\Transaction.API


6. FOR CLIENT, OPEN SOLUTION AND INSTALL PACKAGES USING NPM INSTALL COMMAND

7. RUN CLIENT USING NG SERVE



