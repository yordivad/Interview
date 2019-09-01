Feature: UserCreate
  In order to create a user
  As a user
  I want to provide a user with name, last name, email and the password

  @tag
  Scenario: Create a valid user
    Given the user
      | Name | LastName | Email                 | Password | PasswordConfirm |
      | john | Doe      | john.doe@universe.org | 123      | 123             |
    When the command is handle
    Then I should get no errors