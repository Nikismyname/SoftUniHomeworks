namespace SIS.HTTP.Extentions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string input)
        {
            var charArray = input.ToCharArray();
            charArray[0] = char.ToUpper(charArray[0]);
            for (int i = 1; i < charArray.Length; i++)
            {
                charArray[i] = char.ToLower(charArray[i]);
            }
            var result = new string(charArray);
            return result;
        }
    }
}
