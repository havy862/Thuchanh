using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TH03
{
    public partial class FrmSinhVien : Form
    {
        DataTable SinhVien;
        public FrmSinhVien()
        {
            InitializeComponent();
        }
        private void LoadDataToGridview()
        {
            string sql = "SELECT * FROM SinhVien";
            SinhVien = DAO.LoadDataToTable(sql);
            dataGridViewSV.DataSource = SinhVien;
        }
        private void FrmSinhVien_Load(object sender, EventArgs e)
        {
            LoadDataToGridview();
            DAO.FillCombo("SELECT * FROM SinhVien", cboMaLop, "MaLop");
            cboMaLop.SelectedIndex = -1;
        }
        private void ResetValues()
        {
            txtMaSV.Text = "";
            txtTenSV.Text = "";
            txtNamSinh.Text = "";
            txtQueQuan.Text = "";
            cboMaLop.Text = "";
        }
        private void dataGridViewSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.Text = dataGridViewSV.CurrentRow.Cells["MaSV"].Value.ToString();
            txtTenSV.Text = dataGridViewSV.CurrentRow.Cells["TenSV"].Value.ToString();
            txtNamSinh.Text = dataGridViewSV.CurrentRow.Cells["NamSinh"].Value.ToString();
            txtQueQuan.Text = dataGridViewSV.CurrentRow.Cells["QueQuan"].Value.ToString();
            cboMaLop.Text = dataGridViewSV.CurrentRow.Cells["MaLop"].Value.ToString();
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            ResetValues();

            int count = 0;
            count = dataGridViewSV.Rows.Count;
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dataGridViewSV.Rows[count - 2].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi.Remove(0, 2)));
            if (chuoi2 + 1 < 10)
            {
                txtMaSV.Text = "SV00" + (chuoi2 + 1).ToString();
            }
            else
                if (chuoi2 + 1 < 100)
            {
                txtMaSV.Text = "SV0" + (chuoi2 + 1).ToString();
            }
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaSV.Text == "")
            {
                MessageBox.Show("Bạn cần nhập mã sinh viên");
                txtMaSV.Focus();
                return;
            }
            if (txtTenSV.Text == "")
            {
                MessageBox.Show("Bạn cần nhập tên sinh viên");
                txtTenSV.Focus();
                return;
            }
            if (txtNamSinh.Text == "")
            {
                MessageBox.Show("Bạn cần nhập năm sinh");
                txtNamSinh.Focus();
                return;
            }
            if (txtQueQuan.Text == "")
            {
                MessageBox.Show("Bạn cần nhập quê quán");
                txtQueQuan.Focus();
                return;
            }
            if (cboMaLop.Text == "")
            {
                MessageBox.Show("Bạn cần chọn mã lớp");
                cboMaLop.Focus();
                return;
            }
            sql = "SELECT MaSV FROM SinhVien WHERE MaSV= '" + txtMaSV.Text + "'";
            if (DAO.CheckKey(sql))
            {
                MessageBox.Show("Mã sinh viên này đã tồn tại, bạn phải nhập mã khác", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                txtMaSV.Text = "";
                return;
            }
            sql = "INSERT INTO SinhVien VALUES ('" + txtMaSV.Text + "', N'" + txtTenSV.Text + "', '" + txtNamSinh.Text +
                "', " + txtQueQuan.Text + ", '" + cboMaLop.Text + "')";
            DAO.RunSql(sql);
            LoadDataToGridview();
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (SinhVien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE SinhVien SET TenSV = N'" + txtTenSV.Text + "', NamSinh = '" + txtNamSinh.Text +
                "', QueQuan = " + txtQueQuan.Text + ", MaLop = '" + cboMaLop.Text + "' WHERE MaSV= '" + txtMaSV.Text + "'";
            DAO.RunSql(sql);
            LoadDataToGridview();
        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (SinhVien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM SinhVien WHERE MaSV = '" + txtMaSV.Text + "'";
                DAO.RunSql(sql);
                LoadDataToGridview();
            }
        }
        private void bntThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
