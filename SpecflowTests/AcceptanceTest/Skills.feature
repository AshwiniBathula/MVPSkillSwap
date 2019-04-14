Feature: Skills Tab
	In order to update my profile 
	As a skill trader
	I want to add the skills that I know

@mytag
Scenario: Check if user could able to add a skill 
	Given I clicked on the Skills tab under Profile page
	When I add a new skill
	Then that skill should be displayed on my listings
	
@mytag
Scenario: Check if you are able to edit and update existing skill
	Given I clicked on the skills tab under Profile page
	When I click edit button and update 
	Then Updated skill details should be listed

@mytag
Scenario: Check if you are able to edit and add skill without updating
	Given I clicked on the skill tab under Profile page
	When I click edit button and add button 
	Then error about already existing skilldata should be displayed

@mytag
Scenario: Check if you are able to cancel editing a skill
	Given I clicked on the skill tab under Profile page
	When I click edit button and then cancel 
	Then the skill list should be same as previous

@mytag
Scenario: Check if you are able to remove skill from listing
	Given I clicked on the skill tab under Profile page
	When I click remove button
	Then The skill should be removed from the listing

@mytag
Scenario: Check if you are able to add skill without level
	Given I clicked on the skill tab under Profile page
	When I add skill with out level
	Then appropriate error message about skill should be displayed

@mytag
Scenario: Check if you are able to add level without skill
	Given I clicked on the skill tab under Profile page
	When I add level without skill 
	Then validation on skill should be displayed

@mytag
Scenario: Check if you are able to cancel adding skill
	Given I clicked on the skill tab under Profile page
	When I click add and cancel  
	Then skill should not be added

@mytag
Scenario: Check if user can add duplicate skill and level
	Given I clicked on the skill tab under Profile page
	When I add duplicate skill and level
	Then error about already existing skilldata should be displayed

@mytag
Scenario: Check if user can add duplicate skill with different level
	Given I clicked on the skill tab under Profile page
	When I add duplicate skill and different level
	Then error about duplicate skilldata should be displayed





