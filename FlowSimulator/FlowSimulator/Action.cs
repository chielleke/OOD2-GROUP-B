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
            ;
            set
            ;
        }

        /// <summary>
        /// The component which an action is being applied to.
        /// </summary>
        public Component Component
        {
            get
            ;
            set
           ;
        }
        /// <summary>
        /// Refers to an enum ActionType, determine which type of action was performed
        /// </summary>
        public ActionType ActionType
        {
            get;
            set;
        }/*
        //constructors
        /// <summary>
        /// this is used for moving a component
        /// </summary>
        /// <param name="p">the position of the component</param>
        /// <param name="action">type "Move" here without quotations</param>
        /// <param name="comp">reference to the component</param>
        public Action(Point p, ActionType Move, Component comp)
        {
            this.Position = p;
            this.ActionType = Move;
            this.Component = comp;
        }
        */
        /// <summary>
        /// this is used when you create, delete or Move a component
        /// </summary>
        /// <param name="Act">type "ActionType." followed "Create", "Delete" or "Move" here without quotations</param>
        /// <param name="comp">reference to the component </param>
        public Action(ActionType Act, Component comp )
        {
            this.ActionType = Act;
            if (Act.Equals(1))
            {
                this.Position = comp.Position;
            }
            if (Act.Equals(2))
            {
                this.Component = (Component) comp.Clone();
            }
            else
            {
                this.Component = comp;
            }

        }
       
    }
    /// <summary>
    /// Enum class of the types of actions that can be undone/ redone.
    /// </summary>
    public enum ActionType
    {
        Create,
        Move,
        Delete,
        
    }
}
