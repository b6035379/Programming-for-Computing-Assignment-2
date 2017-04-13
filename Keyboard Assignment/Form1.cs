﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Keyboard_Assignment
{
    public partial class Form_MainWindow : Form
    {
        // Flags changes made and thus file needs saving 
        bool booleanRequiresSaving = false;

        // The Path to the 'Dictionary'
        string strPresentFilePathName = "";

        // Timing Functionality
        bool boolFirstVisit = true;
        int intIntervalRequired = 500;

        // Global ListBox can be place on the Form instead of here. 
        ListBox lstGlobalListbox = new ListBox();
        int intMyListIndex = 0;

        // Buttons. Identifies which button is being selected be the user. 
        bool[] boolButtonPresssed = new bool[18];

        // Prediction.
        string Str_KeyStrokes;

        // Is the line from the list that has the highest useage
        int intPredictedIndex;
        int intNumberOfCharacters;
        int intPredictedLength;
        int intTimesClicked = 0;
        int Index = -1;

        string Mode;
        string MultiPress = "Multi-Press";
        string Prediction = "Prediction";


        public Form_MainWindow()
        {
            InitializeComponent();
        }

        private void ModeMultiPress()
        {
            txtStatus.Clear();
            Mode = MultiPress;
            txtStatus.Text = "Multi-Press";
        }

        private void ModePrediction()
        {
            txtStatus.Clear();
            Mode = Prediction;
            txtStatus.Text = "Prediction";
        }

        private void Reset() //Resets the Index number, times a button has been clicked, and disables the timer.
        {
            Index = 0;
            intTimesClicked = 0;
        }

        private void ButtonClicked()
        {
            timer1.Enabled = false;
            timer1.Enabled = true;
            intTimesClicked = intTimesClicked + 1;
            Index = -1 + intTimesClicked;
        }

        private void CycleThrough()
        {
            if (Index < 6)
            {
                ButtonClicked();
            }
            else
            {
                Reset();
                ButtonClicked();
            }
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            if (Mode == Prediction)
            {
                ModeMultiPress(); //Calls Multi-Press Class
            }
            else
            {
                ModePrediction(); //Calls Prediction Class
            }
        }

        private void Form_MainWindow_Load(object sender, EventArgs e)
        {
            ModeMultiPress();
            Reset();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //On tick (timer elapsed), enter the letter selected in the array
            timer1.Enabled = false;
            rtxtBuilder.Text = rtxtBuilder.Text + lst7.Items[Index].ToString();
            Reset();

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            CycleThrough();
        }
        

        private void txtNotepad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            txtNotepad.AppendText(Environment.NewLine);
        }

        private void btn000_Click(object sender, EventArgs e)
        {
            txtNotepad.AppendText(rtxtBuilder.Text + " ");
            Str_KeyStrokes = string.Empty;
            rtxtBuilder.Clear();
        }

        
    }
}
