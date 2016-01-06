using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FlowSimulator
{
    /// <summary>
    /// A class to store actions such as adding/removing a component
    /// </summary>
    public class Action
    {
        /// <summary>
        /// The coordinates of the component which the action was carried out on.
        /// </summary>
        public Point Position
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// The component which an action is being applied to.
        /// </summary>
        public Component Component
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        /// <summary>
        /// Refers to an enum ActionType, determine which type of action was performed
        /// </summary>
        public ActionType ActionType
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        
        
    }
    /// <summary>
    /// Enum class of the types of actions that can be undone/ redone.
    /// </summary>
    public enum ActionType
    {
        Add,
        Move,
        Delete,
        Update,
    }
}
