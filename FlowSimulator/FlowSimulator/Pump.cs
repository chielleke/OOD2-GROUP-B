using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FlowSimulator
{
    public class Pump : Part
        
    {
        private Image compImage, compImageNot,compIcon, compIconNot;
        /// <summary>
        /// The pipeline connected to the node of this pump
        /// </summary>
        public bool PipelineConnected = false;
        

  /// <summary>
  /// establishes a connection
  /// </summary>
  /// <param name="pipeline"></param>
  /// <returns></returns>
        public bool Connect(Pipeline pipeline)
        {
            throw new System.NotImplementedException();
        }

        public Pump(Point position): base(position)
        {
            this.compImage = new Bitmap(Properties.Resources.pump);
            this.compImageNot = new Bitmap(Properties.Resources.pumpNot);
            this.compIcon = new Bitmap(Properties.Resources.pumpIco);
            this.compIconNot = new Bitmap(Properties.Resources.pumpNotIco);

        }
        public bool Input { get; set; }
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
