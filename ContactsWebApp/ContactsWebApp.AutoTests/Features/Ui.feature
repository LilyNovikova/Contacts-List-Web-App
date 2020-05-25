Feature: Ui
	In order to test UI
	As a developer
	I want to test my web app's UI

Scenario Outline: AddAndDeleteContact
	When I click Add New Contact button on Contacts Form
	Then Create Form is displayed
	When I fill fields with '<contact>' data on Create Form
	And I click Create button on Create Form
	Then Contacts Form is displayed
	Then '<contact>' is displayed on Contacts Form
	When I click '<contact>' 'Delete' button on Contacts Form
	Then Delete Form is displayed
	And '<contact>' data is displayed on Delete Form
	When I click Delete button on Delete Form
	Then Contacts Form is displayed
	Then '<contact>' is not displayed on Contacts Form

	Examples:
		| contact |
		| test    |

Scenario Outline: EditContact
	Given I have added '<contact>' to Contacts List
	Then '<contact>' is displayed on Contacts Form
	When I click '<contact>' 'Edit' button on Contacts Form
	Then Edit Form is displayed
	When I fill fields with '<edited>' data on Edit Form
	And I click Save button on Edit Form
	Then Contacts Form is displayed
	Then '<contact>' is not displayed on Contacts Form
	Then '<edited>' is displayed on Contacts Form
	When I click '<edited>' 'Delete' button on Contacts Form
	When I click Delete button on Delete Form
	Then '<edited>' is not displayed on Contacts Form

	Examples:
		| contact | edited |
		| test    | edited |