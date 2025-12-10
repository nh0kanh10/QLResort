using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace QLResort.GUI
{
    partial class frmStatistics
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cbFilterResort;
        private System.Windows.Forms.ComboBox cbFilterMonth;
        private System.Windows.Forms.ComboBox cbFilterYear;
        private System.Windows.Forms.Panel pnlStats;
        
        // Labels cho giá trị thống kê
        private System.Windows.Forms.Label lblTongPhongValue;
        private System.Windows.Forms.Label lblPhongTrongValue;
        private System.Windows.Forms.Label lblPhongDangSuDungValue;
        private System.Windows.Forms.Label lblPhongBaoTriValue;
        private System.Windows.Forms.Label lblPhongNgungValue;
        private System.Windows.Forms.Label lblDoanhThuValue;
        private System.Windows.Forms.Label lblChiPhiValue;
        private System.Windows.Forms.Label lBUSoiNhuanValue;
        private System.Windows.Forms.Label lblDatCocValue;
        private System.Windows.Forms.Label lblHoanTienValue;
        private System.Windows.Forms.Label lblTongDatPhongValue;
        private System.Windows.Forms.Label lblDatPhongThanhCongValue;
        private System.Windows.Forms.Label lblDatPhongHuyValue;
        private System.Windows.Forms.Label lblTiLeThanhCong;
        private System.Windows.Forms.Label lblTongSuKienValue;
        private System.Windows.Forms.Label lblDoanhThuSuKienValue;
        private System.Windows.Forms.Label lblTongKhachHangValue;
        private System.Windows.Forms.Label lblTongNhanVienValue;
        private System.Windows.Forms.Label lblKhachHangMoiValue;
        private System.Windows.Forms.Label lblTongDichVuValue;
        private System.Windows.Forms.Label lblDoanhThuDichVuValue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            // ========== Filter Panel ==========
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cbFilterResort = new System.Windows.Forms.ComboBox();
            this.cbFilterMonth = new System.Windows.Forms.ComboBox();
            this.cbFilterYear = new System.Windows.Forms.ComboBox();

            this.pnlFilter.BackColor = Color.FromArgb(236, 240, 241);
            this.pnlFilter.Dock = DockStyle.Top;
            this.pnlFilter.Height = 50;
            this.pnlFilter.Padding = new Padding(10);

            this.lblFilter.Text = "Lọc theo:";
            this.lblFilter.Font = new Font("Cambria", 10, FontStyle.Bold);
            this.lblFilter.Location = new Point(10, 15);
            this.lblFilter.AutoSize = true;

            this.cbFilterResort.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbFilterResort.Location = new Point(90, 12);
            this.cbFilterResort.Size = new Size(200, 21);
            this.cbFilterResort.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);

            this.cbFilterMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbFilterMonth.Location = new Point(300, 12);
            this.cbFilterMonth.Size = new Size(150, 21);
            this.cbFilterMonth.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);

            this.cbFilterYear.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbFilterYear.Location = new Point(460, 12);
            this.cbFilterYear.Size = new Size(150, 21);
            this.cbFilterYear.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);

            this.pnlFilter.Controls.Add(this.lblFilter);
            this.pnlFilter.Controls.Add(this.cbFilterResort);
            this.pnlFilter.Controls.Add(this.cbFilterMonth);
            this.pnlFilter.Controls.Add(this.cbFilterYear);

            // ========== Stats Panel ==========
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlStats.AutoScroll = true;
            this.pnlStats.Dock = DockStyle.Fill;
            this.pnlStats.Padding = new Padding(20);
            this.pnlStats.BackColor = Color.FromArgb(245, 247, 250);

            // ========== Tạo các value labels ==========
            this.lblTongPhongValue = CreateValueLabel(Color.FromArgb(52, 152, 219));
            this.lblPhongTrongValue = CreateValueLabel(Color.FromArgb(46, 204, 113));
            this.lblPhongDangSuDungValue = CreateValueLabel(Color.FromArgb(231, 76, 60));
            this.lblPhongBaoTriValue = CreateValueLabel(Color.FromArgb(241, 196, 15));
            this.lblPhongNgungValue = CreateValueLabel(Color.FromArgb(149, 165, 166));
            this.lblDoanhThuValue = CreateValueLabel(Color.FromArgb(155, 89, 182));
            this.lblChiPhiValue = CreateValueLabel(Color.FromArgb(231, 76, 60));
            this.lBUSoiNhuanValue = CreateValueLabel(Color.FromArgb(46, 204, 113));
            this.lblDatCocValue = CreateValueLabel(Color.FromArgb(52, 152, 219));
            this.lblHoanTienValue = CreateValueLabel(Color.FromArgb(241, 196, 15));
            this.lblTongDatPhongValue = CreateValueLabel(Color.FromArgb(52, 73, 94));
            this.lblDatPhongThanhCongValue = CreateValueLabel(Color.FromArgb(46, 204, 113));
            this.lblDatPhongHuyValue = CreateValueLabel(Color.FromArgb(231, 76, 60));
            this.lblTiLeThanhCong = CreateValueLabel(Color.FromArgb(155, 89, 182));
            this.lblTongSuKienValue = CreateValueLabel(Color.FromArgb(52, 152, 219));
            this.lblDoanhThuSuKienValue = CreateValueLabel(Color.FromArgb(155, 89, 182));
            this.lblTongKhachHangValue = CreateValueLabel(Color.FromArgb(52, 73, 94));
            this.lblKhachHangMoiValue = CreateValueLabel(Color.FromArgb(46, 204, 113));
            this.lblTongNhanVienValue = CreateValueLabel(Color.FromArgb(52, 152, 219));
            this.lblTongDichVuValue = CreateValueLabel(Color.FromArgb(52, 73, 94));
            this.lblDoanhThuDichVuValue = CreateValueLabel(Color.FromArgb(155, 89, 182));

            // ========== Tạo các Cards ==========
            int cardW = 240, cardH = 100, gap = 20;
            
            // Row 1: Phòng
            this.pnlStats.Controls.Add(CreateCard("🏠 Tổng số phòng", this.lblTongPhongValue, 20 + 0 * (cardW + gap), 20));
            this.pnlStats.Controls.Add(CreateCard("✅ Phòng trống", this.lblPhongTrongValue, 20 + 1 * (cardW + gap), 20));
            this.pnlStats.Controls.Add(CreateCard("🛏️ Phòng đang dùng", this.lblPhongDangSuDungValue, 20 + 2 * (cardW + gap), 20));
            this.pnlStats.Controls.Add(CreateCard("🔧 Phòng bảo trì", this.lblPhongBaoTriValue, 20 + 3 * (cardW + gap), 20));
            this.pnlStats.Controls.Add(CreateCard("⛔ Phòng ngưng", this.lblPhongNgungValue, 20 + 4 * (cardW + gap), 20));

            // Row 2: Tài chính
            this.pnlStats.Controls.Add(CreateCard("💰 Doanh thu", this.lblDoanhThuValue, 20 + 0 * (cardW + gap), 130));
            this.pnlStats.Controls.Add(CreateCard("💸 Chi phí", this.lblChiPhiValue, 20 + 1 * (cardW + gap), 130));
            this.pnlStats.Controls.Add(CreateCard("📈 Lợi nhuận", this.lBUSoiNhuanValue, 20 + 2 * (cardW + gap), 130));
            this.pnlStats.Controls.Add(CreateCard("💳 Đặt cọc", this.lblDatCocValue, 20 + 3 * (cardW + gap), 130));
            this.pnlStats.Controls.Add(CreateCard("🔄 Hoàn tiền", this.lblHoanTienValue, 20 + 4 * (cardW + gap), 130));

            // Row 3: Đặt phòng
            this.pnlStats.Controls.Add(CreateCard("📋 Tổng đặt phòng", this.lblTongDatPhongValue, 20 + 0 * (cardW + gap), 240));
            this.pnlStats.Controls.Add(CreateCard("✅ Hoàn tất", this.lblDatPhongThanhCongValue, 20 + 1 * (cardW + gap), 240));
            this.pnlStats.Controls.Add(CreateCard("❌ Đã hủy", this.lblDatPhongHuyValue, 20 + 2 * (cardW + gap), 240));
            this.pnlStats.Controls.Add(CreateCard("📊 Tỷ lệ thành công", this.lblTiLeThanhCong, 20 + 3 * (cardW + gap), 240));

            // Row 4: Sự kiện
            this.pnlStats.Controls.Add(CreateCard("🎉 Tổng sự kiện", this.lblTongSuKienValue, 20 + 0 * (cardW + gap), 350));
            this.pnlStats.Controls.Add(CreateCard("💰 DT sự kiện", this.lblDoanhThuSuKienValue, 20 + 1 * (cardW + gap), 350));

            // Row 5: Khách hàng & Nhân viên
            this.pnlStats.Controls.Add(CreateCard("👥 Tổng khách hàng", this.lblTongKhachHangValue, 20 + 0 * (cardW + gap), 460));
            this.pnlStats.Controls.Add(CreateCard("🆕 KH mới", this.lblKhachHangMoiValue, 20 + 1 * (cardW + gap), 460));
            this.pnlStats.Controls.Add(CreateCard("👔 Tổng nhân viên", this.lblTongNhanVienValue, 20 + 2 * (cardW + gap), 460));

            // Row 6: Dịch vụ
            this.pnlStats.Controls.Add(CreateCard("🛎️ Tổng dịch vụ", this.lblTongDichVuValue, 20 + 0 * (cardW + gap), 570));
            this.pnlStats.Controls.Add(CreateCard("💰 DT dịch vụ", this.lblDoanhThuDichVuValue, 20 + 1 * (cardW + gap), 570));

            // ========== Form setup ==========
            this.Text = "Thống Kê Resort";
            this.Size = new Size(1400, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmStatistics_Load);

            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlFilter);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label CreateValueLabel(Color color)
        {
            return new Label 
            { 
                Text = "0", 
                Font = new Font("Cambria", 18, FontStyle.Bold), 
                ForeColor = color, 
                AutoSize = true,
                Location = new Point(15, 45)
            };
        }

        private Panel CreateCard(string title, Label valueLabel, int x, int y)
        {
            Panel card = new Panel();
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Location = new Point(x, y);
            card.Size = new Size(240, 100);

            Label titleLabel = new Label();
            titleLabel.Text = title;
            titleLabel.Font = new Font("Cambria", 10, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(52, 73, 94);
            titleLabel.Location = new Point(15, 15);
            titleLabel.AutoSize = true;
            card.Controls.Add(titleLabel);
            card.Controls.Add(valueLabel);

            return card;
        }
    }
}
