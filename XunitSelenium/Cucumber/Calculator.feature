﻿Feature: Calculator
	As Alice (the customer)
	I want to execute binary operations
	So I can save my time


Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120
	And displayed first name is 50
	And displayed second name is 70

Scenario: Substract two numbers
	Given the first number is 70
	And the second number is 40
	When I substract first number to second number
	Then the result should be 30
	And displayed first name is 70
	And displayed second name is 40

Scenario: Product of two numbers
	Given the first number is 30
	And the second number is 30
	When I multiply both numbers
	Then the result shall be 900
	And displayed first name is 30
	And displayed second name is 30

Scenario: Division of two numbers
	Given the first number is 20
	And the second number is 4
	When I divide first number by second number
	Then the result is 5
	And displayed first name is 20
	And displayed second name is 4

Scenario: Division of two numbers returning non integer value
	Given the first number is 10
	And the second number is 4
	When I divide first number by second number
	Then the result is 2.5
	And displayed first name is 10
	And displayed second name is 4


Scenario Outline: Comprobar varios valores para la raiz
	When Realizo la raiz del numero <number> 
	Then La respuesta debe ser <result>
	Examples: 
	| number | result  |
	| 4      | 2       |
	| 5      | 2.236   |
	| 2.5    | 1.581   |
	| 0      | 0       |
	