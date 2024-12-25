namespace Basic_API.NonPrimitiveDT
{
    public enum shippingMethod
    {
        normal,
        express = 20,
        airdrop // will get 21
    }
    public class EnumBasic
    {
        public static void display()
        {
            // example 1: getting a key-value from enum 
            var method = shippingMethod.airdrop; // method(variable) is type enum
            Console.WriteLine((int)method);
            // note cw(method) == cw(method.toString()) for enum variables   


            // example 2 : converting code -> string using enum
            // vice versa : suppose we got a code and need to find the method
            var code = 20;
            Console.WriteLine((shippingMethod)code);

            // now assume we got a shipping method dynamically and we need to know the enum of it
            var methodName = "normal";
            
            var SM_Enum = (shippingMethod)Enum.Parse(typeof(shippingMethod), methodName);
            Console.WriteLine(SM_Enum);

        }
    }
}
