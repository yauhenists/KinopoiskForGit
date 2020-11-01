Feature: DropDownFeature
	https://demoqa.com/select-menu

@SimpleDropDown
Scenario: Select value from simple dropdown
	Given I have opened Select Menu page
	When I select Blue style select menu
	Then Selected style is Blue

@DisabledDropDown
Scenario: Select value from disabled dropdown
	Given I have opened Select Menu page
	When I select Mr. title
	Then Selected title is Mr.

@MultiselectDropDown
Scenario: Select value from multiselect dropdown
	Given I have opened Select Menu page
	When I select cars
	| Car1  | Car2 |
	| Volvo | Opel |
	Then All selected cars are matched