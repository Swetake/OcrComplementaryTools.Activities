using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OcrComplementaryTools
{
    public class ReviewDialog : CodeActivity
    {
        [Category("Input")]
        [Description("Image for review.")]
        [RequiredArgument]
        public InArgument<Image> InputImage { get; set; }

        [Category("Input")]
        [Description("Text for review.")]
        public InArgument<String> InputText { get; set; }

        [Category("Input")]
        [Description("Candidate List.")]
        public InArgument<List<String>> CandidateStringList { get; set; }



        [Category("Dialog")]
        [Description("[Optional] Image/Text Frame Width")]
        public InArgument<Int32> FrameWidth  { get; set; }

        [Category("Dialog")]
        [Description("[Optional] Image Frame Height")]
        public InArgument<Int32> ImageFrameHeight { get; set; }


        [Category("Dialog")]
        [Description("[Optional] Text Frame Height")]
        public InArgument<Int32> TextFrameHeight { get; set; }

        [Category("Dialog")]
        [Description("[Optional] Font Size")]
        public InArgument<Int32> FontSize { get; set; }

        [Category("Dialog")]
        [Description("Disable to submit when press enter key")]
        public InArgument<bool> DisableEnterKeySubmit { get; set; }



        [Category("Output")]
        [Description("Reviewed Text")]
        [RequiredArgument]
        public OutArgument<string> ReviewedText { get; set; }

        [Category("Output")]
        [Description("IsModified")]
        public OutArgument<bool>IsModified  { get; set; }

        [Category("Output")]
        [Description("IsUnreadable")]
        public OutArgument<bool> IsUnreadable { get; set; }


        protected internal Image ImgReview { get; set; }

        protected internal string StrText { get; set; }

        protected internal List<string> ListStrCandidate { get; set; }

        protected internal Boolean IsUnRead { get; set; }

        protected internal Boolean IsModify { get; set; }

        protected internal Boolean IsDisableEnterKeySubmit { get; set; }
        protected internal Int32 IntFrameWidth  { get; set; }
        protected internal Int32 IntImageFrameHeight { get; set; }
        protected internal Int32 IntTextFrameHeight { get; set; }
        protected internal Int32 IntFontSize { get; set; }


        protected override void Execute(CodeActivityContext context)
        {

            this.ImgReview = InputImage.Get(context);
            this.StrText = InputText.Get(context);
            this.ListStrCandidate = CandidateStringList.Get(context);

            this.IntFrameWidth = FrameWidth.Get(context);
            this.IntImageFrameHeight = ImageFrameHeight.Get(context);
            this.IntTextFrameHeight = TextFrameHeight.Get(context);
            this.IntFontSize = FontSize.Get(context);
            this.IsDisableEnterKeySubmit = DisableEnterKeySubmit.Get(context);

            this.IsUnRead = false;
            this.IsModify = false;
            
            FormMain fm = new FormMain(this);
            fm.ShowDialog();

            IsModified.Set(context, this.IsModify);
            IsUnreadable.Set(context, this.IsUnRead);
            ReviewedText.Set(context, this.StrText);
        }
    }
}
