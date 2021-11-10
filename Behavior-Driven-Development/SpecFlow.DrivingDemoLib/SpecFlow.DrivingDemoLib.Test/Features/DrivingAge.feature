Feature: DrivingAge
	Checks if a person is allowed to drive a car in a given country

@mytag
Scenario: Permitted driving in Switzerland
	Given The driver is 21 years old
	When they live in Switzerland
	Then  they are permitted to drive a car

@mytag
Scenario: Permitted driving in Germnay
	Given The driver is 18 years old
	When they live in Germany
	Then  they are permitted to drive a car

@mytag
Scenario: Permitted driving in UnitedStates
	Given The driver is 16 years old
	When they live in UnitedStates
	Then  they are permitted to drive a car

@mytag
Scenario: Not Permitted driving in Germnay
	Given The driver is 16 years old
	When they live in Germany
	Then  they are not permitted to drive a car

@mytag
Scenario: These people are not Permitted driving
	Given The driver is <age> years old
	When they live in <country>
	Then  they are not permitted to drive a car
	Examples: 
	| age | country  |
	| 18  | Cameroon |
	| 16  | Germany |
	| 10  | UnitedStates |
