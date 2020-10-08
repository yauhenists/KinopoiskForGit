Feature: BrowserCommandsFeature
	https://www.toolsqa.com/selenium-webdriver/selenium-webdriver-browser-commands/

@browserCommands
Scenario: Check main commands
	Given I have opened ToolsQA page
	Then I check title of webpage is "What are all Selenium Webdriver Browser Commands in Java?"
	Then I check url is "https://www.toolsqa.com/selenium-webdriver/selenium-webdriver-browser-commands/"
	Then I check code source is started with "<html lang"