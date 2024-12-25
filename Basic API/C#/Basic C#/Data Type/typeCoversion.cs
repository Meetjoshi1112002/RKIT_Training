namespace Basic_API.Data_Type
{
    internal class TypeCoversion
    {
        public static void display()
        {
            // 1st implicit conversiton
            float f = 122.66f;
            double d = f;

            // 2nd explict conversions (we do despite data loss)
            int n = 100;
            byte b = (byte)n;

            // 3rd non compactible type converstion using Sytems Convert class or primte DT parse method
            string n1 = "25";
            string n2 = "1235";

            byte con2 = Convert.ToByte(n1);
            int con1= int.Parse(n2);


            Console.WriteLine(d + " " + b + " " + con1 + " " + con2);

            try
            {
                var num = "12345";
                byte by = Convert.ToByte(num);
            }
            catch (Exception ex) {
                Console.WriteLine("Execption thwon here");
            }
        }
    }
}
