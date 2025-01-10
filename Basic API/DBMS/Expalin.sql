-- Explain Keyword with query7

-- Tells how system peformed the query

-- important column with Explain : 
			-- type : tells which how much part of table it had to see ( ALL means entirte table)
            -- rows : telss which all rows it had to scan)
            -- possbile_keys : indexex that mysql had to consider
            -- key : the index that it used for this query