Feature: SelectBook
	In order to buy a book from Amazon.co.uk silly mistakes
	As a not registered client
	I want to find a book and add it to cart

Background: 
	Given I navigate to Amazon book store in UK
	And I am not logged in

Scenario: Navigate to Amazon book store in UK
	Then The correct page is open
	And I can start to search for books

Scenario Outline: Search for book
	When I select section books
	And Search for book with title <title>
	Then First found item has following attributes
	| title                             | badge | type      | price |
	| Harry Potter and the Cursed Child | prime | Paperback | 4.00  |

Examples: 
	| title                             |
	| Harry Potter and the Cursed Child |