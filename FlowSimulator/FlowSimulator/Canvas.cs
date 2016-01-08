using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using FlowSimulator.Properties;
using System.Diagnostics;

namespace FlowSimulator
{
    /// <summary>
    /// This class contains the methods for the drawing area(canvas) and when a new component is drawn, it will be added to a list in this class.
    /// </summary>
    ///
    public class Canvas
    {
        private bool IsOccupied;


        /// <summary>
        /// This list will contain all the components that have been drawn on the canvas
        /// </summary>
        public List<Component> Components
        {
            get;
            set;
        }
        /// <summary>
        /// To obtain the coordinates of the position that has been clicked by the mouse
        public Point MousePoint
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        public Size Size { get; set; }

        /// <summary>
        /// Refers to a component that has been selected on the canvas
        /// </summary>
        public Component SelectedComponent
        {
            get;
            set;
        }

        /// <summary>
        /// When multiple components on the canvas have been selected
        /// </summary>
        public List<Component> SelectedComponents
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
        /// To store an action eg. save, undo etc.
        /// </summary>
        public Action Action
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
        /// This list contains the undo-redo actions
        /// </summary>
        public List<Action> UndoRedoList = new List<Action>();
        /// <summary>
        /// this int is used for knowing where canvas is at while using the Undo-Redo List
        /// </summary>
        public int UndoRedoIndex = -1;


        /// <summary>
        /// Responsible for saving a canvas and loading existing canvas
        /// </summary>
        public FileHelper Filehelper
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
        /// To add a new component to the canvas
        /// </summary>
        /// <param name="mousePoint"></param>
        /// <param name="selectedCompIndex"></param>
        public void CreateComponent(Component c)
        {
            Components.Add(c);
        }

        /// <summary>
        /// To remove an existing component from the canvas
        /// </summary>
        /// <param name="selectedComponent"></param>
        public void RemoveComponent(Component selectedComponent)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// To draw a rectangle around the selected component
        /// </summary>
        /// <param name="g"></param>
        public void DrawSelection(PaintEventArgs e, Component selectedComponent)
        {
            foreach (Component c in Components)
            {
                if (c == selectedComponent)
                {
                    Pen p = new Pen(System.Drawing.Color.Gray, 2);
                    e.Graphics.DrawRectangle(p, c.Position.X, c.Position.Y, 40, 40);
                }
            }

        }

        /// <summary>
        /// To select a component on the canvas
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Component SelectComponent(Point point)
        {
            //Point p = point;
            Rectangle temp = new Rectangle(point.X - 5, point.Y - 5, 10, 10);
            foreach (Component c in Components)
            {
                //if (c.SelectionArea.Contains(point))
                if (temp.IntersectsWith(c.SelectionArea))
                {
                    return c;
                }
            }
            return null;
        }

        /// <summary>
        /// To check if it is overlapping
        /// </summary>
        /// <param name="selectedComponent"></param>

        public bool IsOverlapping(Rectangle newPlace)
        {

            foreach (Component c in Components)
            {
                Point p = c.Position;
                Rectangle rec = c.SelectionArea;
                if (newPlace.IntersectsWith(c.SelectionArea))
                {

                    return true;

                }

            }
            return false;
        }

        public Point getMidPoint(Pipeline p)
        {
            return new Point((p.inputPoint.X + p.outputPoint.X) / 2, (p.inputPoint.Y + p.outputPoint.Y) / 2);
        }


        /// <summary>
        /// To adjust the properties of a component on the canvas
        /// </summary>
        /// <param name="selectedComponent"></param>
        /// <returns></returns>
        public bool AdjustProperties(Component selectedComponent)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// To remove multiple selected components from the canvas
        /// </summary>
        /// <param name="selectedComponents"></param>
        public void RemoveComponents(List<Component> selectedComponents)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// To calculate the maximum flow through the network
        /// </summary>
        /// <returns></returns>
        /// 
        private Pipeline p;


        /// <summary>
        /// To calculate the maximum flow through the network
        /// </summary>
        /// <returns></returns>


