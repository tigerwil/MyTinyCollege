﻿SELECT CourseID, Title FROM Course 
WHERE CourseID NOT IN(SELECT DISTINCT CourseID FROM Enrollment WHERE StudentID=1)