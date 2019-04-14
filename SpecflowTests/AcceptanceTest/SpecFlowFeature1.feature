Feature: SpecFlowFeature1
	In order to update my profile 
	As a skill trader
	I want to add the languages that I know

@mytag
Scenario: Check if user could able to add a language 
	Given I clicked on the Language tab under Profile page
	When I add a new language
	Then that language should be displayed on my listings
	
@mytag
Scenario: Check if user is able to add maximum of four languages
	Given I clicked on the Language tab under Profile page
	When I add languages
	| LanguageName |  | Level  |
	| English  |  | Fluent |
	| Hindi    |  | Basic  |
	| telugu   |  |Conversational |
	| Tamil    |  |  Basic |
	Then I should see only four languages

@mytag
Scenario: Check if you are able to edit and update existing language
	Given I clicked on the Language tab under Profile page
	When I click edit button and update 
	Then Updated language details should be listed

@mytag
Scenario: Check if you are able to edit and add language without modifying
	Given I clicked on the Language tab under Profile page
	When I click edit button and Update button 
	Then Language update should be unsuccessful

@mytag
Scenario: Check if you are able to cancel editing a language
	Given I clicked on the Language tab under Profile page
	When I click edit button and then cancel 
	Then the language list should be same as previous

@mytag
Scenario: Check if you are able to remove language from listing
	Given I clicked on the Language tab under Profile page
	When I click the remove button
	Then The language should be removed from the listings

@mytag
Scenario: Check if you are able to add language without level
	Given I clicked on the Language tab under Profile page
	When I add language with out level
	Then Language addition should be unsuccessful

@mytag
Scenario: Check if you are able to add level without language
	Given I clicked on the Language tab under Profile page
	When I add level without language 
	Then Language addition should be unsuccessful

@mytag
Scenario: Check if you are able to add without level and language
	Given I clicked on the Language tab under Profile page
	When I click add without level and language 
	Then Language addition should be unsuccessful

@mytag
Scenario: Check if you are able to cancel adding language
	Given I clicked on the Language tab under Profile page
	When I click add and cancel  
	Then language should not be added

@mytag
Scenario: Check if user can add duplicate language and level
	Given I clicked on the Language tab under Profile page
	When I add duplicate language and level
	Then error about already existing language data should be displayed

@mytag
Scenario: Check if user can add duplicate language with different level
	Given I clicked on the Language tab under Profile page
	When I add a new language
	And I add same language with different level
	Then Language addition should be unsuccessful


	

	