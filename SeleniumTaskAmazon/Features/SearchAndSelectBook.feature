Feature: SearchForAndSelectBook
	In order to buy a book from Amazon.co.uk silly mistakes
	As a not registered client
	I want to find a book and add it to cart

Background: 
	Given I navigate to Amazon book store in UK
	And I am not logged in

Scenario: Navigate to Amazon book store in UK
	Then The correct page is open
	And I can start to search for books

Scenario: Search for book
	When I select category Books
	And Search for book with title Harry Potter and the Cursed Child
	Then 1st found book has following attributes
	| title                             | badge | type | price |
	| Harry Potter and the Cursed Child | true | Paperback | 5.99  |

Scenario: Check book details
	When I select category Books
	And Search for book with title Harry Potter and the Cursed Child
	And Navigate to 1st found book details
	Then I am on the book details page
	And The book has following attributes
	| title                             | badge | type | price |
	| Harry Potter and the Cursed Child | false | Paperback | 5.99  |

Scenario: Add and edit book to the basket
	When I select category Books
	And Search for book with title Harry Potter and the Cursed Child
	And Navigate to 1st found book details
	And Add book to the basket
	Then The notification is shown
	And Notification title is Added to Basket
	And There is 1 item in the basket
	When I edit basket
	Then The book is shown on the list
	And The book is the same as on the search page
	And Quantity is 1
	And Total price is equal to quantity times book price
	


