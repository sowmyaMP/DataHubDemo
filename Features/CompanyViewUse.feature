@Chrome @Datahub-Stage @Admin @GS1USEnterprise1

Feature: Company view use module
	General UI verification, along with Company search, prefix search, 
	GTIN Search, GLN search, download and list match
	
Scenario: Verify dashboard panel present on the home screen
	Given the user navigate to home page
	When user click on next button
	Then Dashboard Panel is displayed
	
Scenario: Verify Export centre  
	Given the user navigate to home page
	When user click on Export centre icon
	Then export center page displayed
	
Scenario: Verify Clear Search Criteria button ?? required to be automated ? 

Scenario: Search for company by company 

	Given the user navigate to home page
	And the user navigate to Company view/use
	And select the Company tab
	And provide the company name as 'Silk'
	When user clicks on search button
	Then search result contains more than 100 records
	And active records are displayed in black colour text
	And inactive records are displayed in red colour text
	
Scenario: Search for company by company name and Prefix Origin
	Given the user navigate to home page
	And the user navigate to Company view/use
	And select the Company tab
	And provide the company name as 'Leather'
	And select the Prefix Origin as 'United Kingdom'
	When user clicks on search button
	Then search result contains 20 records						
	
Scenario: Search for an inactive company by prefix
	Given the user navigate to home page
	And the user navigate to Company view/use
	And select the Prefix tab
	And provide the Prefix as '0894514002'
	When user clicks on search button
	Then search result contains the company 'B. Happybags, LLC' and inactive
	
Scenario: Search for a active company by prefix
	Given the user navigate to home page
	And the user navigate to Company view/use
	And select the Prefix tab
	And provide the Prefix as '0180253000'
	When user clicks on search button
	Then search result contains the company 'Papaya- Creative Abandon' and active
	
Scenario: Search for a company by GTIN 
	Given the user navigate to home page
	And the user navigate to Company view/use
	And select the GTIN tab
	And provide the GTIN as '60653890000005'
	When user clicks on search button
	Then search result contains the company 'Gorilla Snot USA, LLC' and active

Scenario: Search for a company by GLN 
	Given the user navigate to home page
	And the user navigate to Company view/use
	And select the GLN tab
	And provide the GLN as '0633922000003'
	When user clicks on search button
	Then search result contains the company 'Eagle Cap Nursery LLC' and active
	
Scenario: Verify Company Downloads
	Given the user navigate to home page
	When the user navigate to Company Downloads options
	Then 'Complete US Prefix List Active and Inactive' download option is present with date created as current date
	And 'Complete US Prefix List Active Only' download option is present with date created as current date
	And 'Monthly Prefix Changes' download option is present with the First Day of Current Month
	
