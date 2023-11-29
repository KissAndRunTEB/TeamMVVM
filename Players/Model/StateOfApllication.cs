using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Players
{
    /// <summary>
    /// Help class Save / Load
    /// </summary>
    public static class StateOfApllication
    {
        #region Paths to files

        // Path to xml
        private static string pathToXMLFile = @"../../../Resources/Players.xml";

        // Path to txt
        private static string pathToTxtFile = @"../../../Resources/Players.txt";

        #endregion

        /// <summary>
        /// App state save to file
        /// </summary>
        /// <param name="collectionOfPlayers">Kolekcja piłkarzy do zapisania</param>
        public static void Save(ObservableCollection<PlayerViewModel> collectionOfPlayers)
        {
            #region Saving to a text file

            // Text to save
            string dataToSave = string.Empty;

            // Saving to text file
            foreach (PlayerViewModel player in collectionOfPlayers)
            {
                dataToSave += $"{player.Nick} ; {player.Name} ; {player.Age} ; {player.WinRatio} {Environment.NewLine}";
            }

            File.WriteAllText(pathToTxtFile, dataToSave.Trim());

            #endregion

            #region Zapis do pliku XML

            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<PlayerViewModel>));
            using (StreamWriter wr = new StreamWriter(pathToXMLFile))
            {
                xs.Serialize(wr, collectionOfPlayers);
            }

            #endregion

        }

        /// <summary>
        /// Static method to read from file
        /// </summary>
        /// <returns>Collection of type Player</returns>
        public static ObservableCollection<PlayerViewModel> Load()
        {
            ObservableCollection<PlayerViewModel> team = new ObservableCollection<PlayerViewModel>();

            string dataFromFile = File.ReadAllText(pathToTxtFile).Trim();

            string[] txtPlayers = dataFromFile.Split(Environment.NewLine);

            foreach(string txtPlayer in txtPlayers)
            {
                team.Add(stringToPlayerViewModelConverter(txtPlayer));
            }

            return team;
        }

        #region Metody pomocnicze

        /// <summary>
        /// Converter from text line to object
        /// </summary>
        /// <param name="playerTxt">Line of text decribing player</param>
        /// <returns></returns>
        private static PlayerViewModel stringToPlayerViewModelConverter(string playerTxt)
        {
            string[] infoAboutPlayer = playerTxt.Split(';');

            if (infoAboutPlayer.Length != 4)
                return new PlayerViewModel();

            string nick = infoAboutPlayer[0].Trim();
            string name = infoAboutPlayer[1].Trim();
            int age = 0;
            double winratio = 0;

            try
            {
                age = int.Parse(infoAboutPlayer[2].Trim());
                winratio = Double.Parse(infoAboutPlayer[3].Trim());
            }
            catch{ }

            return new PlayerViewModel(nick, name, winratio, age);
        }

        #endregion
    }
}
