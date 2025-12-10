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
        
        // Labels cho thống kê phòng
        private System.Windows.Forms.Label lblTongPhong;
        private System.Windows.Forms.Label lblTongPhongValue;
        private System.Windows.Forms.Label lblPhongTrong;
        private System.Windows.Forms.Label lblPhongTrongValue;
        private System.Windows.Forms.Label lblPhongDangSuDung;
        private System.Windows.Forms.Label lblPhongDangSuDungValue;
        private System.Windows.Forms.Label lblPhongBaoTri;
        private System.Windows.Forms.Label lblPhongBaoTriValue;
        private System.Windows.Forms.Label lblPhongNgung;
        private System.Windows.Forms.Label lblPhongNgungValue;
        
        // Labels cho thống kê tài chính
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.Label lblDoanhThuValue;
        private System.Windows.Forms.Label lblChiPhi;
        private System.Windows.Forms.Label lblChiPhiValue;
        private System.Windows.Forms.Label lblLoiNhuan;
        private System.Windows.Forms.Label lblLoiNhuanValue;
        private System.Windows.Forms.Label lblDatCoc;
        private System.Windows.Forms.Label lblDatCocValue;
        private System.Windows.Forms.Label lblHoanTien;
        private System.Windows.Forms.Label lblHoanTienValue;
        
        // Labels cho thống kê đặt phòng
        private System.Windows.Forms.Label lblTongDatPhong;
        private System.Windows.Forms.Label lblTongDatPhongValue;
        private System.Windows.Forms.Label lblDatPhongThanhCong;
        private System.Windows.Forms.Label lblDatPhongThanhCongValue;
        private System.Windows.Forms.Label lblDatPhongHuy;
        private System.Windows.Forms.Label lblDatPhongHuyValue;
        private System.Windows.Forms.Label lblTiLeThanhCong;
        
        // Labels cho thống kê sự kiện
        private System.Windows.Forms.Label lblTongSuKien;
        private System.Windows.Forms.Label lblTongSuKienValue;
        private System.Windows.Forms.Label lblDoanhThuSuKien;
        private System.Windows.Forms.Label lblDoanhThuSuKienValue;
        
        // Labels cho thống kê khách hàng & nhân viên
        private System.Windows.Forms.Label lblTongKhachHang;
        private System.Windows.Forms.Label lblTongKhachHangValue;
        private System.Windows.Forms.Label lblTongNhanVien;
        private System.Windows.Forms.Label lblTongNhanVienValue;
        private System.Windows.Forms.Label lblKhachHangMoi;
        private System.Windows.Forms.Label lblKhachHangMoiValue;
        
        // Labels cho thống kê dịch vụ
        private System.Windows.Forms.Label lblTongDichVu;
        private System.Windows.Forms.Label lblTongDichVuValue;
        private System.Windows.Forms.Label lblDoanhThuDichVu;
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

            // InitializeControls
            {
                // Filter Panel
                this.pnlFilter = new System.Windows.Forms.Panel();
                this.pnlFilter.BackColor = Color.FromArgb(236, 240, 241);
                this.pnlFilter.Dock = DockStyle.Top;
                this.pnlFilter.Height = 50;
                this.pnlFilter.Padding = new Padding(10);

                this.lblFilter = new System.Windows.Forms.Label();
                this.lblFilter.Text = "Lọc theo:";
                this.lblFilter.Font = new Font("Segoe UI", 10, FontStyle.Bold);
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

                // Tạo các labels với layout card-based - cải thiện UI với icon
                CreateStatCard("🏠 Tổng số phòng", ref lblTongPhong, ref lblTongPhongValue, 20, 20, Color.FromArgb(52, 152, 219));
                CreateStatCard("✅ Phòng trống", ref lblPhongTrong, ref lblPhongTrongValue, 280, 20, Color.FromArgb(46, 204, 113));
                CreateStatCard("🛏️ Phòng đang sử dụng", ref lblPhongDangSuDung, ref lblPhongDangSuDungValue, 540, 20, Color.FromArgb(231, 76, 60));
                CreateStatCard("🔧 Phòng bảo trì", ref lblPhongBaoTri, ref lblPhongBaoTriValue, 800, 20, Color.FromArgb(241, 196, 15));
                CreateStatCard("⛔ Phòng ngưng", ref lblPhongNgung, ref lblPhongNgungValue, 1060, 20, Color.FromArgb(149, 165, 166));

                CreateStatCard("💰 Doanh thu", ref lblDoanhThu, ref lblDoanhThuValue, 20, 120, Color.FromArgb(155, 89, 182));
                CreateStatCard("💸 Chi phí", ref lblChiPhi, ref lblChiPhiValue, 280, 120, Color.FromArgb(231, 76, 60));
                CreateStatCard("📈 Lợi nhuận", ref lblLoiNhuan, ref lblLoiNhuanValue, 540, 120, Color.FromArgb(46, 204, 113));
                CreateStatCard("💳 Đặt cọc", ref lblDatCoc, ref lblDatCocValue, 800, 120, Color.FromArgb(52, 152, 219));
                CreateStatCard("🔄 Hoàn tiền", ref lblHoanTien, ref lblHoanTienValue, 1060, 120, Color.FromArgb(241, 196, 15));

                CreateStatCard("📋 Tổng đặt phòng", ref lblTongDatPhong, ref lblTongDatPhongValue, 20, 220, Color.FromArgb(52, 73, 94));
                CreateStatCard("✅ Đặt thành công", ref lblDatPhongThanhCong, ref lblDatPhongThanhCongValue, 280, 220, Color.FromArgb(46, 204, 113));
                CreateStatCard("❌ Đặt hủy", ref lblDatPhongHuy, ref lblDatPhongHuyValue, 540, 220, Color.FromArgb(231, 76, 60));
                // Tỷ lệ thành công - tạo riêng
                Panel cardTiLe = new Panel();
                cardTiLe.BackColor = Color.White;
                cardTiLe.BorderStyle = BorderStyle.FixedSingle;
                cardTiLe.Location = new Point(800, 220);
                cardTiLe.Size = new Size(240, 90);
                cardTiLe.Padding = new Padding(10);
                this.lblTiLeThanhCong = new Label();
                this.lblTiLeThanhCong.Text = "Tỷ lệ thành công: 0%";
                this.lblTiLeThanhCong.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                this.lblTiLeThanhCong.ForeColor = Color.FromArgb(155, 89, 182);
                this.lblTiLeThanhCong.Location = new Point(10, 35);
                this.lblTiLeThanhCong.AutoSize = true;
                cardTiLe.Controls.Add(this.lblTiLeThanhCong);
                Label titleTiLe = new Label();
                titleTiLe.Text = "Tỷ lệ thành công:";
                titleTiLe.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                titleTiLe.ForeColor = Color.FromArgb(127, 140, 141);
                titleTiLe.Location = new Point(10, 10);
                titleTiLe.AutoSize = true;
                cardTiLe.Controls.Add(titleTiLe);
                this.pnlStats.Controls.Add(cardTiLe);

                CreateStatCard("🎉 Tổng sự kiện", ref lblTongSuKien, ref lblTongSuKienValue, 20, 320, Color.FromArgb(52, 152, 219));
                CreateStatCard("💰 Doanh thu sự kiện", ref lblDoanhThuSuKien, ref lblDoanhThuSuKienValue, 280, 320, Color.FromArgb(155, 89, 182));

                CreateStatCard("👥 Tổng khách hàng", ref lblTongKhachHang, ref lblTongKhachHangValue, 20, 420, Color.FromArgb(52, 73, 94));
                CreateStatCard("🆕 Khách hàng mới", ref lblKhachHangMoi, ref lblKhachHangMoiValue, 280, 420, Color.FromArgb(46, 204, 113));
                CreateStatCard("👔 Tổng nhân viên", ref lblTongNhanVien, ref lblTongNhanVienValue, 540, 420, Color.FromArgb(52, 152, 219));

                CreateStatCard("🛎️ Tổng dịch vụ", ref lblTongDichVu, ref lblTongDichVuValue, 20, 520, Color.FromArgb(52, 73, 94));
                CreateStatCard("💰 Doanh thu dịch vụ", ref lblDoanhThuDichVu, ref lblDoanhThuDichVuValue, 280, 520, Color.FromArgb(155, 89, 182));

                // SetupLayout
                this.Text = "Thống Kê Resort";
                this.Size = new Size(1400, 700);
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Load += new System.EventHandler(this.frmStatistics_Load);

                this.Controls.Add(this.pnlStats);
                this.Controls.Add(this.pnlFilter);

                this.ResumeLayout(false);
                this.PerformLayout();
            }
        }

        private void CreateStatCard(string title, ref Label lblTitle, ref Label lblValue, int x, int y, Color color)
        {
            Panel card = new Panel();
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Location = new Point(x, y);
            card.Size = new Size(240, 110); // Tăng chiều cao để đẹp hơn
            card.Padding = new Padding(15);
            // Thêm shadow effect
            card.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(200, 200, 200), 1), 
                    new Rectangle(0, 0, card.Width - 1, card.Height - 1));
            };

            Label titleLabel = new Label();
            titleLabel.Text = title;
            titleLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(52, 73, 94);
            titleLabel.Location = new Point(15, 15);
            titleLabel.AutoSize = true;
            card.Controls.Add(titleLabel);
            lblTitle = titleLabel;

            // Luôn tạo value label với format đẹp hơn
            Label valueLabel = new Label();
            valueLabel.Text = "0";
            valueLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            valueLabel.ForeColor = color;
            valueLabel.Location = new Point(15, 45);
            valueLabel.AutoSize = true;
            card.Controls.Add(valueLabel);
            lblValue = valueLabel;

            this.pnlStats.Controls.Add(card);
        }
    }
}
