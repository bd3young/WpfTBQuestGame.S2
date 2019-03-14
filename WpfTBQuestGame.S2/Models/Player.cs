using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTBQuestGame.S2.Models
{
    public class Player : Character
    {
        #region ENUM

        public enum JobTitleName
        {
            Theif,
            ShipWright,
            Engineer
        }

        #endregion

        #region FIELDS

        protected int _lives;
        protected int _health;
        private int _exp;
        private JobTitleName _jobTitle;

        #endregion

        #region PROPERTIES

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Exp
        {
            get { return _exp; }
            set { _exp = value; }
        }

        public JobTitleName JobTitle
        {
            get { return _jobTitle; }
            set { _jobTitle = value; }
        }



        #endregion

        #region METHODS

        #endregion

        #region CONSTRUCTORS

        #endregion
    }
}
