Feature: Favoriting Food Items
	In order to be able to easily find the Food Items I like to buy regularly
	As a Customer
	I want to be able to maintain a list of Favorite Food Items

Scenario: Favoriting a Food Item
	Given I have a Person with the reference "ref-001" named "James"
	And I have a Food Item with the SKU 7506987 called "Berries"
	And Person "ref-001" has no favorited Food Items
	When Person "ref-001" favorites the Food Item 7506987
	Then Person "ref-001" should have 1 favorited Food Items

Scenario: Favoriting an additional Food Item
	Given I have a Person with the reference "ref-002" named "Maria"
	And I have a Food Item with the SKU 7584736 called "Snickers"
	And I have a Food Item with the SKU 7501919 called "Porridge Oats"
	And Person "ref-002" has favorited the Food Item 7584736
	When Person "ref-002" favorites the Food Item 7501919
	Then Person "ref-002" should have 2 favorited Food Items

Scenario: Favoriting a Food Item that is already favorited
	Given I have a Person with the reference "ref-003" named "Libby"
	And I have a Food Item with the SKU 7506572 called "Brown Rice"
	And Person "ref-003" has favorited the Food Item 7506572
	When Person "ref-003" tries to favorite the Food Item 7506572
	Then Person "ref-003" should have 1 favorited Food Items

Scenario: UnFavoriting a Food Item
	Given I have a Person with the reference "ref-004" named "Peter"
	And I have a Food Item with the SKU 7506767 called "Granny Smith Apple"
	And Person "ref-004" has favorited the Food Item 7506767
	When Person "ref-004" unfavorites the Food Item 7506767
	Then Person "ref-004" should have 0 favorited Food Items

Scenario: UnFavoriting a Food Item that is not favourited
	Given I have a Person with the reference "ref-005" named "Aaron"
	And I have a Food Item with the SKU 7523461 called "Kitkat"
	And I have a Food Item with the SKU 7584736 called "Green Grapes"
	And Person "ref-005" has favorited the Food Item 7523461
	When Person "ref-005" tries to unfavorite the Food Item 7584736
	Then Person "ref-005" should have 1 favorited Food Items