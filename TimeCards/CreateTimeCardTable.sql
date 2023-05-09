/*
This is my first attempt to create a databse
*/


Create Table TimeCard (
TimeCardId INT Primary Key,
Date_Worked Date Not Null,
TimeStart TIMESTAMP Not Null, -- Before Lunch
LunchStart TIMESTAMP Not Null,
LunchEnd TIMESTAMP Not Null, -- After Lunch
TimeOver TIMESTAMP Not Null,
AddTimeStart TIMESTAMP Not Null, -- Possible Overtime
AddTimeOver TIMESTAMP Not Null
);

