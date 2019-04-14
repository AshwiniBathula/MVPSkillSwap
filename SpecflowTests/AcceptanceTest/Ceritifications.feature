Feature: Ceritifications
	In order to update my profile 
	As a skill trader
	I want to add the Certifications that have done

@mytag
Scenario: Check if user could able to add a Certifications 
	Given I clicked on the Certifications tab under Profile page
	When I add a new Certification
	Then that Certification should be displayed on my listings
	
@mytag
Scenario: Check if you are able to edit and update existing Certifications
	Given I clicked on the Certifications tab under Profile page
	When I click edit button and update 
	Then Updated Certification details should be listed

@mytag
Scenario: Check if you are able to edit and add Certifications without updating
	Given I clicked on the Certifications tab under Profile page
	When I click edit button and add button 
	Then error about already existing Certificationdata should be displayed

@mytag
Scenario: Check if you are able to cancel editing  Certifications
	Given I clicked on the Certifications tab under Profile page
	When I click edit button and then cancel 
	Then the Certifications list should be same as previous

@mytag
Scenario: Check if you are able to remove Certifications from listing
	Given I clicked on the Certifications tab under Profile page
	When I click the remove button
	Then The Certification should be removed from the listings

@mytag
Scenario: Check if you are able to add Certifications without From
	Given I clicked on the Certifications tab under Profile page
	When I add Certification with out From
	Then appropriate error message should be displayed

@mytag
Scenario: Check if you are able to add From without Certificate
	Given I clicked on the Certifications tab under Profile page
	When I add from without Certification 
	Then validation message on Certification should be displayed

@mytag
Scenario: Check if you are able to cancel adding Certifications
	Given I clicked on the Certifications tab under Profile page
	When I click add and cancel  
	Then Certification should not be added

@mytag
Scenario: Check if user can add duplicate Certifications year and From
	Given I clicked on the Certifications tab under Profile page
	When I add duplicate Certifications
	Then error about already existing Certification data should be displayed

@mytag
Scenario: Check if user can add duplicate Certification with different year and from
	Given I clicked on the Certifications tab under Profile page
	When I add duplicate Certification and different year and from
	Then error about duplicate Certification data should be displayed





