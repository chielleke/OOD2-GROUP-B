using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowSimulator
{

    public partial class FlowNetworkSimulator : Form
    {

        Canvas canvas; // drawing area
        Point mousepoint; //point where mouse was clicked
        int selectedIndex;
        Part selectedPart, tempPart;
        Component selectedComponent, tempComponent;
        Point oldCoordinates; //old ccordinates of a component
        private Rectangle area;
        private ToolTip tooltip = new ToolTip();  // to show errors
        private bool compIsMoving = false, isOccupied = false, isSelected = false, addNewPipeline = false, connectedComp1 = false, wireIsSelected = false;
        Point first, second, third;
        Pipeline selectedPipeline;
        public FlowNetworkSimulator()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            canvas = new Canvas();
            area = new Rectangle(new Point(120,95), new Size(550, 380));
            label8.Text = "Upper flow: " + 50 + "\n" + "Lower flow: " + 50;
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {



        }
        private void EnablePropertiesPane(Component c)
        {

        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {


        }

        private void btnPump_Click(object sender, EventArgs e)
        {
            selectedComponent = new Pump(new Point(0, 0));
        }

     

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel3_DragDrop(object sender, DragEventArgs e)
        {
            // Image selCom = (Image)sender;

        }

        private void panel3_DoubleClick(object sender, EventArgs e)
        {

        }

        private void FlowNetworkSimulator_Load(object sender, EventArgs e)
        {
            
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((selectedComponent = canvas.SelectComponent(mousepoint)) != null)
            {
                foreach (Component comp in canvas.Components)
                {
                    if (selectedComponent.SelectionArea.IntersectsWith(comp.SelectionArea))
                    {
                        oldCoordinates = comp.Position;
                        canvas.Components.Remove(comp);
                        break;
                    }
                }
                isSelected = false;
                compIsMoving = true;
                this.Refresh();
            }
        }

        private void FlowNetworkSimulator_Click(object sender, MouseEventArgs e)
        {
          


        }

        private void FlowNetworkSimulator_MouseClick(object sender, MouseEventArgs e)
        {
            mousepoint = PointToClient(Cursor.Position);
            tooltip.RemoveAll();
            IWin32Window win = this;
            if (e.Button == MouseButtons.Left)
            {

                isSelected = false;

                if ((tempComponent = canvas.SelectComponent(mousepoint)) != null)
                {
                    isSelected = true;
                    if (tempComponent.GetType() == typeof(Splitter))
                        trackBar1.Enabled = true;
                    else
                    {
                        trackBar1.Enabled = false;
                    }
                    if (tempComponent.GetType() == typeof(Pump))
                        textBox1.Enabled = true;
                    else
                    {
                        textBox1.Enabled = false;
                    }

                    
                    
                    this.Refresh();


                }
                if (selectedComponent != null && !canvas.IsOverlapping(selectedComponent.SelectionArea) && area.IntersectsWith(new Rectangle(mousepoint, new Size(40, 40))))
                {
                   
                    selectedComponent.Position = new Point(mousepoint.X, mousepoint.Y);
                    selectedComponent.UpdateSelectionArea();
                  
                    canvas.CreateComponent(selectedComponent);
                    canvas.CreateUndo(ActionType.Create, selectedComponent);
                    UndoButton.Enabled = true;
                    selectedComponent = null;
                    compIsMoving = false;
                    
                    this.Refresh();
                    this.Cursor = Cursors.Arrow;
                }
               
                
                
                if (selectedComponent != null && canvas.IsOverlapping(selectedComponent.SelectionArea) || !area.IntersectsWith(new Rectangle(mousepoint, new Size(40, 40))))
                {
                    canvas.CreateUndo(ActionType.Move, selectedComponent);
                    UndoButton.Enabled = true;
                    if (compIsMoving)
                    {
                       
                        selectedComponent.Position = oldCoordinates;
                        selectedComponent.UpdateSelectionArea();
                       // if(selectedComponent)
                        canvas.CreateComponent(selectedComponent);
                        compIsMoving = false;
                        this.Refresh();
                    }
                    
                    selectedComponent = null;
                    //this.Cursor = Cursors.Arrow;
                    tooltip.Show("You cannot place a component here", win, mousepoint);
                    this.Cursor = Cursors.Arrow;
                   
                        }
                if (addNewPipeline)
                {
                    if (!connectedComp1)
                    {
                        first = new Point(mousepoint.X, mousepoint.Y);
                        connectedComp1 = true;

                    }
                    else
                    {
                        second = new Point(mousepoint.X, mousepoint.Y);
                        if (canvas.DrawPipeline(canvas.SelectComponent(first), canvas.SelectComponent(second)))
                        {   
                            connectedComp1 = false;
                            addNewPipeline = false;

                           
                           
                            this.Refresh();
                            this.Cursor = Cursors.Arrow;
                        }
                        else
                        {
                            tooltip.Show("Unable to establish a connection", win, Cursor.Position);
                            connectedComp1 = false;
                            this.Cursor = Cursors.Arrow;
                            this.Refresh();
                        }
                    }
                }

               
            }
            else if (e.Button == MouseButtons.Right)
            {
              //  mousepoint = this.formPointToClient(Cursor.Position);
                //this.Cursor = Cursors.Arrow;


                if ((tempComponent = canvas.SelectComponent(mousepoint)) != null)
                {
                    isSelected = true;
                    this.Refresh();
                    cmsEdit.Show(Cursor.Position);

                }
                else if ((selectedPipeline = canvas.SelectPipeline(mousepoint)) != null)
                {
                    
                    cmsEditPipeline.Show(Cursor.Position);
                    wireIsSelected = true;
                }
                else
                {
                    isSelected = false;
                }

                this.Refresh();
            }
           
            if (isSelected)
            {
                Component temp = canvas.SelectComponent(mousepoint);
                flowLabel.Location = new Point(temp.Position.X + 6, temp.Position.Y - 15);
                flowLabel.Text = temp.Capacity+ "("+ temp.CurrentFlow + ")";
            }
            if ((selectedPipeline = canvas.SelectPipeline(mousepoint)) != null)
            {
                flowLabel.Location = canvas.getMidPoint(selectedPipeline);
                flowLabel.Text = selectedPipeline.Capacity + "(" + selectedPipeline.CurrentFlow+")";
            }
        }

        private bool propertiesSet = true;
        private void FlowNetworkSimulator_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (selectedComponent != null)
                {
                    Point mouseClick = this.PointToClient(Cursor.Position);
                    selectedComponent.Position = new Point(mouseClick.X, mouseClick.Y);
                    selectedComponent.UpdateSelectionArea();
                    Rectangle tempRec = new Rectangle(mouseClick, new Size(40, 40));
                    if (canvas.IsOverlapping(tempRec) || !area.IntersectsWith(tempRec) && !propertiesSet)
                    {
                        this.Cursor = new Cursor(((Bitmap)((Part)selectedComponent).ComponentIconImage(false)).GetHicon());
                    }
                    else
                    {
                        this.Cursor = new Cursor(((Bitmap)((Part)selectedComponent).ComponentIconImage(true)).GetHicon());

                    }
                    if (compIsMoving)
                    {
                        selectedComponent.Position = new Point(mouseClick.X, mouseClick.Y);
                        Component temp = selectedComponent;
                        flowLabel.Location = new Point(temp.Position.X + 6, temp.Position.Y - 15);
                        flowLabel.Text = temp.Capacity + "(" + temp.CurrentFlow + ")";
                    }
                    this.Refresh();
                }
            }
            catch
            {
                selectedComponent = null;

            }
        }

        private void FlowNetworkSimulator_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics gr = e.Graphics;
                if (canvas.Components != null)
                {
                    foreach (Component comp in canvas.Components)
                    {
                        if (comp is Part)
                            gr.DrawImage(((Part) comp).ComponentImage(true), comp.Position);
                        else
                        {
                            p = (Pipeline) comp;
                            if (p.IsCritical)
                            {
                                Pen pen1 = new Pen(Color.Red, 5);
                                gr.DrawLine(pen1, p.inputPoint, p.outputPoint);
                            }
                            else
                            {

                                Pen pen1 = new Pen(Color.DeepSkyBlue, 5);
                                gr.DrawLine(pen1, p.inputPoint, p.outputPoint);
                            }
                        }
                    }

                }
                if (isSelected)
                {
                    Pen pen = new Pen(Color.Gray, 3);
                    Rectangle rec = canvas.SelectComponent(mousepoint).SelectionArea;
                    gr.DrawRectangle(pen, rec);
                }
                
                
                
            }
            catch
            {
                isSelected = false;
            }


        }

        private void btnSink_Click(object sender, EventArgs e)
        {
            selectedComponent = new Sink(new Point(0, 0));
        }

        private void btnSplitter_Click(object sender, EventArgs e)
        {
            selectedComponent = new Splitter(new Point(0, 0));
        }

        private void btnMerger_Click(object sender, EventArgs e)
        {
            selectedComponent = new Merger(new Point(0, 0));
        }
        //private bool HasPipes()
        //{
        //    foreach (Pipeline Pipe in canvas.Components)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        private void UndoButton_Click(object sender, EventArgs e)
        {
            canvas.UndoLastAction();
            if (canvas.UndoRedoIndex==-1)
            {
                UndoButton.Enabled = false;
            }
            RedoButton.Enabled = true;
            this.Refresh();

        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            canvas.RedoLastAction();
            if (canvas.UndoRedoIndex +1 == canvas.UndoRedoList.Count)
            {
                RedoButton.Enabled = false;
            }
            UndoButton.Enabled = true;
            this.Refresh();
            
        }

        private void btnPipe_Click(object sender, EventArgs e)
        {
            this.selectedComponent = null;
            if (canvas.Components.Count < 2)
            {
                IWin32Window win = this;
                tooltip.Show("Operation was canceled. Reason:\nYou must have at least two gates in your plain", win, Cursor.Position);
            }
            else
            {
                this.Cursor = Cursors.Cross;
                addNewPipeline = true;
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            canvas.DeletePipeline(mousepoint);
            isSelected = false;
            this.Refresh();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            canvas.DeleteComponent(mousepoint);
           
            isSelected = false;
            this.Refresh();
        }
        Pipeline p;
        private void textBox2_TextChanged(object sender, EventArgs e) // capacity
        {
            if ((selectedComponent = canvas.SelectComponent(mousepoint)) != null)
            {
                if (textBox2.Text != "")
                {
                    selectedComponent.Capacity = Convert.ToInt32(textBox2.Text);
                    selectedComponent.CurrentFlow = Convert.ToInt32(textBox1.Text);

                    flowLabel.Text = selectedComponent.Capacity + "(" + selectedComponent.CurrentFlow + ")";
                    if (selectedComponent.Capacity < selectedComponent.CurrentFlow)
                        flowLabel.ForeColor = Color.Red;

                    else flowLabel.ForeColor = Color.Black;

                }
            }
            selectedComponent = null;

            this.Refresh();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//  flow
        {
            Component temp;
           
            if ((temp = canvas.SelectComponent(mousepoint)) != null)
            {
                if (textBox1.Text != "")
                {
                    temp.CurrentFlow = Convert.ToInt32(textBox1.Text);
                    flowLabel.Text = temp.Capacity + "(" + temp.CurrentFlow + ")";
                    if (temp.Capacity < temp.CurrentFlow)
                        flowLabel.ForeColor = Color.Red;
                    else flowLabel.ForeColor = Color.Black;
                    canvas.UpdateProperties(temp);
                }
            }
            selectedComponent = null;

            this.Refresh();
        }



        private double percentage, remainingpercentage;
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
           
            if ((selectedComponent = canvas.SelectComponent(mousepoint)) != null && selectedComponent.GetType() == typeof(Splitter))
            {
                percentage = trackBar1.Value;
                remainingpercentage = trackBar1.Maximum - percentage;
                label8.Text = "Upperflow: " + percentage * 10 + "\n" + "Lowerflow: " + remainingpercentage * 10;

                ((Splitter)selectedComponent).PercentageUp = percentage / 10;
                ((Splitter)selectedComponent).PercentageDown = remainingpercentage / 10;
                canvas.UpdateProperties(selectedComponent);
                


            }
            selectedComponent = null;
            this.Refresh();
            
        }
            
        private int maxFlow, currentFlow;
       

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //panel5.Enabled = true;
            //maxFlow = 0;
            //currentFlow = 0;
            //if ((selectedComponent = canvas.SelectComponent(mousepoint)) != null)

               
            //        currentFlow = Convert.ToInt32(textBox1.Text);
            //        maxFlow = Convert.ToInt32(textBox2.Text);
            //        if (currentFlow <= maxFlow)
            //        {

            //            selectedComponent.CurrentFlow = currentFlow;
            //            selectedComponent.Capacity = maxFlow;

            //        }
            //        else
            //        {
            //            IWin32Window win = this;
            //            tooltip.Show("current flow cannot be higher than the maximum flow.", win, Cursor.Position);
            //        }

                }
              
        


        }
    }
