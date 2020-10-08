Feature: ContextInjection
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@scopeBinding
Scenario: Add two numbers via table
	When I add to numbers
	| FirstNumber | SecondNumber | Result |
	| 40          | 60           | 100    |
	Then check result from Extended steps
	Then check the result