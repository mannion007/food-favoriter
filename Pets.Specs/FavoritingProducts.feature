Feature: Favoriting Food Items
	In order to be able to easily find the Food Items I like to buy regularly
	As a Customer
	I want to be able to maintain a list of Favorite Food Items

Scenario: Favoriting a Food Item
	Given I have a Person called "James"
	And I have a Food Item with the SKU 7506987 called "Berries"
	And "James" has no favorited Food Items
	When "James" favorites the Food Item 7506987
	Then "James" should have 1 favorited Food Items

Scenario: Favoriting an additional Food Item
	Given I have a Person called "Maria"
	And I have a Food Item with the SKU 7584736 called "Snickers"
	And I have a Food Item with the SKU 7501919 called "Porridge Oats"
	And "Maria" has favorited the Food Item 7584736
	When "Maria" favorites the Food Item 7501919
	Then "Maria" should have 2 favorited Food Items

Scenario: Favoriting a Food Item that is already favorited
	Given I have a Person called "Libby"
	And I have a Food Item with the SKU 7506572 called "Brown Rice"
	And "Libby" has favorited the Food Item 7506572
	When "Libby" tries to favorite the Food Item 7506572
	Then "Libby" should have 1 favorited Food Items

Scenario: UnFavoriting a Food Item
	Given I have a Person called "Peter"
	And I have a Food Item with the SKU 7506767 called "Granny Smith Apple"
	And "Peter" has favorited the Food Item 7506767
	When "Peter" unfavorites the Food Item 7506767
	Then "Peter" should have 0 favorited Food Items

Scenario: UnFavoriting a Food Item that is not favourited
	Given I have a Person called "Aaron"
	And I have a Food Item with the SKU 7523461 called "Kitkat"
	And I have a Food Item with the SKU 7584736 called "Green Grapes"
	And "Aaron" has favorited the Food Item 7523461
	When "Aaron" tries to unfavorite the Food Item 7584736
	Then "Aaron" should have 1 favorited Food Items