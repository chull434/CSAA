Feature: AccountFeature
	In order to use CSAA
	As a unregistered user
	I can register

Scenario: Register
	
	When I register with the following details:
		| Field         | Value              |
		| Name          | Test User          |
		| Email         | testuser@localhost |
		| Password      | password           |
		| product_owner | Yes                |
		| scrum_master  | Yes                |
		| developer     | Yes                |

	Then the a user account is created with the following details:
		| Field         | Value              |
		| Name          | Test User          |
		| Email         | testuser@localhost |
		| Password      | password           |
		| product_owner | Yes                |
		| scrum_master  | Yes                |
		| developer     | Yes                |