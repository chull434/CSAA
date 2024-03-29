﻿Feature: Login
	In order to use CSAA
	As a unregistered user
	I can login

Background:
	
	Then I am on the "Login" page

Scenario: Login

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

Scenario: Login Failed - Email

	Given the following user account exists:
		| Field        | Value                  |
		| Name         | Test User              |
		| Email        | testuser@localhost.com |
		| Password     | password               |
		| ProductOwner | Yes                    |
		| ScrumMaster  | Yes                    |
		| Developer    | Yes                    |

	When I enter the following:
		| Field | Value              |
		| Email | testuser@gmail.com |

	And I enter the following passwords:
		| Field    | Value    |
		| Password | password |

	And I click "Login"

	Then I am on the "Login" page

	And the following errors appear:
		| Field         | Value                                          |
		| PasswordError | No user found for that email, please register. |

Scenario: Login Failed - Password

	Given the following user account exists:
		| Field        | Value                  |
		| Name         | Test User              |
		| Email        | testuser@localhost.com |
		| Password     | Pa$$w0rd               |
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

	Then I am on the "Login" page

	And the following errors appear:
		| Field         | Value                                 |
		| PasswordError | Incorrect password, please try again. |

Scenario: Required Fields Validation - Email

	When I enter the following:
		| Field | Value |
		| Email |       |

	And I enter the following passwords:
		| Field    | Value    |
		| Password | password |

	And I click "Login"

	Then I am on the "Login" page

	And the following errors appear:
		| Field      | Value                        |
		| EmailError | Please populate email field. |

Scenario: Required Fields Validation - Password

	When I enter the following:
		| Field | Value                  |
		| Email | testuser@localhost.com |

	And I enter the following passwords:
		| Field    | Value |
		| Password |       |

	And I click "Login"

	Then I am on the "Login" page

	And the following errors appear:
		| Field         | Value                      |
		| PasswordError | Please enter you password. |

Scenario: Register Button

	When I click "Register"

	Then I am on the "Registration" page