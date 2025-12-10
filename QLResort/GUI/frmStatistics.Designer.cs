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

            // Filter Panel
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.pnlFilter.BackColor = Color.FromArgb(236, 240, 241);
            this.pnlFilter.Dock = DockStyle.Top;
            this.pnlFilter.Height = 50;
            this.pnlFilter.Padding = new Padding(10);

            this.lblFilter = new System.Windows.Forms.Label();
            this.lblFilter.Text = "Lọc theo:";
            this.lblFilter.Font = new Font("Cambria", 10, FontStyle.Bold);
            this.lblFilter.Location = new Point(10, 15);
            this.lblFilter.AutoSize = true;

            this.cbFilterResort = new System.Windows.Forms.ComboBox();
            this.cbFilterResort.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbFilterResort.Location = new Point(90, 12);
            this.cbFilterResort.Size = new Size(200, 21);
            this.cbFilterResort.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);

            this.cbFilterMonth = new System.Windows.Forms.ComboBox();
            this.cbFilterMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbFilterMonth.Location = new Point(300, 12);
            this.cbFilterMonth.Size = new Size(150, 21);
            this.cbFilterMonth.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);

            this.cbFilterYear = new System.Windows.Forms.ComboBox();
            this.cbFilterYear.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbFilterYear.Location = new Point(460, 12);
            this.cbFilterYear.Size = new Size(150, 21);
            this.cbFilterYear.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);

            this.pnlFilter.Controls.AddRange(new Control[] {
                this.lblFilter, this.cbFilterResort, this.cbFilterMonth, this.cbFilterYear
            });

            // Stats Panel với scroll
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlStats.AutoScroll = true;
            this.pnlStats.Dock = DockStyle.Fill;
            this.pnlStats.Padding = new Padding(20);
            this.pnlStats.BackColor = Color.FromArgb(245, 247, 250);

            // ========== Khởi tạo tất cả value labels ==========
            this.lblTongPhongValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(52, 152, 219), AutoSize = true };
            this.lblPhongTrongValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(46, 204, 113), AutoSize = true };
            this.lblPhongDangSuDungValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(231, 76, 60), AutoSize = true };
            this.lblPhongBaoTriValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(241, 196, 15), AutoSize = true };
            this.lblPhongNgungValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(149, 165, 166), AutoSize = true };
            this.lblDoanhThuValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(155, 89, 182), AutoSize = true };
            this.lblChiPhiValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(231, 76, 60), AutoSize = true };
            this.lBUSoiNhuanValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(46, 204, 113), AutoSize = true };
            this.lblDatCocValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(52, 152, 219), AutoSize = true };
            this.lblHoanTienValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(241, 196, 15), AutoSize = true };
            this.lblTongDatPhongValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(52, 73, 94), AutoSize = true };
            this.lblDatPhongThanhCongValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(46, 204, 113), AutoSize = true };
            this.lblDatPhongHuyValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(231, 76, 60), AutoSize = true };
            this.lblTiLeThanhCong = new Label { Text = "0%", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(155, 89, 182), AutoSize = true };
            this.lblTongSuKienValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(52, 152, 219), AutoSize = true };
            this.lblDoanhThuSuKienValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(155, 89, 182), AutoSize = true };
            this.lblTongKhachHangValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(52, 73, 94), AutoSize = true };
            this.lblKhachHangMoiValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(46, 204, 113), AutoSize = true };
            this.lblTongNhanVienValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(52, 152, 219), AutoSize = true };
            this.lblTongDichVuValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(52, 73, 94), AutoSize = true };
            this.lblDoanhThuDichVuValue = new Label { Text = "0", Font = new Font("Cambria", 18, FontStyle.Bold), ForeColor = Color.FromArgb(155, 89, 182), AutoSize = true };

            // ========== Tạo các Cards ==========
            int cardW = 240, cardH = 100, gap = 20;
            
            // Row 1: Phòng
            AddCard("🏠 Tổng số phòng", lblTongPhongValue, 20 + 0 * (cardW + gap), 20);
            AddCard("✅ Phòng trống", lblPhongTrongValue, 20 + 1 * (cardW + gap), 20);
            AddCard("🛏️ Phòng đang dùng", lblPhongDangSuDungValue, 20 + 2 * (cardW + gap), 20);
            AddCard("🔧 Phòng bảo trì", lblPhongBaoTriValue, 20 + 3 * (cardW + gap), 20);
            AddCard("⛔ Phòng ngưng", lblPhongNgungValue, 20 + 4 * (cardW + gap), 20);

            // Row 2: Tài chính
            AddCard("💰 Doanh thu", lblDoanhThuValue, 20 + 0 * (cardW + gap), 130);
            AddCard("💸 Chi phí", lblChiPhiValue, 20 + 1 * (cardW + gap), 130);
            AddCard("📈 Lợi nhuận", lBUSoiNhuanValue, 20 + 2 * (cardW + gap), 130);
            AddCard("💳 Đặt cọc", lblDatCocValue, 20 + 3 * (cardW + gap), 130);
            AddCard("🔄 Hoàn tiền", lblHoanTienValue, 20 + 4 * (cardW + gap), 130);

            // Row 3: Đặt phòng
            AddCard("📋 Tổng đặt phòng", lblTongDatPhongValue, 20 + 0 * (cardW + gap), 240);
            AddCard("✅ Hoàn tất", lblDatPhongThanhCongValue, 20 + 1 * (cardW + gap), 240);
            AddCard("❌ Đã hủy", lblDatPhongHuyValue, 20 + 2 * (cardW + gap), 240);
            AddCard("📊 Tỷ lệ thành công", lblTiLeThanhCong, 20 + 3 * (cardW + gap), 240);

            // Row 4: Sự kiện
            AddCard("🎉 Tổng sự kiện", lblTongSuKienValue, 20 + 0 * (cardW + gap), 350);
            AddCard("💰 DT sự kiện", lblDoanhThuSuKienValue, 20 + 1 * (cardW + gap), 350);

            // Row 5: Khách hàng & Nhân viên
            AddCard("👥 Tổng khách hàng", lblTongKhachHangValue, 20 + 0 * (cardW + gap), 460);
            AddCard("🆕 KH mới", lblKhachHangMoiValue, 20 + 1 * (cardW + gap), 460);
            AddCard("👔 Tổng nhân viên", lblTongNhanVienValue, 20 + 2 * (cardW + gap), 460);

            // Row 6: Dịch vụ
            AddCard("🛎️ Tổng dịch vụ", lblTongDichVuValue, 20 + 0 * (cardW + gap), 570);
            AddCard("💰 DT dịch vụ", lblDoanhThuDichVuValue, 20 + 1 * (cardW + gap), 570);

            // Form setup
            this.Text = "Thống Kê Resort";
            this.Size = new Size(1400, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmStatistics_Load);

            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlFilter);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void AddCard(string title, Label valueLabel, int x, int y)
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

            valueLabel.Location = new Point(15, 45);
            card.Controls.Add(valueLabel);

            this.pnlStats.Controls.Add(card);
        }
    }
}
