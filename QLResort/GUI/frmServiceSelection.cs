using QLResort.BUS;
using QLResort.Core.Model;
using QLResort.GUI.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmServiceSelection : AppBaseForm
    {
        private readonly ServiceBUS _serviceBUS;
        private readonly ToolTip _tooltip = new ToolTip();
        private List<Service> _allServices;
        private List<ServiceUsage> _selectedServices;
        private string _guestMaKH;

        public List<ServiceUsage> SelectedServiceUsages => _selectedServices
            .Select(s => s.Clone())
            .ToList();

        public frmServiceSelection(string guestMaKH = null)
        {
            InitializeComponent();
            ApplyTheme();
            _serviceBUS = new ServiceBUS();
            _allServices = new List<Service>();
            _selectedServices = new List<ServiceUsage>();
            _guestMaKH = guestMaKH;
        }

        private void frmServiceSelection_Load(object sender, EventArgs e)
        {
            LoadServices();
            SetupEventHandlers();
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            AppTheme.StyleDataGridView(dgvAvailableServices);
            AppTheme.StyleDataGridView(dgvSelectedServices);
            AppTheme.StylePrimaryButton(btnSave);
            AppTheme.StyleDangerButton(btnClose);
        }

        private void SetupEventHandlers()
        {
            dgvAvailableServices.CellContentClick += DgvAvailableServices_CellContentClick;
            dgvAvailableServices.SelectionChanged += DgvAvailableServices_SelectionChanged;
            dgvAvailableServices.CellClick += DgvAvailableServices_CellClick;
            dgvSelectedServices.CellContentClick += DgvSelectedServices_CellContentClick;
            dgvSelectedServices.SelectionChanged += DgvSelectedServices_SelectionChanged;
            dgvSelectedServices.CellClick += DgvSelectedServices_CellClick;
            btnSave.Click += BtnSave_Click;
            btnClose.Click += BtnClose_Click;
            btnSearch.Click += BtnSearch_Click;
            txtSearchService.KeyDown += TxtSearchService_KeyDown;
            txtSearchService.TextChanged += TxtSearchService_TextChanged;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadServices(txtSearchService.Text.Trim());
        }

        private void TxtSearchService_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadServices(txtSearchService.Text.Trim());
            }
        }

        private void TxtSearchService_TextChanged(object sender, EventArgs e)
        {
            // Auto-search when user types (with a small delay to avoid too many searches)
            // For now, we'll search on Enter key or Search button click
            // If you want real-time search, you can uncomment the line below
            // LoadServices(txtSearchService.Text.Trim());
        }

        private void LoadServices(string searchText = "")
        {
            try
            {
                var result = _serviceBUS.GetServices(isActive: true);
                if (result.Success)
                {
                    _allServices = result.Data;

                    // Filter by search text if provided
                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        _allServices = _allServices.Where(s => 
                            s.TenDV.ToLower().Contains(searchText.ToLower()) ||
                            s.MaDV.ToLower().Contains(searchText.ToLower())
                        ).ToList();
                    }

                    RefreshAvailableServicesGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshAvailableServicesGrid()
        {
            dgvAvailableServices.Rows.Clear();

            foreach (var service in _allServices)
            {
                dgvAvailableServices.Rows.Add(
                    service.MaDV,
                    service.TenDV,
                    service.Gia?.ToString("N0") + " đ",
                    service.ChoPhepDoiDiem ? "Có" : "Không",
                    service.GiaTriDoiDiem ?? 0
                );
            }
        }

        private void RefreshSelectedServicesGrid()
        {
            dgvSelectedServices.Rows.Clear();

            for (int i = 0; i < _selectedServices.Count; i++)
            {
                var usage = _selectedServices[i];
                int rowIndex = dgvSelectedServices.Rows.Add(
                    usage.ServiceCode,
                    usage.ServiceName,
                    usage.Quantity,
                    usage.UnitPrice.ToString("N0") + " đ",
                    usage.Total.ToString("N0") + " đ"
                );
                dgvSelectedServices.Rows[rowIndex].Tag = usage;
            }

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = _selectedServices.Sum(s => s.Total);
            txtTotalAmount.Text = total.ToString("N0");
        }

        private void DgvAvailableServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != dgvAvailableServices.Columns["colAdd"].Index || e.RowIndex < 0)
                return;

            string maDV = dgvAvailableServices.Rows[e.RowIndex].Cells["colMaDVAvailable"].Value?.ToString();
            var service = _allServices.FirstOrDefault(s => s.MaDV == maDV);
            if (service == null) return;

            bool paidByPoint = false;
            decimal unitPrice = service.Gia ?? 0;

            if (service.ChoPhepDoiDiem && !string.IsNullOrEmpty(_guestMaKH))
            {
                var guestPointBUS = new GuestPointBUS();
                var pointResult = guestPointBUS.GetGuestPoint(_guestMaKH);

                if (pointResult.Success && pointResult.Data.DiemHienTai >= (service.GiaTriDoiDiem ?? 0))
                {
                    var dialogResult = MessageBox.Show(
                        $"Dịch vụ này có thể thanh toán bằng điểm.\n" +
                        $"Điểm hiện tại: {pointResult.Data.DiemHienTai}\n" +
                        $"Giá trị đổi điểm: {service.GiaTriDoiDiem}\n\n" +
                        $"Bạn có muốn thanh toán bằng điểm không?",
                        "Thanh toán bằng điểm",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        var deductResult = guestPointBUS.DeductPoints(
                            _guestMaKH,
                            service.GiaTriDoiDiem ?? 0,
                            $"Thanh toán dịch vụ {service.TenDV}"
                        );

                        if (!deductResult.Success)
                        {
                            MessageBox.Show($"Lỗi khi trừ điểm: {deductResult.ErrorMessage}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        MessageBox.Show("Đã thanh toán bằng điểm thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        paidByPoint = true;
                        unitPrice = 0;
                    }
                }
            }

            var existingUsage = _selectedServices.FirstOrDefault(s => s.ServiceCode == service.MaDV && s.PaidByPoint == paidByPoint);
            if (existingUsage != null)
            {
                existingUsage.Quantity++;
            }
            else
            {
                _selectedServices.Add(new ServiceUsage
                {
                    Service = service,
                    Quantity = 1,
                    UnitPrice = unitPrice,
                    PaidByPoint = paidByPoint
                });
            }

            RefreshAvailableServicesGrid();
            RefreshSelectedServicesGrid();
        }

        private void DgvSelectedServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSelectedServices.Columns["colRemove"].Index && e.RowIndex >= 0)
            {
                var usage = dgvSelectedServices.Rows[e.RowIndex].Tag as ServiceUsage;
                if (usage != null)
                {
                    _selectedServices.Remove(usage);
                    RefreshAvailableServicesGrid();
                    RefreshSelectedServicesGrid();
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DgvAvailableServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAvailableServices.SelectedRows.Count > 0)
            {
                var selectedRow = dgvAvailableServices.SelectedRows[0];
                string maDV = selectedRow.Cells["colMaDVAvailable"].Value?.ToString();
                
                if (!string.IsNullOrEmpty(maDV))
                {
                    var service = _allServices.FirstOrDefault(s => s.MaDV == maDV);
                    if (service != null)
                    {
                        // Service is selected, can show details if needed
                    }
                }
            }
        }

        private void DgvAvailableServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex != dgvAvailableServices.Columns["colAdd"].Index)
            {
                var selectedRow = dgvAvailableServices.Rows[e.RowIndex];
                string maDV = selectedRow.Cells["colMaDVAvailable"].Value?.ToString();
                
                if (!string.IsNullOrEmpty(maDV))
                {
                    var service = _allServices.FirstOrDefault(s => s.MaDV == maDV);
                    if (service != null)
                    {
                        // Display service details
                        string serviceInfo = $"Mã DV: {service.MaDV}\n" +
                                           $"Tên DV: {service.TenDV}\n" +
                                           $"Giá: {service.Gia?.ToString("N0")} đ\n" +
                                           $"Cho phép đổi điểm: {(service.ChoPhepDoiDiem ? "Có" : "Không")}";
                        
                        if (service.ChoPhepDoiDiem)
                        {
                            serviceInfo += $"\nGiá trị đổi điểm: {service.GiaTriDoiDiem} điểm";
                        }
                        
                        // Ensure row is selected
                        dgvAvailableServices.Rows[e.RowIndex].Selected = true;
                    }
                }
            }
        }

        private void DgvSelectedServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSelectedServices.SelectedRows.Count > 0)
            {
                var usage = dgvSelectedServices.SelectedRows[0].Tag as ServiceUsage;
                if (usage != null)
                {
                    // Reserved for future detail display
                }
            }
        }

        private void DgvSelectedServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex != dgvSelectedServices.Columns["colRemove"].Index)
            {
                var usage = dgvSelectedServices.Rows[e.RowIndex].Tag as ServiceUsage;
                if (usage != null)
                {
                    string serviceInfo = $"Mã DV: {usage.ServiceCode}\n" +
                                         $"Tên DV: {usage.ServiceName}\n" +
                                         $"Số lượng: {usage.Quantity}\n" +
                                         $"Đơn giá: {usage.UnitPrice:N0} đ\n" +
                                         $"Thành tiền: {usage.Total:N0} đ" +
                                         (usage.PaidByPoint ? "\n(Đã đổi điểm)" : string.Empty);

                    _tooltip.SetToolTip(dgvSelectedServices, serviceInfo);
                    dgvSelectedServices.Rows[e.RowIndex].Selected = true;
                }
            }
        }
    }
}
