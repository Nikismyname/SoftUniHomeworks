namespace SIS.HTTP.Extentions
{
    using SIS.HTTP.Enums;

    public static class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpResponseStatusCode code)
        {
            var result = (int)code + " " + code.ToString();
            return result;
        }
    }
}