        /// <summary>
        /// To draw a created component
        /// </summary>
        /// <param name="component"></param>
        /// <param name="e"></param>
        public void DrawComponent(Component c, PaintEventArgs e)
        {
            Image pump = Properties.Resources.pump;
            e.Graphics.DrawImage(pump, c.Position);

        }


        /// <summary>
        /// To undo the last action eg. adding a component
        /// </summary>
        /// <summary>
        /// To undo the last action eg. adding a component
        /// </summary>
        public void UndoLastAction()
        {
            Action CurrentAction = UndoRedoList[UndoRedoIndex];
            switch (CurrentAction.ActionType)
            {
                case ActionType.Create:
                    UndoRedoList[UndoRedoIndex] = new Action(ActionType.Delete, CurrentAction.Component);
                    Components.Remove(CurrentAction.Component);
                    break;
                case ActionType.Move:
                    UndoRedoList[UndoRedoIndex] = new Action(ActionType.Move, CurrentAction.Component);
                    CurrentAction.Component.Position = CurrentAction.Position;
                    break;
                case ActionType.Delete:
                    Components.Add(CurrentAction.Component);
                    UndoRedoList[UndoRedoIndex] = new Action(ActionType.Create, CurrentAction.Component);
                    break;

            }
            UndoRedoIndex--;
        }

        /// <summary>
        /// To redo the last 'undo' action
        /// </summary>
        public void RedoLastAction()
        {
            Action RedoAction = UndoRedoList[UndoRedoIndex + 1];
            switch (RedoAction.ActionType)
            {
                case ActionType.Create:
                    UndoRedoList[UndoRedoIndex + 1] = new Action(ActionType.Delete, RedoAction.Component);
                    Components.Remove(RedoAction.Component);
                    break;
                case ActionType.Move:
                    UndoRedoList[UndoRedoIndex + 1] = new Action(ActionType.Move, RedoAction.Component);
                    RedoAction.Component.Position = RedoAction.Position;
                    break;
                case ActionType.Delete:
                    Components.Add(RedoAction.Component);
                    UndoRedoList[UndoRedoIndex + 1] = new Action(ActionType.Create, RedoAction.Component);
                    break;

            }
            UndoRedoIndex++;
        }
        /// <summary>
        /// this is used for creating an undo. NOTE: use this method before you give the component it's new position or before you delete the component!
        /// </summary> 
        /// <param name="ActType">type "Create", "Delete" or "Move" here without quotations</param>
        /// <param name="comp">reference to the component</param>
        public void CreateUndo(ActionType ActType, Component comp)
        {
            UndoRedoList.Add(new Action(ActType, comp));
            UndoRedoIndex++;
            if (UndoRedoIndex + 1 < UndoRedoList.Count)
            { UndoRedoList.RemoveAt(UndoRedoIndex + 1); }

        }


        /// <summary>
        /// To redraw an action that was deleted or moved(part of the Undo/redo methods)
        /// </summary>
        /// <param name="action"></param>
        public void ReDraw(Action action)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// To draw a created component that is a pipeline
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        public Pipeline SelectPipeline(Point p)
        {
            Pipeline pipe;
            foreach (Component comp in Components)
            {
                if (comp is Pipeline)
                {
                    pipe = ((Pipeline)comp);
                    if (DistanceFromPointToLine(p, pipe.inputPoint, pipe.outputPoint) < 4)
                    {
                        return pipe;
                    }
                }
            }
            return null;
        }
        public static double DistanceFromPointToLine(Point pt, Point p1, Point p2)
        {
            PointF closest;
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;

            // Calculate the t that minimizes the distance.
            float t = ((pt.X - p1.X) * dx + (pt.Y - p1.Y) * dy) / (dx * dx + dy * dy);

            // See if this represents one of the segment's
            // end points or a point in the middle.
            if (t < 0)
            {
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
            }
            else if (t > 1)
            {
                dx = pt.X - p2.X;
                dy = pt.Y - p2.Y;
            }
            else
            {
                closest = new PointF(p1.X + t * dx, p1.Y + t * dy);
                dx = pt.X - closest.X;
                dy = pt.Y - closest.Y;
            }
            return Math.Sqrt(dx * dx + dy * dy);
        }
        /// <summary>
        /// A simple method that checkes wich Component you are looking for and returns the one you are looking for
        /// </summary>
        /// <param name="p">the coordinates</param>
        /// <returns></returns>
        public Component GetComponent(Point p)
        {
            
            foreach (Component comp in Components)
            {
                if (comp.Position == p)
                {
                    return comp;
                }
               
            }
            return null;


        }


