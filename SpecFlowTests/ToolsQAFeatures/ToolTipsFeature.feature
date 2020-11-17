Feature: ToolTipsFeature
	Simple check of tooltip text

@mytag
Scenario: Check tooltip text
	Given I have opened tooltips page
	When I hover mouse over button
	Then I see tooltip with text You hovered over the Button