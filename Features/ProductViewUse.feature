@Chrome @Datahub-QA @Admin 
Feature: Share the product with other company and view the shared product examples in test.xlsx


Scenario Outline: Share the product with other company
    Given a user login to datahub with company <LoginCompanyName>
    Given navigate to product manage
    Given navigate to InUse
	Given serach the <GTIN> and select the product   
    And Click on sharing tab and click AddButton
    When the user share the selected product with company <SharedompanyName>
    Then the product is shared with the selected company

	@source: test.xlsx
    Examples: 
    | LoginCompanyName |GTIN |SharedompanyName|