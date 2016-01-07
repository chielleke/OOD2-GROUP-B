using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FlowSimulator
{
    public class Splitter : Part
    {
        private Image compImage, compImageNot, compIcon, compIconNot;
        /// <summary>
        /// The pipeline connected to the top output node
        /// </summary>
        public bool Input = false;

       // public int[] Output = new int[2];
        /// <summary>
        /// The pipeline connected to the top output node
        /// </summary>
        public bool OutputUp =false;
       

        /// <summary>
        /// The pipeline connected to the bottom output node
        /// </summary>
        public bool OutputDown = false;
        
        /// <summary>
        /// Determines the percentage through the first channel of the splitter
        /// </summary>
        public int PercentageUp
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
        /// The remainder from the PercentageUp
        /// </summary>
        public int PercentageDown
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
        /// returns a number of connected nodes
        /// </summary>
        /// <returns></returns>
        public int CheckConnectedNodes()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// To establish a connection
        /// </summary>
        /// <returns></returns>
       public bool Connect(Pipeline p) 
       {
          throw new System.NotImplementedException();
       }

     

        public Splitter(Point position): base(position)
        {
            
           this.compImage = new Bitmap(Properties.Resources.splitter);
           this.compImageNot = new Bitmap(Properties.Resources.splitterNot);
           this.compIcon = new Bitmap(Properties.Resources.splitterIco);
           this.compIconNot = new Bitmap(Properties.Resources.splitterNotIco);
       }
        public override Image ComponentImage(bool isNotOccupied)
        {
            if (isNotOccupied)
            {
                return compImage;
            }
            else return compImageNot;
        }
        public override Image ComponentIconImage(bool isNotOccupied)
        {
            if (isNotOccupied)
            {
                return compIcon;
            }
            else return compIconNot;
        }
    }
}
