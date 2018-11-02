Feature: Registration
	In order to use CSAA
	As a unregistered user
	I can register

Background:
	
	Then I am on the "Login" page
	When I click "Register"
	Then I am on the "Registration" page

Scenario: Register

	When I enter the following:
		| Field     | Value                  |
		| FirstName | Test                   |
		| Surname   | User                   |
		| Email     | testuser@localhost.com |

	And I enter the following passwords:
		| Field           | Value    |
		| Password        | password |
		| ConfirmPassword | password |

	And I check the following:
		| Field        | Value |
		| ProductOwner | Yes   |
		| ScumMaster   | Yes   |
		| Developer    | Yes   |

	And I click "Register"

	Then the a user account is created with the following details:
		| Field        | Value                  |
		| Name         | Test User              |
		| Email        | testuser@localhost.com |
		| Password     | password               |
		| ProductOwner | Yes                    |
		| ScumMaster   | Yes                    |
		| Developer    | Yes                    |

	Then I am on the "Login" page

Scenario: Register - Failed

	Given the following user account exists:
		| Field        | Value                  |
		| Name         | Test User              |
		| Email        | testuser@localhost.com |
		| Password     | password               |
		| ProductOwner | Yes                    |
		| ScumMaster   | Yes                    |
		| Developer    | Yes                    |

	When I enter the following:
		| Field     | Value                  |
		| FirstName | Test                   |
		| Surname   | User                   |
		| Email     | testuser@localhost.com |

	And I enter the following passwords:
		| Field           | Value    |
		| Password        | password |
		| ConfirmPassword | password |

	And I check the following:
		| Field        | Value |
		| ProductOwner | Yes   |
		| ScumMaster   | Yes   |
		| Developer    | Yes   |

	And I click "Register"

	Then I am on the "Registration" page

	And the following errors appear:
		| Field         | Value                                                                             |
		| InvalidFields | Name Test User is already taken. Email 'testuser@localhost.com' is already taken. |

Scenario: Required Fields Validation - FirstName

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

	When I enter the following:
		| Field     | Value                  |
		| FirstName | Test                   |
		| Surname   | User                   |
		| Email     | testuser@localhost.com |

	And I enter the following passwords:
		| Field           | Value    |
		| Password        | password |
		| ConfirmPassword |          |

	And I click "Register"

	Then the no user accounts are created

	And the following errors appear:
		| Field           | Value                   |
		| InvalidPassword | Passwords do not match. |

Scenario: Password Validation - mistmatch

	When I enter the following:
		| Field     | Value                  |
		| FirstName | Test                   |
		| Surname   | User                   |
		| Email     | testuser@localhost.com |

	And I enter the following passwords:
		| Field           | Value    |
		| Password        | password |
		| ConfirmPassword | Pa$$w0rd |

	And I click "Register"

	Then the no user accounts are created

	And the following errors appear:
		| Field           | Value                   |
		| InvalidPassword | Passwords do not match. |

Scenario: Login Button

	When I click "Login"

	Then I am on the "Login" page