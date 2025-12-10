using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace QLResort.GUI.Styles
{
    public static class AppTheme
    {
        // 🎨 Màu chủ đạo
        public static readonly Color PrimaryColor = Color.FromArgb(26, 32, 47);
        public static readonly Color AccentColor = Color.FromArgb(255, 215, 0);
        public static readonly Color SuccessColor = Color.FromArgb(46, 204, 113);
        public static readonly Color DangerColor = Color.FromArgb(231, 76, 60);
        public static readonly Color InfoColor = Color.FromArgb(52, 152, 219);
        public static readonly Color BackgroundColor = Color.FromArgb(245, 247, 250);
        public static readonly Color BorderColor = Color.FromArgb(210, 210, 210);

        public static readonly Font DefaultFont = new Font("Cambria", 10, FontStyle.Regular);

        // Áp dụng theme cho cả form
        public static void ApplyForm(Form form)
        {
            form.BackColor = BackgroundColor;
            form.Font = DefaultFont;
        }

        public static void StylePanel(Panel panel, bool dark = false)
        {
            panel.BackColor = dark ? PrimaryColor : Color.White;
        }

        public static void StyleGroupBox(GroupBox group)
        {
            group.ForeColor = PrimaryColor;
            group.Font = new Font("Cambria", 10, FontStyle.Bold);
        }

        public static void StyleLabel(Label label)
        {
            label.Font = new Font("Cambria", 10, FontStyle.Regular);
            label.ForeColor = PrimaryColor;
        }

        public static void StyleHeaderLabel(Label label)
        {
            label.ForeColor = AccentColor;
            label.Font = new Font("Cambria", 18, FontStyle.Bold);
        }

        public static void StyleTextBox(TextBox text)
        {
            text.BorderStyle = BorderStyle.FixedSingle;
            text.BackColor = Color.White;
            text.ForeColor = PrimaryColor;
            text.Font = DefaultFont;
        }

        public static void StyleComboBox(ComboBox combo)
        {
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.BackColor = Color.White;
            combo.ForeColor = PrimaryColor;
            combo.FlatStyle = FlatStyle.Flat;
            combo.Font = DefaultFont;
        }

        public static void StyleNumericUpDown(NumericUpDown num)
        {
            num.BorderStyle = BorderStyle.FixedSingle;
            num.BackColor = Color.White;
            num.ForeColor = PrimaryColor;
            num.Font = DefaultFont;
        }

        public static void StyleDateTimePicker(DateTimePicker picker)
        {
            picker.CalendarMonthBackground = Color.White;
            picker.Font = DefaultFont;
            picker.CalendarTitleForeColor = PrimaryColor;
        }

        public static void StylePrimaryButton(Button btn)
        {
            SetupButton(btn, PrimaryColor, Color.White);
        }

        public static void StyleSecondaryButton(Button btn)
        {
            SetupButton(btn, AccentColor, PrimaryColor);
        }

        public static void StyleDangerButton(Button btn)
        {
            SetupButton(btn, DangerColor, Color.White);
        }

        private static void SetupButton(Button btn, Color back, Color fore)
        {
            btn.BackColor = back;
            btn.ForeColor = fore;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Cambria", 10, FontStyle.Bold);
            btn.Region = Rounded(btn.Width, btn.Height, 8); 
        }

        private static Region Rounded(int w, int h, int r)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, r, r, 180, 90);
            path.AddArc(w - r, 0, r, r, 270, 90);
            path.AddArc(w - r, h - r, r, r, 0, 90);
            path.AddArc(0, h - r, r, r, 90, 90);
            path.CloseAllFigures();
            return new Region(path);
        }

        public static void StyleDataGridView(DataGridView grid)
        {
            if (grid == null) return;
            grid.BackgroundColor = Color.White;
            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 10, FontStyle.Bold);

            grid.DefaultCellStyle.ForeColor = PrimaryColor;
            grid.DefaultCellStyle.SelectionBackColor = AccentColor;
            grid.DefaultCellStyle.SelectionForeColor = PrimaryColor;
            grid.GridColor = BorderColor;
        }

        public static void StyleListView(ListView list)
        {
            list.BackColor = Color.White;
            list.ForeColor = PrimaryColor;
            list.Font = DefaultFont;
            list.FullRowSelect = true;
            list.GridLines = true;
        }
    }
}
