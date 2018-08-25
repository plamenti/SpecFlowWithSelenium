Feature: SelectBook
	In order to buy a book from Amazon.co.uk silly mistakes
	As a not registered client
	I want to select a book and add it to cart

Scenario: Navigate to Amazon book store in UK
	Given I navigate to Amazon book store in UK
	Then The correct page is open
	And I can start to search for books
