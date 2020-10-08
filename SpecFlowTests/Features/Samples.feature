Feature: SpecFlowSampleFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@SmokeTest
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Add two numbers via table
	When I add to numbers
	| FirstNumber | SecondNumber | Result |
	| 40          | 60           | 100    |
	Then check the result
	And Write date 5 days from now via custom step transformer

Scenario Outline: Add two numbers for different iterations
	When I add two numbers <FirstNumber>, <SecondNumber>
	Then check the result <Result>
Examples: 
	| FirstNumber | SecondNumber | Result |
	| 40          | 60           | 100    |
	| 40          | 80           | 120    |

Scenario: Add two numbers via dynamic table
	When I add to numbers using dynamic table
	| FirstNumber | SecondNumber | Result |
	| 40          | 60           | 100    |
	Then check the result

Scenario: Add two numbers with transformation
	Given two numbers 20 and 50 and result 70 
	Then check the result

Scenario: Simple math check
	Then check addition

Scenario: Check find in set
	Given Table for checking
	| FirstNumber | SecondNumber | Result |
	| 40          | 60           | 100    |
	#| 40          | 70           | 110    |