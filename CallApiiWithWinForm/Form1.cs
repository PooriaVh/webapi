using CallApiiWithWinForm.Models;
using FastMember;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CallApiiWithWinForm
{
    public partial class Form1 : Form
    {
        private string  url1 = "http://127.0.0.1:5000";
        public Form1()
        {
            InitializeComponent();
        }

        private async void Search_Click(object sender, EventArgs e)
        {
            //using (var client = new HttpClient())
            //{


            //    var url = this.url1 +"/getlist/getl";

            //    var response = client.GetAsync(url);

            //    var resut = JsonConvert.DeserializeObject<IEnumerable<Products>>(await response.Result.Content.ReadAsStringAsync());
            //    IEnumerable<Products> data = resut;
            //    DataTable table = new DataTable();
            //    using (var reader = ObjectReader.Create(data))
            //    {
            //        table.Load(reader);
            //    }

            //    dgp_product.DataSource = table;
            //}

            IEnumerable<Products> products = await GetHttpProductAsync();
            DataTable dt = new DataTable();
            //using (var reader = ObjectReader.Create(products))
            //{
            //    dt.Load(reader);
            //}
            dgp_product.DataSource = products;
            dgp_product.Columns[0].Visible= false;
        }


        private async Task<IEnumerable<Products>> GetProductAsync()
        {
            using (var client = new RestClient("http://127.0.0.1:5000/"))
            {
                var request = new RestRequest("getlist/getl", Method.Get);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-Type", "application/json");

                var response = await client.GetAsync(request);

                if (response.IsSuccessful)
                {
                    var products = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Products>>(response.Content);
                    return products;
                }
                else
                {
                    throw new Exception($"Error retrieving products: {response.ErrorMessage}");
                }
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

                    var responsed = client.GetAsync(requestUri);

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

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCreateFactor  frmCreateFactor = new FrmCreateFactor();
            frmCreateFactor.ShowDialog();
        }
    }
}
