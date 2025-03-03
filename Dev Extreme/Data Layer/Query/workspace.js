$(
    function(){

        // Treat quey as a promise

        // Data :>

        var people = [
            { id: 1, name: "Amelia", birthYear: 1991, gender: "female" },
            { id: 2, name: "Benjamin", birthYear: 1983, gender: "male" },
            { id: 3, name: "Daniela", birthYear: 1987, gender: "female" },
            { id: 4, name: "Lee", birthYear: 1992, gender: "male" }
        ];

        // simple query **************************************************************************************

        // query 1
        var result = DevExpress.data.query(people)
            .filter(["gender", "=", "female"])  // Filter: Only females
            .sortBy("birthYear")                // Sort: Oldest to youngest
            .select("name", "birthYear")        // Select: Only name and birthYear
            .toArray();                         // Convert result to an array (sycronus)

        console.log("Blocking code so comes first  \n");
        console.log(result);

        // query 2 (filtering + group by)
        var count = DevExpress.data.query(people)
            .filter(["gender", "=", "female"])
            .count();

        count
        .then((count) => {
            console.log("proimse 1");
            console.log("Number of females:", count);
        })

        // query 3

        var oldestPerson = DevExpress.data.query(people)
            .min("birthYear");

        oldestPerson
        .then((person) => {
            console.log("proimse 2");
            console.log("Oldest person:", person);
        })

        // query 4
        var grouped = DevExpress.data.query(people)
            .groupBy("gender")
            .toArray();
        console.log("blocking code 2");
        console.log(grouped);



        // Other important opersation

        // query 4 ************************************************************************

        const combinedIdsSUm = DevExpress.data.query(people)
        .aggregate(
            0,
            (total,obj)=>{
                console.log(total, obj.id);
            return total + parseInt(obj.id);
            },
            (seed)=>{
                console.log(seed)
                return seed ;
            }
        )

        combinedIdsSUm
        .then((result)=>{
            console.log("proimse 3");
            console.log("The combined id sum is "+result);
        })


        // qury 5 ************************************************************************************
        const avgyear = DevExpress.data.query(people)
        .avg("birthYear");


        avgyear
        .then((result)=>{
            console.log("proimse 4");
            console.log("The average year is "+result);
        })


        // query 6 (filtering  + grouping + sorting + slicing + returning promise) *****************************************************************
        const countByGender = DevExpress.data.query(people)
        .filter((data)=>{
            return data.birthYear > 1980;
        })
        .groupBy("gender")
        .sortBy("birthYear" ,true ) // Sort by birthYear DESCENDING
        .thenBy("name") // If birthYear is same, sort by name
        .slice(0,2)
        .enumerate();  //(return a promise)

        countByGender
        .then((result)=>{
            console.log("proimse 5");
            console.log(result);
        })

    }
)