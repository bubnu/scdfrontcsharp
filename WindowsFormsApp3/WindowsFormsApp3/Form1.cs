using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp3;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        EmployeeService employeeService;
        List<Employee> employeeList;
        DepartmentService departmentService;
        List<Department> departmentList;
        public Form1()
        {
            InitializeComponent();
            employeeService = new EmployeeService();
            employeeService.createConnection();
            departmentService = new DepartmentService();
            departmentService.createConnection();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            employeeList = await employeeService.GetEmployeesAsync();
        
            comboBox1.DataSource = employeeList;
            comboBox1.DisplayMember = "name";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button Clicked");

            departmentList = await departmentService.GetDepartmentsAsync();

            Console.WriteLine("After GetDepartmentsAsync");

            comboBox2.DataSource = departmentList;
            comboBox2.DisplayMember = "description";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int intValue) && int.TryParse(textBox3.Text, out int intValue2))
            {
                Department department = new Department(textBox1.Text, intValue, intValue2);
                departmentService.CreateDepartmentAsync(department);
            }
            else
            {
                MessageBox.Show("Please enter valid integer values.");
            }

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int intValue = int.Parse(textBox4.Text);
               await departmentService.UpdateDepartmentDescriptionAsync(textBox1.Text, intValue);
            
                    }
            catch (FormatException)
            {
                // Handle the case where the input is not a valid integer
                MessageBox.Show("Please enter a valid integer.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox6.Text, out int intValue) && int.TryParse(textBox7.Text, out int intValue2))
            {
                Employee employee = new Employee(textBox5.Text, intValue, intValue2, textBox6.Text);
                employeeService.CreateEmployeeAsync(employee);
            }
            else
            {
                MessageBox.Show("Please enter valid integer values.");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private async void button6_Click(object sender, EventArgs e)
        {

            if (int.TryParse(textBox6.Text, out int intValue) && int.TryParse(textBox9.Text, out int intValue2))
            {
                await employeeService.UpdateEmployeeDepartmentIDAsync(intValue, intValue2);
                
            }
            else
            {
                MessageBox.Show("Please enter valid integer values.");
            }
         
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int intValue = int.Parse(textBox9.Text);
                await employeeService.UpdateEmployeeEmailAsync(textBox8.Text, intValue);

            }
            catch (FormatException)
            {
                // Handle the case where the input is not a valid integer
                MessageBox.Show("Please enter a valid integer.");
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            try
            {
                int intValue = int.Parse(textBox9.Text);
                await employeeService.UpdateEmployeeNameAsync(textBox5.Text, intValue);

            }
            catch (FormatException)
            {
                // Handle the case where the input is not a valid integer
                MessageBox.Show("Please enter a valid integer.");
            }
        }
    }
}
