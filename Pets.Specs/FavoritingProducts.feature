Feature: Favoriting Products
	In order to be able to find the food I buy often quickly
	As a Customer
	I want to be able Favorite the foods I enjoy

Scenario: Favoriting a product
	Given I have a Person called "James"
	And I have a Food product with the SKU 7506987 called "Berries"
	And "James" has no favorited products
	When "James" favorites the product 7506987
	Then "James" should have 1 favorited products

Scenario: Favoriting an additional product
	Given I have a Person called "Maria"
	And I have a Food product with the SKU 7584736 called "Snickers"
	And I have a Food product with the SKU 7501919 called "Porridge Oats"
	And "Maria" has favorited the product 7584736
	When "Maria" favorites the product 7501919
	Then "Maria" should have 2 favorited products

Scenario: Favoriting a product that is already favorited
	Given I have a Person called "Libby"
	And I have a Food product with the SKU 7506572 called "Brown Rice"
	And "Libby" has favorited the product 7506572
	When "Libby" tries to favorite the product 7506572
	Then "Libby" should have 1 favorited products

Scenario: Favoriting a product that is not in the Food Category
	Given I have a Person called "Emma"
	And I have a Electrical product with the SKU 7516123 called "Duracel Batteries"
	And "Emma" has no favorited products
	When "Emma" tries to favorite the product 7516123
	Then "Emma" should have 0 favorited products

Scenario: UnFavoriting a product
	Given I have a Person called "Peter"
	And I have a Food product with the SKU 7506767 called "Granny Smith Apple"
	And "Peter" has favorited the product 7506767
	When "Peter" unfavorites the product 7506767
	Then "Peter" should have 0 favorited products

Scenario: UnFavoriting a product that is not favourited
	Given I have a Person called "Aaron"
	And I have a Food product with the SKU 7523461 called "Kitkat"
	And I have a Food product with the SKU 7584736 called "Green Grapes"
	And "Aaron" has favorited the product 7523461
	When "Aaron" tries to unfavorite the product 7584736
	Then "Aaron" should have 1 favorited products