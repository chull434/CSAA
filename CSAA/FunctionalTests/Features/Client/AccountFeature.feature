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

Scenario: Required Fields Validation - FirstName

	Then I am on the "Registration" page

	When I enter the following:
		| Field     | Value                  |
		| FirstName |                        |
		| Surname   | User                   |
		| Email     | testuser@localhost.com |

	And I click "Register"

	Then the no user accounts are created

	And the following errors appear:
		| Field         | Value                       |
		| InvalidFields | Please populate all fields. |

Scenario: Required Fields Validation - Surname

	Then I am on the "Registration" page

	When I enter the following:
		| Field     | Value                  |
		| FirstName | Test                   |
		| Surname   |                        |
		| Email     | testuser@localhost.com |

	And I click "Register"

	Then the no user accounts are created

	And the following errors appear:
		| Field         | Value                       |
		| InvalidFields | Please populate all fields. |

Scenario: Required Fields Validation - Email

	Then I am on the "Registration" page

	When I enter the following:
		| Field     | Value |
		| FirstName | Test  |
		| Surname   | User  |
		| Email     |       |

	And I click "Register"

	Then the no user accounts are created

	And the following errors appear:
		| Field         | Value                       |
		| InvalidFields | Please populate all fields. |

Scenario: Email Validation

	Then I am on the "Registration" page

	When I enter the following:
		| Field     | Value              |
		| FirstName | Test               |
		| Surname   | User               |
		| Email     | testuser@localhost |

	And I click "Register"

	Then the no user accounts are created

	And the following errors appear:
		| Field         | Value          |
		| InvalidFields | Invalid email. |

Scenario: Password Validation - empty

	Then I am on the "Registration" page

	When I enter the following:
		| Field     | Value                  |
		| FirstName | Test                   |
		| Surname   | User                   |
		| Email     | testuser@localhost.com |

	And I enter the following passwords:
		| Field         | Value    |
		| Input         | password |
		| Input_Confirm |          |

	And I click "Register"

	Then the no user accounts are created

	And the following errors appear:
		| Field           | Value                   |
		| InvalidPassword | Passwords do not match. |

Scenario: Password Validation - mistmatch

	Then I am on the "Registration" page

	When I enter the following:
		| Field     | Value                  |
		| FirstName | Test                   |
		| Surname   | User                   |
		| Email     | testuser@localhost.com |

	And I enter the following passwords:
		| Field         | Value    |
		| Input         | password |
		| Input_Confirm | Pa$$w0rd |

	And I click "Register"

	Then the no user accounts are created

	And the following errors appear:
		| Field           | Value                   |
		| InvalidPassword | Passwords do not match. |