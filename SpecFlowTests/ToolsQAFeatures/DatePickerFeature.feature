Feature: DatePickerFeature
	Simple checks working with DatePicker

@Smoke
Scenario: Select date in DatePicker and check in selected field
	Given I have opened DatePicker page
	When I Open DatePicker
	Then I should see DatePicker component
	When I select date 06/13/1990
	Then I should see selected date in date field
	And I should not see DatePicker component

@Smoke
Scenario: Check Date in DatePicker
	Given I have opened DatePicker page
	When I Open DatePicker
	Then I should see DatePicker component
	And I should see current moth and year in DatePicker
	When I select previous month
	Then I should see DatePicker component
	And I should see correct moth and year in DatePicker
	