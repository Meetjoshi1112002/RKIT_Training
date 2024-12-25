namespace Basic_API.Control_Flow
{
    public class Loops
    {
        public static void display()
        {
            // for loop to print patter of diamond
            for(int i = 0; i < 7; i++)
            {
                var lower = (i > 3) ? (i - 3) : (3 - i);
                var upper = (i>3)? (6-i+3):(3 + i);

                for(int j = 0; j < 7; j++)
                {
                    if(j == lower || j == upper)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            //foreach loop
            var owner = "Made by Meet joshi";
            foreach(var i in owner)
            {
                Console.Write(i);
            }

            Console.WriteLine("Rate the patter ");
            while (true) { 
                var input = Console.ReadLine();
                if(!string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(input);
                    continue;
                }
                break;
            }
        }
    }
}
