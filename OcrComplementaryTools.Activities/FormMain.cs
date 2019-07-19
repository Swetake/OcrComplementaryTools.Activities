using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OcrComplementaryTools
{
    public partial class FormMain : Form
    {
        const int INT_FORM_WIDTH_MERGIN = 20;
        const int INT_FORM_HEIGHT_TOP_MERGIN = 20;
        const int INT_FORM_HEIGHT_CENTER_MERGIN = 20;
        const int INT_FORM_HEIGHT_MIDDLE_MERGIN = 10;
        const int INT_FORM_HEIGHT_BOTTOM_MERGIN = 48;
        const int INT_FORM_BUTTON_HEIGHT = 32;

        const int INT_DEFAULT_FRAME_WIDTH = 640;
        const int INT_DEFAULT_IMAGE_FRAME_HEIGHT = 228;
        const int INT_DEFAULT_TEXT_FRAME_HEIGHT = 128;

        Image imgInput;
        string strIniitalText = "";
        List<string> listStrCandidate;
        ReviewDialog reviewDialog;
        bool isComboBoxMode;
        bool isDisableEnterKeySubmit;

        public FormMain(ReviewDialog rd)
        {
            InitializeComponent();
            reviewDialog = rd;
            imgInput = reviewDialog.ImgReview;
            listStrCandidate = reviewDialog.ListStrCandidate;
            isDisableEnterKeySubmit = reviewDialog.IsDisableEnterKeySubmit;

            Size sizeForm = this.Size;
            Size sizeImageFrame = this.pictureBoxReviewImage.Size;
            Size sizeTextFrame = this.textBoxText.Size;

            if (reviewDialog.IntFrameWidth <=0)
            {
                reviewDialog.IntFrameWidth = INT_DEFAULT_FRAME_WIDTH;
            }
            sizeForm.Width = reviewDialog.IntFrameWidth + INT_FORM_WIDTH_MERGIN * 2;
            sizeImageFrame.Width = reviewDialog.IntFrameWidth;
            sizeTextFrame.Width = reviewDialog.IntFrameWidth;


            if (reviewDialog.IntImageFrameHeight <=0)
            {
                reviewDialog.IntImageFrameHeight = INT_DEFAULT_IMAGE_FRAME_HEIGHT;
            }
            sizeImageFrame.Height = reviewDialog.IntImageFrameHeight;


            if (reviewDialog.IntTextFrameHeight <= 0)
            {
                reviewDialog.IntTextFrameHeight = INT_DEFAULT_TEXT_FRAME_HEIGHT;
            }
            sizeTextFrame.Height = reviewDialog.IntTextFrameHeight;
            

            int intTextboxLocationY = sizeImageFrame.Height + INT_FORM_HEIGHT_TOP_MERGIN + INT_FORM_HEIGHT_CENTER_MERGIN;
            int intButtonLocationY = intTextboxLocationY + sizeTextFrame.Height+INT_FORM_HEIGHT_MIDDLE_MERGIN;

            sizeForm.Width = reviewDialog.IntFrameWidth + INT_FORM_WIDTH_MERGIN * 2;
            sizeForm.Height = intButtonLocationY + INT_FORM_BUTTON_HEIGHT + INT_FORM_HEIGHT_BOTTOM_MERGIN;

            this.Size = sizeForm;



            pictureBoxReviewImage.Size = sizeImageFrame;
            buttonGo.Location = new Point(buttonGo.Location.X, intButtonLocationY);
            buttonClear.Location = new Point(buttonClear.Location.X, intButtonLocationY);
            buttonUnreadable.Location = new Point(buttonUnreadable.Location.X, intButtonLocationY);
            buttonRestore.Location = new Point(buttonRestore.Location.X, intButtonLocationY);

            if (listStrCandidate == null)
            { isComboBoxMode = false; }
            else
            {
                if (listStrCandidate.Count == 0)
                {
                    isComboBoxMode = false;
                }
                else
                {
                    isComboBoxMode = true;
                }
            }


            if(isComboBoxMode){

                comboBoxForCandidate.Size = sizeTextFrame;
                comboBoxForCandidate.Location =new Point(comboBoxForCandidate.Location.X, intTextboxLocationY);


                foreach(string strItem in listStrCandidate)
                {
                    comboBoxForCandidate.Items.Add(strItem);
                }


                if (string.IsNullOrEmpty(reviewDialog.StrText))
                {
                    strIniitalText = listStrCandidate[0];
                    
                }
                else
                {
                    strIniitalText = reviewDialog.StrText;
                }

                comboBoxForCandidate.Visible = true;
                textBoxText.Visible = false;
                comboBoxForCandidate.SelectedIndex = 0;
                comboBoxForCandidate.Focus();
                comboBoxForCandidate.Text = strIniitalText;
                this.ActiveControl = this.comboBoxForCandidate;
            }
            else
            {
                textBoxText.Size = sizeTextFrame;
                textBoxText.Location = new Point(textBoxText.Location.X, intTextboxLocationY);
                comboBoxForCandidate.Visible = false;
                textBoxText.Visible = true;
                textBoxText.Text = reviewDialog.StrText;
                strIniitalText = reviewDialog.StrText;
            }
            pictureBoxReviewImage.Image = imgInput;
            
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxText.Text = "";
            comboBoxForCandidate.Text = "";
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (isComboBoxMode)
            {
                reviewDialog.StrText = comboBoxForCandidate.Text;
                if (comboBoxForCandidate.Text.Equals(strIniitalText))
                {
                    reviewDialog.IsModify = false;
                }
                else
                {
                    reviewDialog.IsModify = true;
                }
            }
            else
            {
                reviewDialog.StrText = textBoxText.Text;
                if (textBoxText.Text.Equals(strIniitalText))
                {
                    reviewDialog.IsModify = false;
                }
                else
                {
                    reviewDialog.IsModify = true;
                }
            }
            this.Close();
        }

        private void buttonUnreadble_Click(object sender, EventArgs e)
        {
            reviewDialog.IsUnRead = true;
            this.Close();
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            if (isComboBoxMode)
            {
                comboBoxForCandidate.Text = strIniitalText;
            }
            else
            {
                textBoxText.Text = strIniitalText;
            }
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            this.Activate();
            this.TopMost = true;
            this.TopMost = false;
        }


        private void comboBoxForCandidate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !isDisableEnterKeySubmit)
            {
                buttonGo.PerformClick();

            }
        }

        private void textBoxText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !isDisableEnterKeySubmit)
            {
                buttonGo.PerformClick();

            }
        }
    }
}
