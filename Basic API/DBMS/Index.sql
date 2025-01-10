-- indexes are basically data sttructure that data base use for quick search operations 

-- we store any field in sorted order and reference to the row = index ( a DS)

 -- most time this index (DS binary tree) is stored in the memory itself and help us way faster access to record
 
 -- Disadvantage :
		-- This extra binary tree is stored in memroy so DB size increases
        -- Also it reduces throughputs as we need to update the index as well on CRUD query

Create index idx_PaymentAmount ON payments(PaymentAmount); -- This is crateing index

Show indexes IN payments; -- show all indexes on the tbl (collation tells asc or desc  and cardinallity  shows the nuymber of elements in it
						  -- primary key are indexex by default
                          -- we create secondarty indexex
                          -- foring key are also seconday index by default

-- we can index of table in schama pannel aslo where we see column


-- Prefeix index (in case of string DT like char , varchar , text, blog)

-- we include only prefix to reduce size
-- eg
Create index idx_FirstName ON employees(FirstName(1)); -- how to decide lenght here?

Select 
	COUNT(Distinct Left(FirstName,1)),  -- tells how many unique letters are there if i consider all my customer
    COUNT(Distinct Left(FirstName,5)),-- tells how many unique 2-word prefixer are there if i consider all my customer
    COUNT(Distinct Left(FirstName,10))  -- if gradinent is less we consider that much prefix lenghty in index
From Employees;

-- my gradinet was 1 (so funny !)









                          