namespace Idfy.Signature.Models.Misc
{
    public class Styling
    {
        /// <summary>
        /// Sets color theme for the application
        /// </summary>
        public Theme ColorTheme { get; set; }

        /// <summary>
        /// Set the type of spinner to show in loading screens
        /// </summary>
        public Spinner Spinner { get; set; }
    }

    public enum Theme
    {
        Default,
        Teal,
        Blue,
        Dark,
        Pink,
        Black,
        Purple,
        Neutral
    }

    public enum Spinner
    {
        Document,
        Classic,
        Cubes
    }

}