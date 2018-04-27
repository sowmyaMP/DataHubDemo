@Chrome @Datahub-Stage @Admin @GS1USEnterprise1

Feature: Product Create Module
	Here we have introduced here product module of Datahub application.
	We are going to create a product using Selenium Specflow.
	
Scenario: Create a product
	Given the user navigate to Home page
	Given the user navigate to Product create page
	When enter product mandatory details 
	Then the result should show created successfully
	
Scenario: Search for the Product
	Given the user navigate to Home page
	Given navigate to product manage
	When enter search product in datatable
	Then product is displayed successfully