        public void DeletePipeline(Point p)
        {
            Pipeline tempPipe = null;
            foreach (Pipeline pipe in Components)
            {
                if (DistanceFromPointToLine(p, pipe.inputPoint, pipe.outputPoint) < 4)
                {
                    tempPipe = pipe;
                    break;
                }
            }
            foreach (Component c in Components)
            {
                // delete connections
                if (tempPipe.Input == c)
                {
                    if (c is Pump)
                    {
                        ((Pump)c).PipelineConnected = false;
                        break;
                    }
                    else if (c is Splitter)
                    {
                        if (tempPipe._selectedOutput == 1)
                        {
                            ((Splitter)c).OutputUp = false;
                        }
                        else if (tempPipe._selectedOutput == 1)
                        {
                            ((Splitter)c).OutputDown = false;
                        }
                        break;
                    }
                    else if (c is Merger)
                    {
                        ((Merger)c).Output = false;
                        break;
                    }

                }
            }

            foreach (Component c in Components)
            {
                // delete connections
                if (tempPipe.Output == c)
                {
                    if (c is Splitter)
                    {

                        ((Splitter)c).Input = false;

                        break;
                    }
                    else if (c is Merger)
                    {
                        if (tempPipe._selectedOutput == 1)
                        {
                            ((Merger)c).InputUp = false;
                        }
                        else if (tempPipe._selectedOutput == 1)
                        {
                            ((Merger)c).InputDown = false;
                        }
                        break;
                    }
                    else
                    {
                        ((Sink)c).PipelineConnected = false;
                        break;
                    }
                }
            }
            Components.Remove(tempPipe);           //delete selected wire
        }


        public void DeleteComponent(Point mouseClicked)
        {
            //Rectangle tempMousePoint = new Rectangle(mouseClicked, new Size(1, 1));


            // removes all Components connected
            foreach (Pipeline pipe in Components.Cast<Pipeline>())
            {


                if (pipe.Output == SelectComponent(mouseClicked))
                {
                    DeletePipeline(pipe.outputPoint);

                }
                else if (pipe.Input == SelectComponent(mouseClicked))
                {
                    DeletePipeline(pipe.inputPoint);


                }
            }
            Components.Remove(SelectComponent(mouseClicked));
        }
        public Pipeline findSplitterPipeline(Component input)
        {
            Pipeline pipeline = null;
            foreach (Component comp in Components)
            {
                if (comp is Pipeline)
                {
                    pipeline = ((Pipeline)comp);

                    if (pipeline != null)
                    {
                        if (pipeline.Input == input)
                            return SelectPipeline(new Point(input.Position.X + 40, input.Position.Y + 10));
                        // temp = pipeline;
                    }
                }
            }
            return pipeline;
        }

