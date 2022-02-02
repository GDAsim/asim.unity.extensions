namespace asim.extension
{
    /// <summary>
    /// Extension class for everything to do with text
    /// </summary>
    public static class TextExtension
    {
        public static char[][] StringArrayToCharArray(string[] stringArray)
        {
            char[][] charArray = new char[stringArray.Length][];
            for (int i = 0; i < stringArray.Length; i++)
            {
                charArray[i] = stringArray[i].ToCharArray();
            }
            return charArray;
        }
    }
}
