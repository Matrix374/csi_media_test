# Setup and Running the App
1. dotnet restore
2. dotnet build
3. dotnet run
   
Database Content can be viewed on the `Home/RetrieveAllNumbers` page
There's no access to `Home/RetrieveNumber/{id}` outside of through the url

# Pages
`Home/RetrieveNumber/{id}`
`Home/RetrieveAllNumbers`

# Endpoints
## GET
`Number/GetNumber/{id}`
`Number/GetAllNumbers`

## POST
`Number/PostNumbers`

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

## Possible Extensions in the Future
1. List all Numbers from the Database in a Table which the user can click to send them to `Home/RetrieveNumber/{id}`
2. Form Validation
3. Time Taken Diagnostics