using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace _8Pool.UserControls.Helpers
{
    public partial class ucSidebar : UserControl
    {
        private FlowLayoutPanel _MenuPanel;
        private Guna2Panel _Indicator;
        private ucSidebarButton _activeButton;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private List<ucSidebarButton> _Items = new List<ucSidebarButton>();

        public List<ucSidebarButton> Items
        {
            get => _Items;
            set
            {
                _Items = value ?? new List<ucSidebarButton>();
                _RefreshMenu();
            }
        }

        public ucSidebar()
        {
            InitializeComponent();
            _BuildUI();
        }

        private void _BuildUI()
        {
            this.Dock = DockStyle.Left;
            this.Width = 240;
            this.BackColor = Color.FromArgb(28, 28, 30);

            _MenuPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(0, 10, 0, 10)
            };
            this.Controls.Add(_MenuPanel);

            _Indicator = new Guna2Panel
            {
                Size = new Size(5, 45),
                FillColor = Color.FromArgb(122, 122, 255),
                Visible = false
            };
            this.Controls.Add(_Indicator);
        }

        public void _RefreshMenu()
        {
            _MenuPanel.Controls.Clear();

            foreach (var btn in _Items)
            {
                btn.Clicked += (s, e) => SetActiveButton(btn);
                _MenuPanel.Controls.Add(btn);
            }
        }

        private void SetActiveButton(ucSidebarButton btn)
        {
            _activeButton?.SetActive(false);

            btn.SetActive(true);
            _activeButton = btn;

            _Indicator.Visible = true;
            _Indicator.Top = btn.Top + _MenuPanel.Top;
        }
    }
}
