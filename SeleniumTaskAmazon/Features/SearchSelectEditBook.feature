Feature: Search, select and edit a book
	In order to search, select and edit a book on Amazon.co.uk
	As a not registered client
	I want to find a book, add it to cart and edit it

#Background: 
#	Given I navigate to Amazon book store in UK
#	And I am not logged in

Scenario: Search, Select and Edit a book in Amazone UK store
	Given I navigate to Amazon book store in UK
	And I am not logged in
	Then The correct page is open
	And I can start to search for books
	When I select category Books
	And Search for book with title Harry Potter and the Cursed Child
	Then 1st found book has following attributes
	| title                             | badge | type | price |
	| Harry Potter and the Cursed Child | true | Paperback | 5.99  |
	When Navigate to 1st found book details
	Then I am on the book details page
	And The book has following attributes
	| title                             | badge | type | price |
	| Harry Potter and the Cursed Child | false | Paperback | 5.99  |
	When Add book to the basket
	Then The notification is shown
	And Notification title is Added to Basket
	And There is 1 item in the basket
	When I edit basket
	Then The book is the same as on the search page
	And Quantity is 1
	And Total price is equal to quantity times book price