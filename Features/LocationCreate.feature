@Chrome @Datahub-Stage @Admin @GS1USEnterprise1

Feature: Location Create Module
	Here we have introduced location module of Datahub application.
	We are going to create a location using Selenium Specflow.
	
Scenario: Create a Location
	Given the user navigate to Home page
	Given navigate to location create page
	When enter location mandatory details
	Then the result should show created successfully
	
Scenario: Search for the Location
	Given the user navigate to Home page
	Given navigate to location manage
	When enter search location in datatable
	Then location is displayed successfully


