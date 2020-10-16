Feature: Login
	Check if the Login functionality is working
	as expected with different permutations and
	combinations of data

Background:
	#Given I Delete employee 'AutUser' beforeI start running test

@smoke @positive
Scenario: 
	Given I have navigated to the application
	And I see application opened
	Then I click login link
	When I enter UserName and Password and click login
	| UserName | Password |
	| admin    | password |
	Then I click login button
	Then I should see the username with hello