        private bool isUpdated = false;
        public void UpdateProperties(Component updatedComponent)
        {
            Component temp = null;
            Pipeline pipeline = null;
            foreach (Component comp in Components)
            {
                if (comp is Pipeline)
                {
                    pipeline = ((Pipeline)comp);
                }
                if (pipeline != null)
                {
                    if (pipeline.Input == updatedComponent)
                    {
                        if (!isUpdated)
                        {
                            pipeline.Output.CurrentFlow += (updatedComponent.CurrentFlow - pipeline.CurrentFlow);
                            pipeline.CurrentFlow = pipeline.Output.CurrentFlow;

                        }
                        if (pipeline.CurrentFlow != pipeline.Input.CurrentFlow && pipeline.Input.GetType() == typeof(Pump))
                        {
                            pipeline.CurrentFlow = pipeline.Input.CurrentFlow;
                            pipeline.Output.CurrentFlow = pipeline.CurrentFlow;
                        }


                        if (pipeline.Output.GetType() == typeof(Splitter))
                        {
                            if (pipeline.Output.OutPutUp != null)
                            {

                                p = findSplitterPipeline(pipeline.Output.OutPutUp);
                                p.CurrentFlow = Math.Round(pipeline.Output.CurrentFlow *
                                                    ((Splitter)pipeline.Output).PercentageUp, 2);


                            }
                            if (pipeline.Output.OutPutDown != null)
                            {

                                p = findSplitterPipeline(pipeline.Output.OutPutDown);
                                p.CurrentFlow = Math.Round(pipeline.Output.CurrentFlow *
                                                    ((Splitter)pipeline.Output).PercentageDown, 2);

                            }


                            updatedComponent = pipeline.Output;
                        }
                    }
                }
            }
            isUpdated = true;
        }
        public bool DrawPipeline(Component c1, Component c2)
        {
            int selectedIndex = 0;

            Component temp1 = c1;
            Component temp2 = c2;
            if (c1 != c2)
            {
                if (c1 is Pump)
                {
                    if (((Pump)c1).PipelineConnected == false)
                    {
                        bool cr = ((Pump)c1).PipelineConnected;
                        if (c2 is Sink)
                        {
                            if (((Sink)c2).PipelineConnected == false)
                            {

                                foreach (Component c in Components)
                                {
                                    if (c == c1)
                                    {
                                        ((Pump)c).PipelineConnected = true;
                                        ((Pump)c).OutPut = c2;
                                    }
                                    else if (c == c2)
                                    {
                                        ((Sink)c).PipelineConnected = true;
                                        ((Sink)c).InPut = c1;
                                        ((Sink)c).CurrentFlow += c1.CurrentFlow;

                                    }

                                }
                                Components.Add(new Pipeline(c1, c2, selectedIndex));
                                return true;
                                selectedIndex = 0;
                            }
                        }
                        else if (c2 is Splitter)
                        {
                            if (((Splitter)c2).Input == false)
                            {


                                foreach (Component c in Components)
                                {
                                    if (c == c1)
                                    {
                                        ((Pump)c).PipelineConnected = true;
                                    }
                                    else if (c == c2)
                                    {

                                        ((Splitter)c).Input = true;
                                        ((Splitter)c2).InPut = c1;
                                        ((Splitter)c).CurrentFlow += c1.CurrentFlow;

                                    }

                                }
                                Components.Add(new Pipeline(c1, c2, selectedIndex));
                                selectedIndex = 0;
                                return true;
                            }
                        }
                        else if (c2 is Merger)
                        {
                            if (((Merger)c2).InputDown == false || ((Merger)c2).InputUp == false)
                            {
                                bool b = ((Pump)c1).PipelineConnected;

                                foreach (Component c in Components)
                                {
                                    if (c == c1)
                                    {
                                        ((Pump)c).PipelineConnected = true;

                                    }
                                    else if (c == c2)
                                    {
                                        if (((Merger)c).InputUp == false)
                                        {
                                            selectedIndex = 1;
                                            ((Merger)c).InputUp = true;
                                            ((Merger)c).InPutUp = c1;

                                            ((Merger)c2).CurrentFlow += c1.CurrentFlow;

                                        }
                                        else if (((Merger)c).InputDown == false)
                                        {
                                            selectedIndex = 2;
                                            ((Merger)c).InputDown = true;
                                            ((Merger)c).InPutDown = c1;
                                            ((Merger)c2).CurrentFlow += c1.CurrentFlow;
                                        }


                                    }

                                }
                                Components.Add(new Pipeline(c1, c2, selectedIndex));
                                selectedIndex = 0;
                                return true;
                            }
                        }
                    }
                }
                else if (c1 is Sink)
                {
                    temp1 = c2;
                    temp2 = c1;

                    if (DrawPipeline(temp1, temp2))
                    {
                        return true;

                    }
                }

                else if (c1 is Splitter)
                {
                    if (((Splitter)c1).OutputDown == false || ((Splitter)c1).OutputUp == false)
                    {
                        if (c2 is Pump)
                        {
                            temp1 = c2;
                            temp2 = c1;
                            if (DrawPipeline(temp1, temp2))
                                return true;
                        }
                        else if (c2 is Sink)
                        {
                            bool alreadyConnected = false;

                            if (((Sink)c2).PipelineConnected == false)
                            {
                                foreach (Component c in Components)
                                {
                                    if (c == c1)
                                    {
                                        if (((Splitter)c).OutputUp == false)
                                        {

                                            selectedIndex = 1;
                                            ((Splitter)c).OutputUp = true;
                                            c1.OutPutUp = c2;

                                            double flow = c1.CurrentFlow * ((Splitter)c).PercentageUp;
                                            c1.OutPutUp.CurrentFlow = Math.Round(flow, 2);


                                        }

                                        else if (((Splitter)c).OutputDown == false)
                                        {
                                            selectedIndex = 2;
                                            ((Splitter)c).OutputDown = true;
                                            c1.OutPutDown = c2;
                                            double flow = c1.CurrentFlow * ((Splitter)c).PercentageDown;
                                            c1.OutPutDown.CurrentFlow = Math.Round(flow, 2);




                                        }
                                    }
                                    else if (c == c2)
                                    {
                                        if (((Sink)c).PipelineConnected == false)
                                        {

                                            ((Sink)c).PipelineConnected = true;
                                            ((Sink)c).InPut = c1;

                                        }
                                        else
                                        {
                                            alreadyConnected = true;
                                        }
                                    }


                                }
                                if (!alreadyConnected)
                                {
                                    Components.Add(new Pipeline(c1, c2, selectedIndex));
                                    selectedIndex = 0;
                                    return true;

                                }
                                return false;
                            }


                        }

                        else if (c2 is Merger)
                        {
                            int selectedIndex2 = 0;
                            if (((Merger)c2).InputDown == false || ((Merger)c2).InputUp == false)
                            {
                                foreach (Component c in Components)
                                {
                                    if (c == c1)
                                    {
                                        if (((Splitter)c).OutputUp == false)
                                        {
                                            selectedIndex = 1;
                                            ((Splitter)c).OutputUp = true;
                                            c1.OutPutUp = c2;
                                            double flow = c1.CurrentFlow * ((Splitter)c).PercentageUp;
                                            c1.CurrentFlow = Math.Round(flow, 2);
                                            c2.CurrentFlow += c1.CurrentFlow;

                                        }

                                        else if (((Splitter)c).OutputDown == false)
                                        {
                                            selectedIndex = 2;

                                            ((Splitter)c).OutputDown = true;
                                            c1.OutPutDown = c2;
                                            double flow = c1.CurrentFlow * ((Splitter)c).PercentageDown;
                                            c1.CurrentFlow = Math.Round(flow, 2);
                                            c2.CurrentFlow += c1.CurrentFlow;

                                        }
                                    }
                                    else if (c == c2)
                                    {
                                        if (((Merger)c).InputUp == false)
                                        {
                                            selectedIndex2 = 1;
                                            ((Merger)c).InputUp = true;
                                            ((Merger)c).InPutUp = c1;
                                            ((Merger)c).CurrentFlow += c1.CurrentFlow;
                                        }
                                        else if (((Merger)c).InputDown == false)
                                        {
                                            selectedIndex2 = 2;
                                            ((Merger)c).InputDown = true;
                                            ((Merger)c).InPutDown = c1;
                                            ((Merger)c).CurrentFlow += ((Merger)c).InPutDown.CurrentFlow;
                                        }

                                    }

                                }
                                Components.Add(new Pipeline(c1, c2, selectedIndex, selectedIndex2));
                                selectedIndex = 0;
                                return true;
                            }
                        }
                        else if (c2 is Splitter)
                        {
                            if (((Splitter)c2).Input == false)
                            {


                                foreach (Component c in Components)
                                {
                                    if (c == c1)
                                    {
                                        if (((Splitter)c).OutputUp == false)
                                        {
                                            selectedIndex = 1;
                                            ((Splitter)c).OutputUp = true;
                                            ((Splitter)c).OutPutUp = c1;
                                            double flow = c1.CurrentFlow * ((Splitter)c).PercentageUp;
                                            c1.CurrentFlow = Math.Round(flow, 2);
                                            c2.CurrentFlow += c1.CurrentFlow;
                                        }
                                        else if (((Splitter)c).OutputDown == false)
                                        {
                                            selectedIndex = 2;

                                            ((Splitter)c).OutputDown = true;
                                            ((Splitter)c).OutPutDown = c1;
                                            double flow = c1.CurrentFlow * ((Splitter)c).PercentageDown;
                                            c1.CurrentFlow = Math.Round(flow, 2);
                                            c2.CurrentFlow += c1.CurrentFlow;

                                        }


                                    }
                                    else if (c == c2)
                                    {
                                        if (((Splitter)c).Input == false)
                                            ((Splitter)c).Input = true;
                                        ((Splitter)c2).InPut = c1;

                                    }

                                }
                                Components.Add(new Pipeline(c1, c2, selectedIndex));
                                selectedIndex = 0;
                                return true;
                            }
                        }
                    }

                }
                else if (c1 is Merger)
                {
                    if (((Merger)c1).Output == false)
                    {

                        if (c2 is Pump)
                        {
                            temp1 = c2;
                            temp2 = c1;
                            if (DrawPipeline(temp1, temp2))
                                return true;
                        }
                        else if (c2 is Sink)
                        {
                            if (((Sink)c2).PipelineConnected == false)
                            {
                                foreach (Component c in Components)
                                {
                                    if (c == c1)
                                    {
                                        if (((Merger)c).Output == false)

                                            ((Merger)c).Output = true;
                                    }
                                    else if (c == c2)
                                    {
                                        if (((Sink)c).PipelineConnected == false)
                                        {
                                            selectedIndex = 0;
                                            ((Sink)c).PipelineConnected = true;
                                            ((Sink)c).InPut = c1;
                                            ((Sink)c).CurrentFlow += c1.CurrentFlow;
                                        }
                                    }

                                }
                                Components.Add(new Pipeline(c1, c2, selectedIndex));
                                selectedIndex = 0;
                                return true;
                            }
                        }
                        else if (c2 is Splitter)
                        {
                            if (((Splitter)c2).Input == false)
                            {

                                foreach (Component c in Components)
                                {
                                    if (c == c1)
                                    {
                                        if (((Merger)c).Output == false)

                                            ((Merger)c).Output = true;

                                    }
                                    else if (c == c2)
                                    {
                                        if (((Splitter)c).Input == false)
                                        {
                                            selectedIndex = 0;
                                            ((Splitter)c).Input = true;
                                            ((Splitter)c).InPut = c1;
                                            ((Splitter)c).CurrentFlow += c1.CurrentFlow;

                                        }
                                    }

                                }
                                Components.Add(new Pipeline(c1, c2, selectedIndex));
                                selectedIndex = 0;
                                return true;
                            }
                        }
                        else if (c2 is Merger)
                        {
                            if (((Merger)c2).InputDown == false || ((Merger)c2).InputUp == false)
                            {
                                foreach (Component c in Components)
                                {
                                    if (c == c1)
                                    {
                                        if (((Merger)c).Output == false)

                                            ((Merger)c).Output = true;

                                    }
                                    else if (c == c2)
                                    {
                                        if (((Merger)c).InputUp == false)
                                        {
                                            selectedIndex = 1;
                                            ((Merger)c).InputUp = true;
                                            ((Merger)c).InPutUp = c1;
                                            ((Merger)c).CurrentFlow += ((Merger)c1).CurrentFlow;

                                        }
                                        else if (((Merger)c).InputDown == false)
                                        {
                                            selectedIndex = 2;
                                            ((Merger)c).InputDown = true;
                                            ((Merger)c).InPutDown = c1;
                                            ((Merger)c).CurrentFlow += ((Merger)c1).CurrentFlow;
                                        }
                                    }

                                }
                                Components.Add(new Pipeline(c1, c2, selectedIndex));
                                selectedIndex = 0;
                                return true;
                            }

                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return false;
        }


        /// <summary>
        /// to give the coordinates of the line
        /// </summary>
        /// <returns></returns>
        //private Point  AssignFirstCoordinate()
        // {
        //    if()
        // }

        /// <summary>
        /// Refreshes the drawing area with all changes that has been made
        /// </summary>
        public void RefreshCanvas()
        {
            throw new System.NotImplementedException();
        }
        public Canvas()
        {

            Components = new List<Component>();


        }


    }
}
