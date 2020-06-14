using System;
using System.IO;
using System.Reflection;

namespace truckapp01.ApiMobile
{
    public class Api
    {
        public static string GetJsonData(string data)
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Api)).Assembly;
            var stream = assembly.GetManifestResourceStream($"truckapp01.ApiMobile.{data}.json");
            var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }
    }
}
