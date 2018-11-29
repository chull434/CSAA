Feature: Home
	As a logged in user
	I can use the home screen

Background:
	
	Then I am on the "Login" page

	Given the following user account exists:
		| Field        | Value                  |
		| Name         | Test User              |
		| Email        | testuser@localhost.com |
		| Password     | password               |
		| ProductOwner | Yes                    |
		| ScrumMaster  | Yes                    |
		| Developer    | Yes                    |

	When I enter the following:
		| Field | Value                  |
		| Email | testuser@localhost.com |

	And I enter the following passwords:
		| Field    | Value    |
		| Password | password |

	And I click "Login"

	Then I am on the "Home" page

Scenario: Create Project Button

	When I click "Create Project" in the menu

	Then a project called "New Project" exists

	And I am on the "Project" page

Scenario: Logout Button

	When I click "Logout" in the menu

	Then I am on the "Login" page