namespace Basic_API.Control_Flow
{
    public class RandomPassWordGenerator
    {
        public static string generateRandomPassword()
        {
            const int length = 10;
            var random = new Random();

            var buffer = new char[length];

            for (int i = 0; i < length; i++)
            {
                buffer[i] = (char)('a' + random.Next(0, 26));
            }

            var rp = new String(buffer);
            return rp;
        }
    }
}
