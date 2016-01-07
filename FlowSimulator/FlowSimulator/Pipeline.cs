using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FlowSimulator
{

    public class Pipeline :Component
    {
        
        /// <summary>
        /// The input component connected to the pipeline
        /// </summary>
        public Component Input { get; set; }

        public Pipeline(Component input, Component output, double flow)
        {
            this.Input = input;
            this.Output = output;
            this.CurrentFlow = Convert.ToInt32(input.CurrentFlow);

        }

        // returns the remaining capacity on a pipe
        public double getCapacity(Component from, Component to)
        {//forward flow
            if (Input.Equals(from) && Output.Equals(to))
                return Capacity - CurrentFlow;
            //backwards flow
            if (Input.Equals(to) && Output.Equals(from))
                return CurrentFlow;

            throw new ArgumentException("Both from " + from.GetType() + " and " + from.GetType() +
                                        "should be a part of this pipeline");
        }

       
        public int AdjustCapacity(Component from, Component to, int flow)
        {
            if (flow > getCapacity(from, to))
                throw new ArgumentException("The flow: "+flow+"exceeds the limit");
           // forward flow
            if (Input.Equals(from) && Output.Equals(to))
                this.CurrentFlow += flow;
            // backwards flow
            if (Input.Equals(to) && Output.Equals(from))
                this.CurrentFlow -= flow;
                
            throw new ArgumentException("Both from: "+from.GetType()+" and "+to.GetType()+" should be a part of this pipeline");
        }

    /// <summary>
        /// The output component connected to the pipeline
        /// </summary>
        public Component Output
        {
            get;
            set;
        }

        /// <summary>
        /// Determines if the flow through the pipeline is critical
        /// </summary>
        public bool IsCritical
        {
            get;
            set;
        }

        private Point _inputPoint;
        private Point _outputPoint;
        public int _selectedOutput { get; set; }
        public int _selectedOutput2 { get; set; }
        public Pipeline(Component c1, Component c2, int selectedOutput)
        {
            this.Input = c1;
            this.Output = c2;
            _selectedOutput = selectedOutput;
            this.Capacity = 0;
            this.CurrentFlow = Convert.ToInt32(c1.CurrentFlow);
            //this.AssignInputPoint();
           // this.AssignOutputPoint();
        }
        public Pipeline(Component c1, Component c2, int selectedOutput, int selectedOutput2)
        {
            this.Input = c1;
            this.Output = c2;
            _selectedOutput = selectedOutput;
            _selectedOutput2 = selectedOutput2;
            this.Capacity = 0;
            this.CurrentFlow = Convert.ToInt32(c1.CurrentFlow);
          //  this.AssignInputPoint();
           // this.AssignOutputPoint();
        }
        /// <summary>
        /// first point of the connection
        /// </summary>
        public Point inputPoint
        {
            get
            {
                if (Input is Pump)
                {
                    
                    //if (_selectedOutput == 0)
                        return new Point(Input.Position.X+40, Input.Position.Y + 10);

                }
                else if (Input is Splitter)
                {
                    if (_selectedOutput == 1)
                    {
                        return new Point(Input.Position.X +40, Input.Position.Y + 10);
                    }
                    else if (_selectedOutput == 2)
                        return new Point(Input.Position.X+40, Input.Position.Y + 30);
                }
                else if (Input is Merger)
                {

                   // if (_selectedOutput == 0)
                        return new Point(Input.Position.X + 40, Input.Position.Y + 20);

                }
                return new Point(0, 0);
            } 
        }
        public Point outputPoint
        {
            get
            {
                if (Output is Sink)
                {
                    //if (((Sink)Output).PipelineConnected == false) 
                       return new Point(Output.Position.X, Output.Position.Y + 17);

                }
                else if (Output is Splitter)
                {
                     return new Point(Output.Position.X, Output.Position.Y + 20);

                }
                else if (Output is Merger)
                {
                    if (Input is Splitter)
                    {
                        if (_selectedOutput2 == 1)
                            return new Point(Output.Position.X, Output.Position.Y + 10);
                        if (_selectedOutput2 == 2)
                            return new Point(Output.Position.X, Output.Position.Y + 30);
                    }
                    else
                    {
                        if (_selectedOutput == 1)
                            return new Point(Output.Position.X, Output.Position.Y + 10);
                        if (_selectedOutput == 2)
                            return new Point(Output.Position.X, Output.Position.Y + 30);
                    }
                }
                return new Point(0, 0);
            } 
        }





    }
}
