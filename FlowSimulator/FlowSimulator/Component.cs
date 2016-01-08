using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection.Emit;

namespace FlowSimulator
{
    /// <summary>
    /// An abstract class which the various types of components inherit from
    /// </summary>
    
    public abstract class Component : ICloneable
    {
        public Component InPut { get; set; }
        public Component InPutUp { get; set; }
        public Component InPutDown { get; set; }
        public Component OutPutUp { get; set; }
        public Component OutPutDown { get; set; }
        public Component OutPut { get; set; }
        public double Capacity { get; set; }
        public double CurrentFlow { get; set; }

        /// <summary>
        /// The current position of the component on the canvas
        /// </summary>
        /// 
        protected Point position;

        protected Rectangle selectionArea;
        
        /// <summary>
        /// Determines if the component is currently selected
        /// </summary>
        public bool UpdateSelectionArea()
        {
            this.selectionArea = new Rectangle(position, new Size(40, 40));

            return true;

        }
        /// <summary>
        /// The rectangle which will be drawn around a selected component
        /// </summary>
        /// 
        //work on this
        public System.Drawing.Rectangle SelectionArea
        {
            get { return selectionArea; }
            set { selectionArea = value; }
        }
        public Point Position
        {
            get { return position; }

            set { position = value; }

        }
        /// <summary>
        /// The maximum flow through the component
        /// </summary>
      

        /// <summary>
        /// The current flow through the component
        /// </summary>
      

        

       
   
        //Iclonable
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
