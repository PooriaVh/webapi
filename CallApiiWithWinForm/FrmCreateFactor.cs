using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CallApiiWithWinForm.Models;
using Newtonsoft.Json;

namespace CallApiiWithWinForm
{
    public partial class FrmCreateFactor : Form
    {
        private string url1 = "http://127.0.0.1:5000";

        public FrmCreateFactor()
        {
            InitializeComponent();
        }

        private async void FrmCreateFactor_Load(object sender, EventArgs e)
        {

            IEnumerable<Customer> customers = await GetHttpCustomerAsync();
            DataTable dt = new DataTable();

            cmbCustomers.DataSource = customers;
            cmbCustomers.ValueMember = "Id";
            cmbCustomers.DisplayMember = "Name";



            IEnumerable<Products> products = await GetHttpProductAsync();
            DataTable dt2 = new DataTable();

            dataGridView1.DataSource = products;
            dataGridView1.Columns.AddRange(
            new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "TotalPrice" },
                new DataGridViewTextBoxColumn { Name = "Quantity" },
                new DataGridViewCheckBoxColumn { Name = "select" }
            });
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].ReadOnly = true;

            }
            dataGridView1.Columns["Quantity"].ReadOnly=false;
            dataGridView1.Columns["select"].ReadOnly = false;

        }
        private async Task<IEnumerable<Customer>> GetHttpCustomerAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://127.0.0.1:5000/");

                    var requestUri = "getlist/getCustomer";

                    var responsed = client.GetAsync(requestUri);

                    var content = await responsed.Result.Content.ReadAsStringAsync();
                    var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(content);
                    return customers;
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occurred: {ex.Message}");
            }
        }


        private async Task<IEnumerable<Products>> GetHttpProductAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://127.0.0.1:5000/");
                    
                    var requestUri = "getlist/getl";

                    var responsed = client. GetAsync(requestUri);

                    var content = await responsed.Result.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<IEnumerable<Products>>(content);
                    return products;
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occurred: {ex.Message}");
            }
        }
        private async Task<long> PostCreateFactors(List<Factor>factors)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://127.0.0.1:5000/");
                    var a=JsonConvert.SerializeObject(factors);
                    var content = new StringContent(a, Encoding.UTF8, "application/json");
                    var requestUri = "Factor/Create";

                    var responsed  =await client.PostAsync(requestUri,content);

                    //await responsed.Result.Content.ReadAsStringAsync();
                   // var products = JsonConvert.DeserializeObject<IEnumerable<Products>>(content);
                    return responsed;
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occurred: {ex.Message}");
            }
        }





        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateBalance();
        }


        private void UpdateBalance()
        {
            int counter;


            // Iterate through the rows, skipping the Starting Balance row.
            for (counter = 0; counter < (dataGridView1.Rows.Count);
                counter++)
            {
                if (dataGridView1.Rows[counter].Cells["Quantity"].Value != null)
                {
                    dataGridView1.Rows[counter].Cells["TotalPrice"].Value = (decimal.Parse(dataGridView1.Rows[counter].Cells["Quantity"].Value.ToString()) * decimal.Parse(dataGridView1.Rows[counter].Cells["Price"].Value.ToString())).ToString();

                }


            }
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 5) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int counter=0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean( dataGridView1.Rows[i].Cells["Select"].Value))
                {
                    counter++;
                }
            }
            if (counter==0)
            {
                MessageBox.Show("برای ایجاد فاکتور می بایست حداقل یک مورد را از لیست محصولات انتخاب نمایید!");
            }
            else
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
