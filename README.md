# EmployeeManager

## Building the project
1. Ensure you are in the root of the solution folder. Verify the root directory as shown in the screenshots below  
![Screenshot 1](Screenshots/Root1.png)  
![Screenshot 2](Screenshots/Root2.png)  

2. build the solution  
![Screenshot 3](Screenshots/Build1.png)  
![Screenshot 4](Screenshots/Build2.png)  

3. Publish the project as an executable starting from the Api project.  
![Screenshot 5](Screenshots/Publish1.png)  
-c Release specifies that the app will be released with the release configuration  
-r win-x64 specifies the target runtime, can be changed to linux-x64 or osx-x64 as required  
--self-contained specifies that all required dependencies will be included in the executable   

4. verify executable, it will be located into EmployerManager.Api/bin/Release/net8.0/{runtime}/publish  
![Screenshot 5](Screenshots/Location1.png)  

5. run the executable  
![Screenshot 5](Screenshots/Run1.png)  

6. test as needed  
![Screenshot 6](Screenshots/Test1.png)  
![Screenshot 7](Screenshots/Test2.png)  
![Screenshot 8](Screenshots/Test3.png)  

optional:  
If you prefer not to build the entire project into an executable, you can run and test the code directly within Visual Studio.  
![Screenshot 9](Screenshots/Visual1.png)  
run the https profile  
![Screenshot 10](Screenshots/Visual2.png)  
verify it started correctly  
![Screenshot 11](Screenshots/Visual3.png)  
access Swagger  
![Screenshot 12](Screenshots/Visual4.png)  