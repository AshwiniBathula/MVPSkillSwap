Feature: Education Tab
	In order to update my profile 
	As a skill trader
	I want to add my education details

@mytag
Scenario: Check if user could able to add education details 
	Given I clicked on the education tab under Profile page
	When I add education details
	Then education details should be displayed on my listings
	
@mytag
Scenario: Check if you are able to edit and update education details
	Given I clicked on the education tab under Profile page
	When I click edit button and update 
	Then Updated education details should be listed

@mytag
Scenario: Check if you are able to edit and add education without updating
	Given I clicked on the skill tab under Profile page
	When I click edit button and add button 
	Then error about already existing education data should be displayed

@mytag
Scenario: Check if you are able to cancel editing education details
	Given I clicked on the education tab under Profile page
	When I click edit button and then cancel 
	Then the education list should be same as previous

@mytag
Scenario: Check if you are able to remove education from listing
	Given I clicked on the education tab under Profile page
	When I click remove button
	Then The education details should be removed from the listing

@mytag
Scenario: Check if you are able to add education without Country
	Given I clicked on the education tab under Profile page
	When I add education with out Country
	Then appropriate error message about missing country should be displayed

@mytag
Scenario: Check if you are able to add education without College/University
	Given I clicked on the education tab under Profile page
	When I add education with out College/University
	Then appropriate error message about missing College/University should be displayed

@mytag
Scenario: Check if you are able to add education without Title
	Given I clicked on the education tab under Profile page
	When I add education with out Title
	Then appropriate error message about missing Title should be displayed

@mytag
Scenario: Check if you are able to add education without Degree
	Given I clicked on the education tab under Profile page
	When I add education with out Degree
	Then appropriate error message about missing Degree should be displayed

@mytag
Scenario: Check if you are able to add education without Year
	Given I clicked on the education tab under Profile page
	When I add education with out Year
	Then appropriate error message about missing year should be displayed


@mytag
Scenario: Check if you are able to cancel adding education
	Given I clicked on the education tab under Profile page
	When I click add and cancel  
	Then education should not be added

@mytag
Scenario: Check if user can add duplicate education
	Given I clicked on the education tab under Profile page
	When I add duplicate education 
	Then error about already existing education should be displayed

@mytag
Scenario: Check if user can add duplicate education with different Country
	Given I clicked on the education tab under Profile page
	When I add duplicate education and different Counrty
	Then error about duplicate  Educationdata should be displayed






