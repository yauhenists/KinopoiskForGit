Feature: LoginAndLogoutSteps
	Login with valid and invalid credentials

@mytag
Scenario: Login with valid credentials
	Given I have opened home page
	And Go to registration page
	When I login with credentials
	| Login             | Password    |
	| test.selenium2002 | selenium123 |
	Then I should see avatar button on reloaded home page

Scenario: Login with invalid credentials
	Given I have opened home page
	And Go to registration page
	When I login with credentials
	| Login             | Password    |
	| test.selenium2002 | selenium124 |
	Then I should see validation message