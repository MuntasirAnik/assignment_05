using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Assignment_05
{
    public partial class Form1 : Form
    {
        List<string> ids = new List<string> { };
        List<string> names = new List<string> { };
        List<string> mobiles = new List<string> { };
        List<int> ages = new List<int> { };
        List<string> addresses = new List<string> { };
        List<double> cgpa = new List<double> { };

        public Form1()
        {
            InitializeComponent();
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {
            idTextBox.MaxLength = 4;
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            nameTextBox.MaxLength = 30;
        }

        private void mobileTextBox_TextChanged(object sender, EventArgs e)
        {
            mobileTextBox.MaxLength = 11;
        }

        private void gpaTextBox_TextChanged(object sender, EventArgs e)
        {
            gpaTextBox.MaxLength = 4;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(idTextBox.Text=="" || idTextBox.Text.Length < 4)
            {
                MessageBox.Show("Enter your 4 digit Id.");
            }
            else
            {
                if (nameTextBox.Text == "")
                {
                    MessageBox.Show("enter your name.");
                }
                else
                {                    
                    if (mobileTextBox.Text == "" || mobileTextBox.Text.Length < 11)
                    {
                        MessageBox.Show("Enter your 11 digit mobile number");
                    }
                    else
                    {
                        int i;
                        if(ageTextBox.Text =="" || !int.TryParse(ageTextBox.Text, out i))
                        {
                            MessageBox.Show("age must be a number value");
                        }
                        else
                        {
                            double q;
                            if(gpaTextBox.Text=="" || !double.TryParse(gpaTextBox.Text, out q))
                            {
                                MessageBox.Show("gpa must be number");
                            }
                            else
                            {
                                foreach (string id in ids)
                                {
                                    if (id == idTextBox.Text)
                                    {
                                         MessageBox.Show("dublicate id");
                                         return;
                                    }
                                }
                                foreach (string mobile in mobiles)
                                {
                                    if (mobile == mobileTextBox.Text)
                                    {
                                        MessageBox.Show("dublicate contact number");
                                        return;
                                    }
                                }
                                AddStudent(idTextBox.Text, nameTextBox.Text, mobileTextBox.Text, Convert.ToInt32(ageTextBox.Text), addressTextBox.Text, Convert.ToDouble(gpaTextBox.Text));
                                MessageBox.Show("Data Saved Successfully!!!");
                                ShowCurrentStuData(idTextBox.Text, nameTextBox.Text, mobileTextBox.Text, Convert.ToInt32(ageTextBox.Text), addressTextBox.Text, Convert.ToDouble(gpaTextBox.Text));

                            }
                        }
                    }

                    

                }                                                                      
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            stuInfoRichTextBox.Text = "";
            string message = "";

            for (int i = 0; i < ids.Count(); i++)
            {

                message += "Id:\t" + ids[i] + "\nName:\t" + names[i] + "\nMobile:\t" + mobiles[i] + "\nAge:\t" + ages[i] + "\nAddress:\t" + addresses[i] + "\nGPA:\t" + cgpa[i] + "\n-----------------------------\n";

            }
            stuInfoRichTextBox.Text += message;
            CaculateTotalGpa();
            MaxGpa();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            stuInfoRichTextBox.Text = "";
            if (idRadioButton.Checked == true)
            {
                string message="";
                if (ids.Contains(idTextBox.Text))
                {
                    int index = ids.IndexOf(idTextBox.Text);

                    message += "Id:\t" + ids[index] + "\nName:\t" + names[index] +"\nMobile:\t"+mobiles[index]+"\naddress:\t"+ addresses[index] +"\nGPA:\t"+cgpa[index]+ "\n-----------------------------\n";
                    stuInfoRichTextBox.Text += message;
                }                
                else
                {
                    MessageBox.Show("no data found ");
                }

            }
            if(nameRadioButton.Checked == true)
            {
                string message = "";
                if(names.Contains(nameTextBox.Text))
                {
                    int index = names.IndexOf(nameTextBox.Text);
                    message += "Id:\t" + ids[index] + "\nName:\t" + names[index] + "\nMobile:\t" + mobiles[index] + "\naddress:\t" + addresses[index] + "\nGPA:\t" + cgpa[index] + "\n-----------------------------\n";
                    stuInfoRichTextBox.Text += message;
                }
                else
                {
                    MessageBox.Show("no data found ");
                }
            }
            if (mobileRadioButton.Checked == true)
            {
                string message = "";
                if (mobiles.Contains(mobileTextBox.Text))
                {
                    int index = mobiles.IndexOf(mobileTextBox.Text);
                    message += "Id:\t" + ids[index] + "\nName:\t" + names[index] + "\nMobile:\t" + mobiles[index] + "\naddress:\t" + addresses[index] + "\nGPA:\t" + cgpa[index] + "\n-----------------------------\n";
                    stuInfoRichTextBox.Text += message;
                }
                else
                {
                    MessageBox.Show("no data found ");
                }
            }



        }
        private void AddStudent(string id, string name, string mobile, int age, string address, double gpa)
        {
            ids.Add(id);
            names.Add(name);
            mobiles.Add(mobile);
            ages.Add(age);
            addresses.Add(address);
            cgpa.Add(gpa);
        }
        private void ShowCurrentStuData(string id, string name, string mobile, int age, string address, double gpa)
        {
            string message;
            message = "Id:\t" + id + "\nName:\t" + name + "\nMobile:\t" + mobile + "\nAge:\t" + age + "\nAddress:\t" + address + "\nGPA:\t" + gpa;
            stuInfoRichTextBox.Text = message;
        }
        private void MaxGpa()
        {
            double maxValue = cgpa.Max();
            int index = cgpa.IndexOf(maxValue);
            maxNameTextBox.Text = "";
            maxNameTextBox.AppendText(names[index]);


            double minValue = cgpa.Min();
            int index1 = cgpa.IndexOf(minValue);
            minNameTextBox.Text = "";
            minNameTextBox.AppendText(names[index1]);


            maxTextBox.Text = maxValue.ToString();
            minTextBox.Text = minValue.ToString();
        }
        private void CaculateTotalGpa()
        {
            double counter = 0;
            double sum = 0;
            double ans = 0;
            for (int i = 0; i < cgpa.Count(); i++)
            {
                sum += cgpa[i];
                counter++;
            }
            ans = sum / counter;
            aveTextBox.Text = ans.ToString();
            totalTextBox.Text = sum.ToString();

        }
    }
}
