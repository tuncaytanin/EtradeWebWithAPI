using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WebAPIWithWindowsForm
{
    public partial class FormUser : Form
    {
        #region Tanımlar
        private string url = "https://localhost:44340/api/";
        private int selectedId = 0;
        #endregion


        #region Form
        public FormUser()
        {
            InitializeComponent();
            Load += FormUser_Load;
        }

        private async void FormUser_Load(object sender, EventArgs e)
        {

            await UyeleriListele();
        }
        #endregion

        #region CRUD
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                UserAddDto userAddDto = new UserAddDto()
                {
                    FirstName = txtFirstName.Text,
                    Adress = txtAdress.Text,
                    DateOfBirth = dtpDateOfBirth.Value,
                    Email = txtEmail.Text,
                    Gender = cboxGender.Text == "Erkek" ? true : false,
                    LastName = txtLastName.Text,
                    Password = txtPassword.Text,
                    UserName = txtUserName.Text
                };

                HttpResponseMessage response = await httpClient.PostAsJsonAsync(url + "Users/Add", userAddDto);
                if (response.IsSuccessStatusCode)
                {
                    await UyeleriListele();
                    MessageBox.Show("Ekleme İşlemi Başarılı");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Ekleme İşlemi Sırasında Hata Oluştu");
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {

                await httpClient.DeleteAsync(url + "Users/Delete/" + selectedId.ToString());
                await UyeleriListele();
            }
        }
        #endregion
        #region Method
        private async Task UyeleriListele()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var users = await httpClient.GetFromJsonAsync<List<UserDetailDto>>(new Uri(url + "Users/GetList"));
                dgvUsers.DataSource = users;
            }
        }

        void ClearForm()
        {
            txtAdress.Text = String.Empty;
            txtEmail.Text  = String.Empty;
            txtFirstName.Text= String.Empty;
            txtLastName.Text= String.Empty;
            txtPassword.Text= String.Empty;
            txtUserName.Text= String.Empty; ;
            cboxGender.Text= String.Empty;
            dtpDateOfBirth.Value = DateTime.Now;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }



        #endregion

        private async void dgvUsers_DoubleClick(object sender, EventArgs e)
        {
            selectedId = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value.ToString());
            if (selectedId>0)
            {

                using (HttpClient httpClient= new HttpClient())
                {
                    var user = await httpClient.GetFromJsonAsync<UserDto>(url + "Users/GetById/" + selectedId.ToString());
                    if (user is not null)
                    {
                        txtAdress.Text = user.Adress;
                        txtEmail.Text= user.Email;
                        txtFirstName.Text = user.FirstName;
                        txtLastName.Text=user.LastName;
                        txtPassword.Text = String.Empty;
                        txtUserName.Text = user.UserName;
                        cboxGender.Text = user.Gender == true ? "Erkek" : "Kadın";
                        dtpDateOfBirth.Value = user.DateOfBirth;

                    }
                }
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                UserUpdateDto userUpdateDto = new UserUpdateDto()
                {
                    FirstName = txtFirstName.Text,
                    Adress = txtAdress.Text,
                    DateOfBirth = dtpDateOfBirth.Value,
                    Email = txtEmail.Text,
                    Gender = cboxGender.Text == "Erkek" ? true : false,
                    LastName = txtLastName.Text,
                    Password = txtPassword.Text,
                    UserName = txtUserName.Text,
                    Id = selectedId
                };

                HttpResponseMessage response = await httpClient.PutAsJsonAsync(url + "Users/Update", userUpdateDto);
                if (response.IsSuccessStatusCode)
                {
                    await UyeleriListele();
                    MessageBox.Show("Ekleme İşlemi Başarılı");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Ekleme İşlemi Sırasında Hata Oluştu");
                }
            }
        }
    }
}
