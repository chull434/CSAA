Feature: Project
	As a logged in user
	After Creating a project
	I can use the project screen

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

	When I click "Create Project" in the menu

	Then I am on the "Project" page

Scenario: Update Project
	
	When I enter the following:
		| Field | Value     |
		| Title | Project 2 |

	When I click "Save"

	Then a project called "Project 2" exists

Scenario: Add Team Member

	Given the following user account exists:
		| Field        | Value                   |
		| Name         | Test User 2             |
		| Email        | testuser2@localhost.com |
		| Password     | password                |
		| ProductOwner | Yes                     |
		| ScrumMaster  | Yes                     |
		| Developer    | Yes                     |

	When I enter the following:
		| Field | Value                   |
		| Email | testuser2@localhost.com |

	When I click "Add"

	Then "testuser2@localhost.com" is a team member of a project called "New Project"

Scenario: Logout Button

	When I click "Logout" in the menu

	Then I am on the "Login" page

Scenario: Home Button

	When I click "Home" in the menu

	Then I am on the "Home" page
