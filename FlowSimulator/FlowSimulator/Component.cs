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
    
    public abstract class Component
    {
        public Component InPut { get; set; }
        public Component OutPut { get; set; }
        public Component InPutUp { get; set; }
        public Component InPutDown { get; set; }
        public Component OutPutUp { get; set; }
        public Component OutPutDown { get; set; }

        /// <summary>
        /// The current position of the component on the canvas
        /// </summary>
        /// 
       
        private Point position;
        private Rectangle selectionArea;
      
        public Point Position
        {
            get { return position; }

            set { position = value; } 
           
        }

        /// <summary>
        /// The maximum flow through the component
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// The current flow through the component
        /// </summary>
        public int CurrentFlow { get; set ; }

        /// <summary>
        /// Determines if the component is currently selected
        /// </summary>
        

        /// <summary>
        /// The rectangle which will be drawn around a selected component
        /// </summary>
        /// 
        //work on this
        public System.Drawing.Rectangle SelectionArea
        {
            get { return selectionArea; }
            set { selectionArea = value;} 
        }

        /// <summary>
        /// To establish a connection between a component a pipeline
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            throw new System.NotImplementedException();
        }

    public Component(Point _position) // Gate class constructor
    {
              this.Capacity = 10;
            this.position = _position;
            Size s = new Size(40, 40);
           selectionArea = new Rectangle(this.Position, new Size(40, 40));
            
   
            

        }

   
    public abstract Image ComponentImage(bool isOccupied);
    public abstract Image ComponentIconImage(bool isOccupied);
    
        public bool UpdateSelectionArea()
    {
        this.selectionArea = new Rectangle(position, new Size(40, 40));
        
            return true;
        
    }

       
}
}
