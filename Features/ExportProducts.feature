@Chrome @Datahub-Stage @Admin @MedicalDevices

Feature: Export Products 
	
Scenario: To Export Product
	Given the user navigate to Home page
	Given navigate to product manage
	When user clicks on Export All Products from table
	Then Export confirmation popup is displayed
	When user click on Continue button
	Then Green colour confirmation box is displayed
	And Notification count is incremented by 1

Scenario: To verify Exported file
    Given the user navigate to Home page
	When user click on Export centre icon
	Then Export centre is displayed with Exported date as current date
	And Exported status is Completed
	And Exported file is present
	When user opens the Exported file
	Then selected products are present in the exported file