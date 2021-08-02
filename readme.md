# Setup and Running the App
1. dotnet restore
2. dotnet build
3. dotnet run

# Endpoints

## GET
GetNumbers
GetAllNumbers

## POST
PostNumbers

# Other Notes

## Goals
1. Sort these number in either ascending or descending order
2. Ordered sequence should be inserted into the database along with the direction that the sequence was sorted in and time taken to perform the sort
3. Feedback to the user that result of the operation was successful or not
4. Displays the results of all sorts including the sort direciton and time taken.
5. Export all the sorts as JSON.
6. Document all assumptions

## Assumptions
1. Numbers must be integers
2. Numbers are stored as strings in Database separated by ","