using System;
using ComputerAssistedRoleplay.Model.Hitzone;
using ComputerAssistedRoleplay.Model.Weapons;
using ComputerAssistedRoleplay.Model.Character;

namespace ComputerAssistedRoleplay.Model.Character
{    /// <summary>
     /// Delegate for StatuschangedEvents
     /// </summary>
     /// <typeparam name="ILog">Interface to the StatusEvents</typeparam>
     /// <param name="sender">Source of the event</param>
     /// <param name="e">Contains the Event Data</param>
    public delegate void CharacterHandler<ICharacterObserver>(ICharacterObserver sender, CharacterChangedEventArgs e);

    /// <summary>
    /// The Event Data of the Log Events
    /// </summary>
    public class CharacterChangedEventArgs : EventArgs
    {
        public string CharacterInfo { get; }

        /// <summary>
        /// Creates a new Instance of the CharacterChangedEventArgs
        /// </summary>
        public CharacterChangedEventArgs(string characterInfo)
        {
            CharacterInfo = characterInfo;
        }
    }

    /// <summary>
    /// The Interface every observer must Implement if they want to get notified about Character changes
    /// </summary>
    public interface ICharacterObserver
    {
        void CharacterChangedEvent(ICharacterSender status, CharacterChangedEventArgs e);
    }

    /// <summary>
    /// Status interface to allow subscription and unsubscription
    /// </summary>
    public interface ICharacterSender
    {
        void Subscribe(ICharacterObserver iso);
        void UnSubscribe(ICharacterObserver iso);
    }

    public class CharacterSheet : ICharacterSender
    {
        public Hitzones Hitzone { get; set; }
        private Weapon _Weapon;
        public Weapon Weapon
        {
            get
            {
                return _Weapon;
            }
            set
            {
                _Weapon = value;
                characterChanged();
            }
        }
        
        public StatusSheet Status { get; }

        public event CharacterHandler<CharacterSheet> charHandler = delegate { };

        /// <summary>
        /// Constructor for the CHaractersheet
        /// </summary>
        /// <param name="hitzone"></param>
        /// <param name="defaultWeapon"></param>
        public CharacterSheet(Hitzones hitzone, Weapon defaultWeapon)
        {
            Hitzone = hitzone;
            _Weapon = defaultWeapon;
            Status = new StatusSheet();
        }

        /// <summary>
        /// Attacks another Character
        /// </summary>
        /// <param name="enemyCS">The Character to attack</param>
        public void Attack(CharacterSheet enemyCS)
        {
            //Calculate if character hits (something like Attackchance vs agility)
            //Currently we always hit

            SingleHitZone hitBodyPart = enemyCS.Hitzone.randomizeHitzone();
            DamageItem damage = new DamageItem(hitBodyPart, _Weapon);

            enemyCS.ProcessHit(damage);
            characterChanged();
        }

        /// <summary>
        /// Processes a hit by a weapon
        /// </summary>
        /// <param name="affliction">The Damage item that is applied to the character</param>
        public void ProcessHit(DamageItem hit)
        {
            //Substract Hitpoints for Bash
            //Substract Hitpoints for Cut
            //Substract Hitpoints for Pierce
            Status.DealDamage(hit.Bash + hit.Pierce + hit.Cut);
            Status.AddAfflictions(hit.Afflictions);
            characterChanged();
        }

        /// <summary>
        /// Overridden ToString method that returns the description of the character
        /// </summary>
        /// <returns>Characterdescription</returns>
        public override string ToString()
        {
            string characterDescription = "";
            characterDescription += "Rasse: " + Hitzone.RaceName + "\r\n";
            characterDescription += Status.ToString();
            characterDescription += "\r\n";
            characterDescription += "\r\nWaffe:\r\n" + _Weapon.ToString();
            return characterDescription;
        }

        /// <summary>
        /// Subscirbe to get notifications of the Characterchanged events
        /// </summary>
        /// <param name="iCO"></param>
        public void Subscribe(ICharacterObserver iCO)
        {
            charHandler += new CharacterHandler<CharacterSheet>(iCO.CharacterChangedEvent);
        }

        /// <summary>
        /// Unsubscribe to remove notifications of the Characterchanged events
        /// </summary>
        /// <param name="iCO"></param>
        public void UnSubscribe(ICharacterObserver iCO)
        {
            charHandler -= new CharacterHandler<CharacterSheet>(iCO.CharacterChangedEvent);
        }

        private void characterChanged()
        {
            charHandler.Invoke(this, new CharacterChangedEventArgs(this.ToString()));
        }
    }
}
