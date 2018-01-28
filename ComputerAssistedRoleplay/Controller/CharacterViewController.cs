﻿using System;
using ComputerAssistedRoleplay.Model.Character;

namespace ComputerAssistedRoleplay.Controller
{
    public interface ICharacterView : IStatusObserver
    {
        /// <summary>
        /// Sets the controller of the View
        /// </summary>
        /// <param name="controller">Instance of the controller that is operating the view</param>
        void SetController(CharacterViewController controller);

        void DisplayStatus(int hitpoints);
    }

    public class CharacterViewController
    {
        private CharacterSheet _character;
        private CharacterSheet _opponent;
        private ICharacterView _view;

        /// <summary>
        /// Connects the view and the model together via the controller
        /// </summary>
        /// <param name="characterView">The Character view</param>
        /// <param name="character">The Character Sheet it is connected to</param>
        public CharacterViewController(ICharacterView characterView, CharacterSheet character, CharacterSheet opponent)
        {
            _view = characterView;
            _character = character;
            _opponent = opponent;

            _view.SetController(this);
            _character.Status.Subscribe(_view);
            this.LoadView();
        }

        internal void SetHitpoints(int newHitpoints)
        {
            _character.Status.Hitpoints = newHitpoints;
        }

        /// <summary>
        /// Loads the view and prefills it with values;
        /// </summary>
        private void LoadView()
        {
            _view.DisplayStatus(_character.Status.Hitpoints);
        }

        /// <summary>
        /// Attacks the opponent
        /// </summary>
        internal void AttackOpponent()
        {
            _character.Attack(_opponent);
        }
    }
}
