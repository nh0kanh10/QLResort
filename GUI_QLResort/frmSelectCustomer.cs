using ET_QLResort;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI_QLResort
{
    public partial class frmSelectCustomer : AppBaseForm
    {
        public GuestM SelectedGuest { get; private set; }
        private List<GuestM> _guestList;

        public frmSelectCustomer(List<GuestM> guestList = null)
        {
            InitializeComponent();
            _guestList = guestList ?? new List<GuestM>();
            InitializeDataGridView();
            SetupEventHandlers();
        }

        private void InitializeDataGridView()
        {


            // Load data
            foreach (var guest in _guestList)
            {
                dgvCustomers.Rows.Add(
                    guest.MaKH,
                    guest.HoTen,
                    guest.SDT,
                    guest.Email,
                    guest.IDNumber
                );
            }
        }

        private void SetupEventHandlers()
        {
            dgvCustomers.SelectionChanged += DgvCustomers_SelectionChanged;
            dgvCustomers.CellDoubleClick += DgvCustomers_CellDoubleClick;
            btnSelect.Click += BtnSelect_Click;
            btnNew.Click += BtnNew_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void DgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            btnSelect.Enabled = dgvCustomers.SelectedRows.Count > 0;
        }

        private void DgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectCustomer(e.RowIndex);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                SelectCustomer(dgvCustomers.SelectedRows[0].Index);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            var addGuestForm = new frmGuest();
            if (addGuestForm.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SelectCustomer(int rowIndex)
        {
            string maKH = dgvCustomers.Rows[rowIndex].Cells["colMaKH"].Value?.ToString();
            SelectedGuest = _guestList.FirstOrDefault(g => g.MaKH == maKH);
        }
    }
}
