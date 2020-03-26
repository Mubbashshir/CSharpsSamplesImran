Feature: BBCHome

Scenario: Launch the BBC Home page
Given the user has launched the BBCHome page
When the user enters the BBC new employee details
| Name  | Age | Phone  | Email         |
| Imran | 41  | 999999 | test@test.com |
Then emplyee details can be seen at the employee view page