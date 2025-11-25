using System.ComponentModel;

namespace HotelManagementIt008.UserControls
{
    public partial class StatCardControl : UserControl
    {
        public StatCardControl()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue("")]
        public string TitleText
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue("")]
        public string ValueText
        {
            get => lblValue.Text;
            set => lblValue.Text = value;
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue("")]
        public Color AccentColor
        {
            get => lblValue.ForeColor;
            set => lblValue.ForeColor = value;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
    }
}
