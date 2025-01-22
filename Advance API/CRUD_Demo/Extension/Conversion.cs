using System.Reflection;

namespace CRUD_Demo.Extension
{
    public static class DtoToPoCoExtension
    {
        public static POCO Convert<POCO>(this object dto)
        {
            // Get the type of the POCO
            Type pocoType = typeof(POCO);

            // Create an instance of the POCO
            POCO pocoInstance = (POCO)Activator.CreateInstance(pocoType);

            // Get properties of the DTO
            PropertyInfo[] dtoProperties = dto.GetType().GetProperties();

            // Get properties of the POCO
            PropertyInfo[] pocoProperties = pocoType.GetProperties();

            // Iterate through each property of the DTO
            foreach (PropertyInfo dtoProperty in dtoProperties)
            {
                // Find the corresponding property in the POCO with the same name
                PropertyInfo pocoProperty = Array.Find(pocoProperties, p => p.Name == dtoProperty.Name);

                // If no matching property is found, skip this property
                if (pocoProperty == null)
                {
                    //Console.WriteLine($"No matching property found for {dtoProperty.Name} in POCO {pocoType.Name}");
                    continue;
                }

                // If types are compatible, copy the value
                if (dtoProperty.PropertyType == pocoProperty.PropertyType)
                {
                    object value = dtoProperty.GetValue(dto);
                    pocoProperty.SetValue(pocoInstance, value);
                }
                else
                {
                    Console.WriteLine($"Type mismatch for property {dtoProperty.Name}: DTO={dtoProperty.PropertyType}, POCO={pocoProperty.PropertyType}");
                }
            }

            // Return the converted POCO object
            return pocoInstance;
        }


    }
}
