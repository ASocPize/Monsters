using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters
{
    public class Monster
    {
        public enum EmotionalState
        {
            yourdumb,
            happy,
            sad,
            angry,
            bored
        }

        #region Fields
        private EmotionalState _attitude;
        private int _age;
        private string _name;
        #endregion

        #region Properties
        public EmotionalState Attitude
        {
            get { return _attitude; }
            set { _attitude = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion

        #region Constructors
        public Monster()
        {

        }
        #endregion
    }
}
