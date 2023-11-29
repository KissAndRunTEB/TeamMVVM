namespace Players
{
    /// <summary>
    /// Team player
    /// </summary>
    public class Player
    {

        #region Public fields

        public string Nick { get; set; }

        public string Name { get; set; }

        public double WinRatio { get; set; }

        public int Age { get; set; }


        #endregion

        #region Constructors

        public Player()
        {
            Nick = string.Empty;
            Name = string.Empty;
            WinRatio = 50;
            Age = 20;
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="name"></param>
        /// <param name="winratio"></param>
        /// <param name="age"></param>
        public Player(string nick, string name, double winratio, int age)
        {
            Nick = nick;
            Name = name;
            WinRatio = winratio;
            Age = age;
        }

        #endregion

        /// <summary>
        /// Ovverright of ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Nick} {Name}, age: {Age}, WR: {WinRatio}";
        }
    }
}
