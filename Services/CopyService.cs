namespace TelstarRoutePlanner.Services
{
    public static class CopyService<TClass1, TClass2>
    {
        public static void Copy(TClass1 class1, TClass2 class2)
        {
            var class1Properties = typeof(TClass1).GetProperties();
            var class2Properties = typeof(TClass2).GetProperties();

            foreach(var class1property in class1Properties)
            {
                foreach(var class2property in class2Properties)
                {
                    if (class1property.Name == class2property.Name && class1property.GetType() == class2property.GetType())
                    {
                        var value = class1property.GetValue(class1property);
                        class1property.SetValue(class2property, value);
                    }
                }
            }
        }
    }
}
