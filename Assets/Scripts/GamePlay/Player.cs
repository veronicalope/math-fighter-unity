using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MathFighter.GamePlay
{
    public class Player : MonoBehaviour
    {
        public int _playerNum;   // index of the player in the gameplay settings list of players (NOT the xbox player index)
        public string playerName;
        //public enum EnumGamepadButton { None, A, B, X, Y };
        //private EnumGamepadButton _buttonPressed;
        private bool _hintPressed;
        private bool _superattackPressed;
        private bool _cheatPressed;
        private bool _freezePressed;
        private bool _tauntPressed;
        private SpriteRenderer _spriteRenderer;
        public bool CanAnswer;
        private TutorManager.EnumTutor _character = TutorManager.EnumTutor.None;

        public int PlayerNum
        {
            get { return _playerNum; }
            set { _playerNum = value; }
        }

        public bool HintPressed
        {
            get { return _hintPressed; }
            set { _hintPressed = value; }
        }

        public bool SuperAttackPressed
        {
            get { return _superattackPressed; }
            set { _superattackPressed = value; }
        }

        public bool CheatPressed
        {
            get { return _cheatPressed; }
            set { _cheatPressed = value; }
        }

        public bool FreezePressed
        {
            get { return _freezePressed; }
            set { _freezePressed = value; }
        }

        public bool TauntPressed
        {
            get { return _tauntPressed; }
            set { _tauntPressed = value; }
        }

        public virtual bool IsValid
        {
            get { return false; }
        }

        public virtual Texture2D GamerPic
        {
            get { return null; }
        }

        public virtual string GamerTag
        {
            //get { return "TheEternalBlade"; }  // give the PC testing build something to display
            get { return "WWWWWWWWWWWWWWW"; }  // give the PC testing build something to display
        }

        public virtual SpriteRenderer SpriteRenderer
        {
            get { return _spriteRenderer; }
            set { _spriteRenderer = value; }
        }
        ////#if XBOX
        //public virtual Gamer GamerRef
        //{
        //    get { return null; }
        //}
        ////#endif

        public TutorManager.EnumTutor Character
        {
            get { return _character; }
            set { _character = value; }
        }

        /// <summary>
        /// Called to tell the player that a button was pressed on the gamepad
        /// </summary>
        //public void OnButtonPressed(EnumGamepadButton button)
        //{
        //    if (_buttonPressed == EnumGamepadButton.None)
        //    {
        //        _buttonPressed = button;
        //    }
        //}

        ///// <summary>
        ///// Call this to reset the player input to no button being pressed
        ///// </summary>
        //public void ResetButtonPressed()
        //{
        //    _buttonPressed = EnumGamepadButton.None;
        //}

        ///// <summary>
        ///// Returns the stored button press associated with the player (can be 'None')
        ///// </summary>
        //public EnumGamepadButton GetButtonPressed()
        //{
        //    return _buttonPressed;
        //}

        public virtual PlayerCharacterSelector GetCharacterSelector(int playerNum)
        {
            throw new NotImplementedException();
        }
    }



    /// <summary>
    /// This class will be used to mediate selecting a character on the character selection screen.
    /// Different types of player (AI, Local, Remote) will require different mediation implemented
    /// by derived classes.
    /// </summary>
    public abstract class PlayerCharacterSelector
    {
        protected int _playerNum;   // index of the player in the gameplay settings list of players (NOT the xbox player index)

        public PlayerCharacterSelector(int playerNum)
        {
            _playerNum = playerNum;
        }

        //public abstract void Tick(GameStateCharacterSelectionLobby lobby, float dt);
    }
}