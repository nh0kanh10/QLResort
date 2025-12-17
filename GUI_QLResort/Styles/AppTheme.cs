using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GUI_QLResort.Styles
{
    public static class AppTheme
    {
        // 🎨 Màu chủ đạo
        // 🎨 Màu chủ đạo
        // Vàng Kim Hoàng Gia (#C49A46)
        public static readonly Color AccentColor = Color.FromArgb(196, 154, 70); 
        
        // Xanh Navy Đậm (#122446)
        public static readonly Color PrimaryColor = Color.FromArgb(18, 36, 70); 
        
        // Trắng Kem / Ngà (#F8F4E3)
        public static readonly Color BackgroundColor = Color.FromArgb(248, 244, 227); 
        
        // Xanh Đen Đậm (#0F1C30) - Dùng cho Text
        public static readonly Color TextColor = Color.FromArgb(15, 28, 48);

        public static readonly Color SuccessColor = Color.FromArgb(46, 204, 113);
        public static readonly Color DangerColor = Color.FromArgb(231, 76, 60);
        public static readonly Color InfoColor = Color.FromArgb(52, 152, 219);
        public static readonly Color BorderColor = Color.FromArgb(210, 210, 210);

        // 🖋 Font chữ chủ đạo: Palatino Linotype (Sang trọng, cổ điển)
        public static readonly string ThemeFont = "Palatino Linotype"; 
        
        public static readonly Font DefaultFont = new Font(ThemeFont, 11, FontStyle.Regular); 

        // Áp dụng theme cho cả form
        public static void ApplyForm(Form form)
        {
            form.BackColor = BackgroundColor;
            form.Font = DefaultFont;
            ApplyTo(form);
        }

        public static void ApplyTo(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn)
                {
                    // Default to Primary for now, or check Tag/Name if needed
                    // For now apply Primary style as requested "all buttons like this"
                    StylePrimaryButton(btn); 
                }
                else if (c is TextBox txt) StyleTextBox(txt);
                else if (c is ComboBox cmb) StyleComboBox(cmb);
                else if (c is DataGridView dgv) StyleDataGridView(dgv);
                else if (c is NumericUpDown nud) StyleNumericUpDown(nud);
                else if (c is DateTimePicker dtp) StyleDateTimePicker(dtp);
                else if (c is Panel pnl) 
                {
                     StylePanel(pnl);
                     ApplyTo(pnl); // Recurse
                }
                else if (c is GroupBox gb)
                {
                     StyleGroupBox(gb);
                     ApplyTo(gb); // Recurse
                }
                else if (c is TabControl tc)
                {
                     ApplyTo(tc);
                }
                else if (c is TabPage tp)
                {
                     tp.BackColor = BackgroundColor;
                     ApplyTo(tp);
                }
                else if (c.HasChildren)
                {
                    ApplyTo(c);
                }
            }
        }

        public static void StylePanel(Panel panel, bool dark = false)
        {
            panel.BackColor = dark ? PrimaryColor : BackgroundColor;
        }

        public static void StyleGroupBox(GroupBox group)
        {
            group.ForeColor = TextColor;
            group.Font = new Font(ThemeFont, 11, FontStyle.Bold);
        }

        public static void StyleLabel(Label label)
        {
            label.Font = new Font(ThemeFont, 11, FontStyle.Regular);
            label.ForeColor = TextColor;
        }

        public static void StyleHeaderLabel(Label label)
        {
            label.ForeColor = AccentColor;
            label.Font = new Font(ThemeFont, 20, FontStyle.Bold); // Hơi to hơn chút cho tiêu đề
        }

        public static void StyleTextBox(TextBox text)
        {
            text.BorderStyle = BorderStyle.FixedSingle;
            text.BackColor = Color.White;
            text.ForeColor = TextColor;
            text.Font = DefaultFont;
        }

        public static void StyleComboBox(ComboBox combo)
        {
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.BackColor = Color.White;
            combo.ForeColor = TextColor;
            combo.FlatStyle = FlatStyle.Flat;
            combo.Font = DefaultFont;
        }

        public static void StyleNumericUpDown(NumericUpDown num)
        {
            num.BorderStyle = BorderStyle.FixedSingle;
            num.BackColor = Color.White;
            num.ForeColor = TextColor;
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
            SetupButton(btn, PrimaryColor, AccentColor);
            btn.Text = btn.Text.ToUpper(); // Enforce uppercase for style
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
            btn.Font = new Font(ThemeFont, 10, FontStyle.Bold);
            btn.Text = btn.Text.ToUpper();
        }

        public static void StyleDataGridView(DataGridView grid)
        {
            if (grid == null) return;
            grid.BackgroundColor = Color.White;
            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font(ThemeFont, 10, FontStyle.Bold);

            grid.DefaultCellStyle.ForeColor = PrimaryColor;
            grid.DefaultCellStyle.SelectionBackColor = AccentColor;
            grid.DefaultCellStyle.SelectionForeColor = PrimaryColor;
            grid.GridColor = BorderColor;
            grid.Font = DefaultFont;
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
