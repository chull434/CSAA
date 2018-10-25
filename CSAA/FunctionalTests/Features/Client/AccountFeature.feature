Feature: AccountFeature
	In order to use CSAA
	As a unregistered user
	I can register

Scenario: Register

	Then I am on the "Registration" page

	When I enter the following:
		| Field     | Value                  |
		| FirstName | Test                   |
		| Surname   | User                   |
		| Email     | testuser@localhost.com |

	And I enter the following passwords:
		| Field         | Value    |
		| Input         | password |
		| Input_Confirm | password |

	And I check the following:
		| Field        | Value |
		| ProductOwner | Yes   |
		| ScumMaster   | Yes   |
		| Developer    | Yes   |

	And I click "Register"

	Then the a user account is created with the following details:
		| Field         | Value              |
		| Name          | Test User          |
		| Email         | testuser@localhost |
		| Password      | password           |
		| product_owner | Yes                |
		| scrum_master  | Yes                |
		| developer     | Yes                |

Scenario: Required Fields Validation

	Then I am on the "Registration" page

	When I enter the following:
		| Field     | Value                  |
		| FirstName |                        |
		| Surname   | User                   |
		| Email     | testuser@localhost.com |

	And I enter the following passwords:
		| Field         | Value    |
		| Input         | password |
		| Input_Confirm | password |

	And I check the following:
		| Field        | Value |
		| ProductOwner | Yes   |
		| ScumMaster   | Yes   |
		| Developer    | Yes   |

	And I click "Register"

	Then the no user accounts are created

	Then the following errors appear:
		| Field         | Value                      |
		| InvalidFields | Please Populate all fields |