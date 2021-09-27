using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWars
{
    public partial class frmRobotWars : Form
    {
        private Grid myGrid = new Grid();
        private Robot robot;
        private int origin_x = 0, origin_y = 0;

        public frmRobotWars()
        {
            InitializeComponent();
        }

        private void frmRobotWars_Load(object sender, EventArgs e)
        {

        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            grpBox_Robot1.Enabled = true;
            grpBox_Robot2.Enabled = true;
            grpBox_Output.Enabled = true;
            txtbox_Output.Enabled = true;

            numUpDown_height.Enabled = false;
            numUpDown_width.Enabled = false;
            btn_SetGrid.Enabled = false;

            btn_Go.Enabled = true;
            btn_Reset.Enabled = true;
            btn_Clear.Enabled = true;

            myGrid.VerticalCells = (int)numUpDown_height.Value;
            myGrid.HorizontalCells = (int)numUpDown_width.Value;

            for (int i = 0; i <= myGrid.HorizontalCells; i++)
            {
                cbx_robot1_x.Items.Add((i).ToString());
                cbx_robot2_x.Items.Add((i).ToString());
            }

            for (int i = 0; i <= myGrid.VerticalCells; i++)
            {
                cbx_robot1_y.Items.Add((i).ToString());
                cbx_robot2_y.Items.Add((i).ToString());
            }

            cbx_robot1_x.SelectedIndex = 0;
            cbx_robot1_y.SelectedIndex = 0;
            cbx_robot1_orientation.SelectedIndex = 0;

            cbx_robot2_x.SelectedIndex = myGrid.HorizontalCells;
            cbx_robot2_y.SelectedIndex = myGrid.VerticalCells;
            cbx_robot2_orientation.SelectedIndex = 0;

        }

        private void txtbox_robot1_move_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^L^M^R^l^m^r^\b]"))
            {
                e.Handled = true;
            }
        }
        private void txtbox_robot2_move_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^L^M^R^l^m^r^\b]"))
            {
                e.Handled = true;
            }
        }
      
        private void txtbox_robot1_move_TextChanged(object sender, EventArgs e)
        {
            txtbox_robot1_move.CharacterCasing = CharacterCasing.Upper;
        }
        private void txtbox_robot2_move_TextChanged(object sender, EventArgs e)
        {
            txtbox_robot2_move.CharacterCasing = CharacterCasing.Upper;
        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
            string curPosition;
            string newPosition;

            txtbox_Output.AppendText("New Position: " + Environment.NewLine);

            robot = new Robot(Int32.Parse(cbx_robot1_x.Text), Int32.Parse(cbx_robot1_y.Text), cbx_robot1_orientation.Text, origin_x, origin_y, myGrid.HorizontalCells, myGrid.VerticalCells);
            curPosition = cbx_robot1_x.Text + " " + cbx_robot1_y.Text + " " + cbx_robot1_orientation.Text;
            newPosition = robot.calculatePosition(txtbox_robot1_move.Text);

            txtbox_Output.AppendText("Robot 1 : " + newPosition + Environment.NewLine);

            robot = new Robot(Int32.Parse(cbx_robot2_x.Text), Int32.Parse(cbx_robot2_y.Text), cbx_robot2_orientation.Text, origin_x, origin_y, myGrid.HorizontalCells, myGrid.VerticalCells);
            curPosition = cbx_robot2_x.Text + " " + cbx_robot2_y.Text + " " + cbx_robot2_orientation.Text;
            newPosition = robot.calculatePosition(txtbox_robot2_move.Text);

            txtbox_Output.AppendText("Robot 2 : " + newPosition + Environment.NewLine + Environment.NewLine);

        }
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            grpBox_Robot1.Enabled = false;
            grpBox_Robot2.Enabled = false;
            grpBox_Output.Enabled = false;
            txtbox_Output.Enabled = false;

            numUpDown_height.Enabled = true;
            numUpDown_width.Enabled = true;
            btn_SetGrid.Enabled = true;

            btn_Go.Enabled = false;
            btn_Reset.Enabled = false;
            btn_Clear.Enabled = false;

            cbx_robot1_x.Items.Clear();
            cbx_robot2_x.Items.Clear();

            cbx_robot1_y.Items.Clear();
            cbx_robot2_y.Items.Clear();

            cbx_robot1_orientation.SelectedIndex = -1;
            cbx_robot2_orientation.SelectedIndex = -1;

            txtbox_robot1_move.Clear();
            txtbox_robot2_move.Clear();

            txtbox_Output.Clear();
        }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            cbx_robot1_x.SelectedIndex = 0;
            cbx_robot1_y.SelectedIndex = 0;
            cbx_robot1_orientation.SelectedIndex = 0;

            cbx_robot2_x.SelectedIndex = myGrid.HorizontalCells;
            cbx_robot2_y.SelectedIndex = myGrid.VerticalCells;
            cbx_robot2_orientation.SelectedIndex = 0;

            txtbox_robot1_move.Clear();
            txtbox_robot2_move.Clear();

            txtbox_Output.Clear();
        }

      

    }
}
