$(
    function(){




        // Displaying jokes part
        $("#display_saved_jokes button").click(() => {
            let savedJokes = [];
            if(localStorage.getItem("jokes")){
                savedJokes = JSON.parse(localStorage.getItem("jokes"));
            }
            
            if (savedJokes.length === 0) {
                $("#savedJokesOutput").html("<p>No jokes saved yet.</p>");
                return;
            }
        
            let jokesHTML = "<ul>";
            savedJokes.forEach((joke, index) => {
                if (joke.type === "single") {
                    jokesHTML += `
                        <li>
                            <strong>Category:</strong> ${joke.category}<br>
                            <strong>Joke:</strong> ${joke.joke}
                        </li>
                        <hr>
                    `;
                } else {
                    jokesHTML += `
                        <li>
                            <strong>Category:</strong> ${joke.category}<br>
                            <strong>Setup:</strong> ${joke.setup}<br>
                            <strong>Delivery:</strong> ${joke.delivery}
                        </li>
                        <hr>
                    `;
                }
            });
            jokesHTML += "</ul>";
        
            $("#savedJokesOutput").html(jokesHTML);
        });
        
    }
)