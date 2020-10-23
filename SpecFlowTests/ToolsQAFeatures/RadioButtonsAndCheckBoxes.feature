Feature: RadioButtonsAndCheckBoxes
	Check Radio button selecting
	Check 2 checkboxes selecting
	Used Actions class. For multiple checkboxes selecting Perform() method should be called when all checkboxes are clicked

@RadioButton
Scenario: Selecting Radio Button
	Given I have opened Practice Form page
	When I select Other Gender
	Then It's selected

@CheckBox
Scenario: Selecting CheckBoxes
	Given I have opened Practice Form page
	When I select Sports and Reading As Hobbies
	Then They are selected