using System;
using System.Collections.Generic;
using ComputerAssistedRoleplay.Model;
using ComputerAssistedRoleplay.Model.Character;
using ComputerAssistedRoleplay.Model.Misc;

namespace ComputerAssistedRoleplay.Controller
{
    /// <summary>
    /// Interface of the MainWindow to support the Controller
    /// </summary>
    public interface IMainWindowView
    {
        /// <summary>
        /// Sets the text of the Log to text
        /// </summary>
        /// <param name="text"></param>
        void SetLogText(string text);

        /// <summary>
        /// Appends text to the Log
        /// </summary>
        /// <param name="text"></param>
        void AppendLogText(string text);

        /// <summary>
        /// Sets the CombatTime
        /// </summary>
        /// <param name="text"></param>
        void SetTime(string text);

        /// <summary>
        /// Sets the controller of the View
        /// </summary>
        /// <param name="controller">Instance of the controller that is operating the view</param>
        void SetController(MainWindowController controller);

        /// <summary>
        /// Displays the description of the player
        /// </summary>
        /// <param name="description"></param>
        void displayPlayerDescription(string description);

        /// <summary>
        /// Displays the description of the enemy
        /// </summary>
        /// <param name="description"></param>
        void displayEnemyDescription(string description);

        /// <summary>
        /// Displays all available weapons for the Player and the enemy
        /// </summary>
        /// <param name="weaponNames">List of available weaponnames</param>
        void displayPlayerWeapons(List<string> weaponNames, string selectedWeapon);

        /// <summary>
        /// Displays all available weapons for the enemy
        /// </summary>
        /// <param name="weaponNames">List of available weaponnames</param>
        void displayEnemyWeapons(List<string> weaponNames, string selectedWeapon);
    }

    /// <summary>
    /// Controller of the Main Window
    /// </summary>
    public class MainWindowController : ICharacterObserver, ILogObserver, IClockObserver
    {
        /// <summary>
        /// Interface of the Hitzone Window
        /// </summary>
        IMainWindowView _view;
        /// <summary>
        /// Hitzonefactory of the Main Calculator
        /// </summary>
        CARCalculator _carCalc;

        /// <summary>
        /// Initial setup of the View (fill with predefined values)
        /// </summary>
        public void LoadView()
        {
            _view.displayPlayerDescription(_carCalc.PlayerCharacter.ToString());
            _view.displayEnemyDescription(_carCalc.EnemyCharacter.ToString());
            _view.SetTime(_carCalc.Time.ToString());
            _view.displayPlayerWeapons(_carCalc.WeapFab.AvailableWeapons, _carCalc.PlayerCharacter.Weapon.Name);
            _view.displayEnemyWeapons(_carCalc.WeapFab.AvailableWeapons, _carCalc.EnemyCharacter.Weapon.Name);
        }

        /// <summary>
        /// Createas a new instance of the Hitzone view controller
        /// </summary>
        /// <param name="view">View interface it is linked to</param>
        /// <param name="calculator">Main Calculator class</param>
        public MainWindowController(IMainWindowView view, CARCalculator calculator)
        {
            _view = view;
            _carCalc = calculator;
            _view.SetController(this);
            _carCalc.Log.Subscribe(this);
            _carCalc.Time.Subscribe(this);
            _carCalc.PlayerCharacter.Subscribe(this);
            _carCalc.EnemyCharacter.Subscribe(this);
        }

        /// <summary>
        /// Sets the Controller of the Hitzone View
        /// </summary>
        /// <param name="hzView">View of the Hitzone</param>
        internal void setHitZoneController(IHitzoneView hzView)
        {
            HitzoneViewController HZControl = new HitzoneViewController(hzView, _carCalc.HitFab);
        }

        /// <summary>
        /// Sets the Controller of the Weapons View
        /// </summary>
        /// <param name="wpView">View of the Weapons</param>
        internal void setWeaponController(IWeaponsView wpView)
        {
            WeaponViewController WPView = new WeaponViewController(wpView, _carCalc.WeapFab);
        }

