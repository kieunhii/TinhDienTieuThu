using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinhDienTieuThu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKV.Text == "Khu Vực 1")
            {
                txtDM.Text = "50";
            }
            if (cboKV.Text == "Khu Vực 2")
            {
                txtDM.Text = "100";
            }
            if (cboKV.Text == "Khu Vực 3")
            {
                txtDM.Text = "150";
            }
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (Convert.ToInt32(txtSC.Text)>Convert.ToInt32(txtSM.Text))
            {
                errorProvider1.SetError(txtSM,"Vui long nhap lai so");
            }
            else
            {
                txtTieuThu.Text = (Convert.ToInt32(txtSM.Text)-Convert.ToInt32(txtSC.Text)).ToString();
                if (Convert.ToInt32(txtTieuThu.Text)<Convert.ToInt32(txtDM.Text))
                {
                    txtThanhTien.Text = (Convert.ToInt32(txtTieuThu.Text)*500).ToString();
                }
                else
                {
                    txtThanhTien.Text = (Convert.ToInt32(txtTieuThu.Text) * 1000).ToString();
                }

                ListViewItem item = new ListViewItem();
                item.Text = txtTen.Text;
                listView1.Items.Add(item);
                item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = cboKV.Text
                });
                item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = txtDM.Text
                }); item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = txtTieuThu.Text
                }); item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = txtThanhTien.Text
                });

                txtTong.Text = (Convert.ToInt32(txtThanhTien.Text) + Convert.ToInt32(txtTong.Text)).ToString();
            
                
            }

        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            txtTen.Clear();
            txtDM.Clear();
            txtSC.Clear();
            txtSM.Clear();
            txtThanhTien.Clear();
            txtTieuThu.Clear();
            cboKV.ResetText();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            try
            {
                int viTri = listView1.SelectedIndices[0];
                txtTong.Text = (Convert.ToInt32(txtTong.Text) - Convert.ToInt32(listView1.Items[viTri].SubItems[4].Text)).ToString();
                listView1.Items.RemoveAt(viTri);
            }
            catch (Exception)
            {

                MessageBox.Show("Can chon dong can xoa");
            }


        }
       
    }
}
