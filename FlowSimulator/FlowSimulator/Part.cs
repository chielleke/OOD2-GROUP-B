using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FlowSimulator
{
   public abstract class Part :Component
    {
        //everything that was in component and was only used by the parts is now in parts

       
        

        /// <summary>
        /// sets the base for setting it's position
        /// </summary>
        /// <param name="_position">A point where it is stated</param>
        public Part(Point _position)  {
            this.Capacity = 10;
            this.position = _position;
            Size s = new Size(40, 40);
            selectionArea = new Rectangle(this.Position, new Size(40, 40));
        }
       

       


        /// <summary>
        /// To establish a connection between a Part a pipeline
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            throw new System.NotImplementedException();
        }

        public abstract Image ComponentImage(bool isOccupied);
        public abstract Image ComponentIconImage(bool isOccupied);

    }
}
