using System.ComponentModel;

namespace Players
{
    /// <summary>
    /// Class model providing view certain fields
    /// </summary>
    public class PlayerViewModel : BaseViewModel
    {
        #region Private fields

        private Player mPlayer;

        private string description;

        #endregion

        #region Public fields

        public string Nick
        {
            get
            {
                return mPlayer.Nick;
            }
            set
            {
                mPlayer.Nick = value;
                onPropertyChanged(nameof(Nick));
            }
        }

        public string Name
        {
            get
            {
                return mPlayer.Name;
            }
            set
            {
                mPlayer.Name = value;
                onPropertyChanged(nameof(Name));
            }
        }

        public double WinRatio
        {
            get
            {
                return mPlayer.WinRatio;
            }
            set
            {
                mPlayer.WinRatio = value;
                onPropertyChanged(nameof(WinRatio));
            }
        }

        public int Age
        {
            get
            {
                return mPlayer.Age;
            }
            set
            {
                mPlayer.Age = value;
                onPropertyChanged(nameof(Age));
            }
        }

        public string Description
        {
            get { return this.ToString(); }
            set { description = value; onPropertyChanged(nameof(Description)); }
        }

        #endregion

        public override string ToString()
        {
            return mPlayer.ToString();
        }


        #region Constructors

        public PlayerViewModel()
        {
            mPlayer = new Player();
            description = this.ToString();
        }

        /// <summary>
        /// Constructorwith paramets
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="name"></param>
        /// <param name="winratio"></param>
        /// <param name="age"></param>
        public PlayerViewModel(string nick, string name, double winratio, int age)
        {
            mPlayer = new Player(nick, name, winratio, age);
            description = this.ToString();
        }

        #endregion
    }
}
