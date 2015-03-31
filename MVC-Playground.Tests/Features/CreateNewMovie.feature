Feature: CreateNewMovie
	As an User of the Site
	I want to be able to Create New Movies
	So that I can Extend the available list
@UI
Scenario Outline: Positive Create Successfully
	Given I have navigated to Create New Movie Page
	And I have filled in all the Name of the movie with <Movies>
	When I press the Create Button
	Then The new movie is created and I am redirected to List of Movies and <Movies> is in the list

Examples: 
| Movies         |
| Men in black 3 |
| Men in black 4 |
| Rambo          |