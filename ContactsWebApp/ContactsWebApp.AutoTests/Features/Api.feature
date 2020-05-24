@api
Feature: Api
	In order to test api
	As a developer
	I want to test my web app's api

Scenario Outline: DeleteThroughAPI
	Given I have added '<contact>' to Contacts List
	Then '<contact>' is displayed on Contacts Form
	When I delete '<contact>' through API
	When I refresh the page
	Then '<contact>' is not displayed on Contacts Form

	Examples:
		| contact |
		| test    |

		@needsDelete
Scenario Outline: AddThroughAPI
	When I add '<contact>' through API
	When I refresh the page
	Then '<contact>' is displayed on Contacts Form
	And Contacts list from API contains '<contact>'

	Examples:
		| contact |
		| test    |

		@needsDelete
Scenario Outline: EditThroughAPI
	Given I have added '<contact>' to Contacts List
	Then '<contact>' is displayed on Contacts Form
	When I edit '<contact>' as '<edited>' through API
	When I refresh the page
	Then '<edited>' is displayed on Contacts Form
	Then '<contact>' is not displayed on Contacts Form

	Examples:
		| contact | edited |
		| test    | edited |