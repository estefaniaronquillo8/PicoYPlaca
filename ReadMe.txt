Pico y Placa - Predictor

   - Is a Windows Forms(.NET Framework) Application created with Visual Studio 2019 using C# language
   - Three different folders were created for better organization:
	Helper:
	   - Class "Validation.cs": 
		- Is a class created specifically for validation of the fields (TextBoxs)
		- It contains two different boolean methods to validate the inputs from
		  the user. 
		- Method "letterFieldValidation": Checks the length and validation of 
		  only letters for the first 3 digits of the license
		- Method "numberFieldValidation": Checks the length and validation of 
		  only numbers for the last 3-4 digits of the license
	Resources:
	   - Image pasted on the design of the Interface 

	View:
	   - "Predictor.cs": 
		- Predictor.cs [Diseño]: Interface of the application. It has:
			- 6 Labels 
			- 2 TextBoxs
			- 1 PictureBox
			- 1 DateTimePicker
			- 1 Button
		- Predictor.cs:
			- Programming behind the tools entered into the design
			- The user can´t enter more of 3 digits on the txtLicenseLetters
			  TextBox and 4 on the txtLicenseNumbers TextBox
			- A personalized TimePicker was manually created 
			- The Button "EnterData":
				- Has the boolean methods from the Validation class on 
				  the Helper folder. 
				- A new variable was created to get the last digit of the license
		|		  plate number
				- A switch was created for checking each day's restriction with
				  the date and last digit
			- A new void method was created to validate the TimePicker restriction
			  in case the day and last digit of the license plate number match 
			  the cases from the switch