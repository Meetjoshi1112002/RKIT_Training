-- Use of Distinct:
		-- can be applied to single , multiple colums + can be used in aggreagate
        Select distinct ProviderId,EmployeeId 
        From Payments;   -- This query help to get all emp - prov relations in office
        
        -- distinct in aggreagate 
        Select count(distinct EmployeedId)
        From Payments; -- This total unique employees involved in a transcation
        
-- Applying pagination using limit and offset:

		-- syntax 1 : 
				Select distinct e.FirstName 
                From ServiceLogs s Inner join Employees e On s.EmployeeId = e.Id
                Limit 2,2;   -- Like (start , size)
                
				Select distinct e.FirstName 
                From ServiceLogs s Inner join Employees e On s.EmployeeId = e.Id
                Limit 2 offset 2   -- limit telss size and offset to skip
                
                -- skit calution : offset = (page_number - 1 ) * page_size
                -- total pages : Count(*)/page_size   -- frontend nees this
                
        