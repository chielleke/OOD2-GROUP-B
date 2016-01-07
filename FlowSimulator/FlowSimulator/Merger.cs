using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FlowSimulator
{
    public class Merger : Part
    {  
        private Image compImage, compImageNot, compIcon, compIconNot;
        /// <summary>
        /// The pipeline connected to the top input node
        /// </summary>
        public bool InputUp = false;
        /// <summary>
        /// The pipeline connected to the bottom input node
        /// </summary>
        public bool InputDown = false;
        /// <summary>
        /// the pipeline connected to the output node
        /// </summary>
        public bool Output =false;
        
        /// <summary>
        /// To establish a connection with a pipeline
        /// </summary>
        /// <param name="edge"></param>
        public void Connect(Pipeline pipeline)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// returns how many nodes have been connected with a pipeline
        /// </summary>
        /// <returns></returns>
        public int CheckConnectedNodes()
        {
            throw new System.NotImplementedException();
        }
        public Merger(Point position): base(position)
        {
            this.compImage = new Bitmap(Properties.Resources.merger);
            this.compImageNot = new Bitmap(Properties.Resources.mergerNot);
            this.compIcon = new Bitmap(Properties.Resources.mergerIco);
            this.compIconNot = new Bitmap(Properties.Resources.mergerNotIco);
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
