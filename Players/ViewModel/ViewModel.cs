using Players.WindowAddPlayer;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Players
{
    public class ViewModel : BaseViewModel
    {
        #region Private fields

        private readonly List<int> rangeOfAge;

        private PlayerViewModel displayedPlayer;

        private PlayerViewModel selectedPlayer;

        private PlayerViewModel newPlayer;

        // Lista piłkarzy
        private ObservableCollection<PlayerViewModel> listOfPlayers;

        private RelayCommand saveCommand;

        private RelayCommand deletePlayerCommand;

        private RelayCommand modifyPlayerCommand;

        private RelayCommand addPlayerCommand;

        #endregion

        #region Constructor

        public ViewModel()
        {
            // Possible ages
            rangeOfAge = new List<int>();
            for (int i = 18; i <= 50; i++)
                rangeOfAge.Add(i);

            listOfPlayers = StateOfApllication.Load();

            // Setting first player as default to show in view
            if (listOfPlayers.Count > 0)
                displayedPlayer = new PlayerViewModel(
                    listOfPlayers[0].Nick, listOfPlayers[0].Name, listOfPlayers[0].WinRatio, listOfPlayers[0].Age);
            else
                displayedPlayer = new PlayerViewModel();

            newPlayer = new PlayerViewModel();
        }

        #endregion

        #region Public fields


        public PlayerViewModel DisplayedPlayer
        {
            get { return displayedPlayer; }
        }


        public PlayerViewModel NewPlayer
        {
            get { return newPlayer; }
        }


        public PlayerViewModel SelectedPlayer
        {
            get { return selectedPlayer; }
            set
            {
                if (value != null)
                {
                    selectedPlayer = value;

                    displayedPlayer.Nick = value.Nick;
                    displayedPlayer.Name = value.Name;
                    displayedPlayer.Age = value.Age;
                    displayedPlayer.WinRatio = value.WinRatio;
                }
            }
        }


        public List<int> RangeOfAge
        {
            get
            { return rangeOfAge; }
        }


        public ObservableCollection<PlayerViewModel> ListOfPlayers
        {
            get { return listOfPlayers; }
            set { listOfPlayers = value; onPropertyChanged(nameof(ListOfPlayers)); }
        }

        public RelayCommand Save
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new RelayCommand(argument => { StateOfApllication.Save(listOfPlayers); }, argument => true);
                return saveCommand;
            }
        }


        public RelayCommand DeletePlayer
        {
            get
            {
                if (deletePlayerCommand == null)
                    deletePlayerCommand = new RelayCommand(argument => { listOfPlayers.Remove(selectedPlayer); }, argument => true);
                return deletePlayerCommand;
            }
        }


        public RelayCommand ModifyPlayer
        {
            get
            {
                if (modifyPlayerCommand == null)
                    modifyPlayerCommand = new RelayCommand(argument =>
                    {
                        if (selectedPlayer != null & !string.IsNullOrEmpty(displayedPlayer.Nick) &
                            !string.IsNullOrEmpty(displayedPlayer.Name))
                        {
                            selectedPlayer.Nick = displayedPlayer.Nick;
                            selectedPlayer.Name = displayedPlayer.Name;
                            selectedPlayer.Age = displayedPlayer.Age;
                            selectedPlayer.WinRatio = displayedPlayer.WinRatio;
                            selectedPlayer.Description = selectedPlayer.ToString();
                        }
                    }, argument => true);
                return modifyPlayerCommand;
            }
        }



        public RelayCommand AddPlayer
        {
            get
            {
                if (addPlayerCommand == null)
                    addPlayerCommand = new RelayCommand(argument =>
                    {
                        // Creating new window enablying user add player
                        AddPlayerWindow window = new AddPlayerWindow();

                        window.DataContext = this;

                        window.ShowDialog();

                        // The DialogResult property carries information
                        // whether we are adding a new player or not
                        if (window.DialogResult == true) 
                        {
                            if (newPlayer != null)
                            {
                                // Adding player
                                listOfPlayers.Add(new PlayerViewModel(
                                    newPlayer.Nick, newPlayer.Name, newPlayer.WinRatio, newPlayer.Age));
                            }
                        }   
                    }, argument => true);
                return addPlayerCommand;
            }
        }

        #endregion
    }
}
