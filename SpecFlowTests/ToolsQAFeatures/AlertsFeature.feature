Feature: AlertsFeature
	To check different types of alerts

@SimpleAlert
Scenario: Check Simple Alert
	Given I have opened alerts page
	When I click simple alert button
	Then I see alerts text You clicked a button
	And I confirm alert

@ConfirmAlert
Scenario: Check Confirm Alert
	Given I have opened alerts page
	When I click confirm alert button
	Then I see alerts text Do you confirm action?
	And I confirm confirmation alert
	Then I see text of confirmation You selected Ok
	When I click confirm alert button
	And I cancel confirmation alert 
	Then I see text of confirmation You selected Cancel

@PromptAlert
Scenario: Check Prompt Alert
	Given I have opened alerts page
	When I click prompt alert button
	Then I see alerts text Please enter your name
	And I confirm prompt alert
	Then I see text of confirmation You entered test
	When I click prompt alert button
	And I cancel prompt alert 
	Then I see text of confirmation is empty

@TimerAlert
Scenario: Check Timer Alert
	Given I have opened alerts page
	When I click timer alert button
	Then I see alerts text This alert appeared after 5 seconds
	And I confirm timer alert
	Then Time of alert appearing is 5 seconds