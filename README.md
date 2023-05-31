# GUCera Database Management

This repository contains stored procedures for managing the GUCera database. These procedures can be used to check for duplicate emails, view student courses, and retrieve information about assignments, feedback, and promocodes.

## Procedures

The following procedures are included in this repository:

### existDuplicateEmail

This procedure checks if a given email address already exists in the Users table of the GUCera database. It takes an email address as input and returns a bit value indicating whether or not the email already exists.

### viewStudentCourses

This procedure lists all courses that a specific student is enrolled in. It takes a student ID as input and returns columns for course ID and name.

### AssignmentExist

This procedure checks if an assignment with a given number and type already exists for a specific course. It takes inputs for course ID, assignment number, assignment type (e.g. homework or quiz), and returns a bit value indicating whether or not an existing assignment was found.

### FeedbackExist

This procedure checks if feedback has already been submitted for a specific course by a specific student. It takes inputs for course ID, feedback number, and student ID, and returns a bit value indicating whether or not existing feedback was found.

### viewPromocode

This procedure retrieves information about promocodes that have been assigned to a specific student. It takes a student ID as input and returns columns for promocode code, discount percentage, start date, end date, and maximum uses per user.

## Usage

To use these stored procedures with your own instance of the GUCera database:

1. Connect to your database using SQL Server Management Studio.
2. Open each stored procedure file (.sql) in this repository.
3. Execute each file to create the corresponding stored procedure in your database.
4. Call each stored procedure as needed using SQL queries.
