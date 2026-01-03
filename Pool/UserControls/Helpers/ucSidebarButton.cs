using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace _8Pool.UserControls.Helpers
{
    public partial class ucSidebarButton : UserControl
    {
        public ucSidebarButton()
        {
            InitializeComponent();
        }

        private Guna2Button _btn;

        public string ButtonText
        {
            get => _btn.Text;
            set => _btn.Text = value;
        }

        public event EventHandler Clicked;

        private bool _isActive = false;

        public bool IsActive
        {
            get => _isActive;
            private set
            {
                _isActive = value;
                _btn.FillColor = value ? Color.FromArgb(40, 40, 45) : Color.Transparent;
            }
        }

        public ucSidebarButton(EventHandler clickHandler = null)
        {
            this.Width = 200;
            this.Height = 45;

            _btn = new Guna2Button
            {
                Size = this.Size,
                Location = new Point(0, 0),
                FillColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                TextAlign = HorizontalAlignment.Left,
                ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton,
                BorderRadius = 6,
                HoverState = { FillColor = Color.FromArgb(50, 50, 55) }
            };

            _btn.Click += (s, e) => Clicked?.Invoke(this, e);

            if (clickHandler != null)
                Clicked += clickHandler;

            this.Controls.Add(_btn);
        }

        public void SetActive(bool active)
        {
            IsActive = active;
        }
    }

}
