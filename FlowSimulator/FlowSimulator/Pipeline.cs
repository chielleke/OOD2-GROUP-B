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

        public Pipeline(Component input, Component output, double CurrentFlow)
        {
            this.Input = input;
            this.Output = output;
            if (input.GetType() == typeof(Splitter))
            {
                if (input.OutPutUp != null && input.OutPutDown == null)
                {
                    this.CurrentFlow = input.OutPutUp.CurrentFlow;
                }
                else this.CurrentFlow = input.OutPutDown.CurrentFlow;
            }
            else
            { this.CurrentFlow = Convert.ToDouble(input.CurrentFlow); }

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
        /// Determines if the CurrentFlow through the pipeline is critical
        /// </summary>
        public bool IsCritical
        {
            get
            {
                if (CurrentFlow > Capacity)
                    return true;
                else
                {
                    return false;
                }
            }
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
            if (c1.GetType() == typeof(Splitter))
            {
                if (c1.OutPutUp != null && c1.OutPutDown == null)
                {
                    this.CurrentFlow = c1.OutPutUp.CurrentFlow;
                }
                else this.CurrentFlow = c1.OutPutDown.CurrentFlow;
            }
            else
            { this.CurrentFlow = Convert.ToDouble(c1.CurrentFlow); }
        }
        public Pipeline(Component c1, Component c2, int selectedOutput, int selectedOutput2)
        {
            this.Input = c1;
            this.Output = c2;
            _selectedOutput = selectedOutput;
            _selectedOutput2 = selectedOutput2;
            this.Capacity = 0;
            if (c1.GetType() == typeof(Splitter))
            {
                if (c1.OutPutUp != null && c1.OutPutDown == null)
                {
                    this.CurrentFlow = c1.OutPutUp.CurrentFlow;
                }
                else this.CurrentFlow = c1.OutPutDown.CurrentFlow;
            }
            else
            { this.CurrentFlow = Convert.ToDouble(c1.CurrentFlow); }
            
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