        /// <summary>
        /// Sets the Controller of the PlayerView
        /// </summary>
        /// <param name="playerView">View of the Player character</param>
        internal void setPlayerController(ICharacterView playerView)
        {
            CharacterViewController playerViewController = new CharacterViewController(playerView, _carCalc.PlayerCharacter, _carCalc.EnemyCharacter);
        }

        /// <summary>
        /// Sets the Controller of the EnemyView
        /// </summary>
        /// <param name="playerView">View of the Enemy character</param>
        internal void setEnemyController(ICharacterView enemyView)
        {
            CharacterViewController enemyViewController = new CharacterViewController(enemyView, _carCalc.EnemyCharacter, _carCalc.PlayerCharacter);
        }

        /// <summary>
        /// Empties the CombatLog
        /// </summary>
        public void clearLog()
        {
            _carCalc.Log.Clear();
        }

        /// <summary>
        /// Close action of the MainWindow (Cleanup time)
        /// </summary>
        internal void Close()
        {
            _carCalc.Log.UnSubscribe(this);
            _carCalc.Time.Unsubscribe(this);
            _carCalc.PlayerCharacter.UnSubscribe(this);
            _carCalc.EnemyCharacter.UnSubscribe(this);
        }

        /// <summary>
        /// Throws X number of dice with Y sides and attaches the result to the Log.
        /// </summary>
        /// <param name="numberOfDice">Number of Dice that are thrown</param>
        /// <param name="diceSides">Number of sides each dice has</param>
        internal void throwDice(int numberOfDice, int diceSides)
        {
            int sum = 0;
            _carCalc.Log.Append("");
            for (int i = 0; i < numberOfDice; i++)
            {
                sum += _carCalc.throwDice(diceSides);
                
            }

            if(numberOfDice>1)
            {
                _carCalc.Log.Append("Gesamtaugenzahl: " + sum);
            }
        }

        /// <summary>
        /// Throws a Number of dice according to diceString
        /// </summary>
        /// <param name="diceString"></param>
        internal void throwDiceString(string diceString)
        {
            _carCalc.throwDiceByFormula(diceString);
        }

        /// <summary>
        /// ILogObserver function when a Log is Changing the Text
        /// </summary>
        /// <param name="log"></param>
        /// <param name="e"></param>
        public void logTextChangedEvent(ILog log, LogEventArgs e)
        {
            if (e.LogCleared)
            {
                _view.SetLogText("");
            }
            else
            {
                _view.AppendLogText(e.NewLogEntry + "\r\n");
            }
        }

        /// <summary>
        /// The player attacks the enemy with the equipped weapon
        /// </summary>
        internal void playerAttack()
        {
            _carCalc.PlayerCharacter.Attack(_carCalc.EnemyCharacter);
        }

        /// <summary>
        /// The enemy attacks the player with the equipped weapon
        /// </summary>
        internal void enemyAttack()
        {
            _carCalc.EnemyCharacter.Attack(_carCalc.PlayerCharacter);
        }

        /// <summary>
        /// Advances the combat time
        /// </summary>
        internal void AdvanceTime()
        {
            _carCalc.Time.Step();
            enemyAttack();
            playerAttack();
        }

        /// <summary>
        /// Resets the combat time
        /// </summary>
        internal void ResetTime()
        {
            _carCalc.Time.Reset();
        }

        internal void setPlayerWeapon(string weaponName)
        {
            _carCalc.setPlayerWeapon(weaponName);
        }

        internal void setEnemyWeapon(string weaponName)
        {
            _carCalc.setEnemyWeapon(weaponName);
        }

        /// <summary>
        /// IClockObserver function when the time changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClockTimeChangedEvent(IClock sender, ClockEventArgs e)
        {
            _view.SetTime(e.TimeString);
        }

        public void CharacterChangedEvent(ICharacterSender status, CharacterChangedEventArgs e)
        {
            _view.displayPlayerDescription(_carCalc.PlayerCharacter.ToString());
            _view.displayEnemyDescription(_carCalc.EnemyCharacter.ToString());
        }
    }
}
