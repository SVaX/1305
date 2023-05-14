using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DemoAppAgain.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddAgentWindow.xaml
    /// </summary>
    public partial class AddAgentWindow : Window
    {
        DemoAgainDbContext db = new DemoAgainDbContext();
        Agent _currentAgent = new Agent();
        public AddAgentWindow()
        {
            InitializeComponent();
            InitTypes();
        }

        public void InitTypes()
        {
            foreach (var cp in db.CompanyTypes)
            {
                comptypeComboBox.Items.Add(cp.Name);
            }
            comptypeComboBox.SelectedIndex = 0;
        }

        public static bool ValidateTextBoxes(TextBox[] textBoxes)
        {
            foreach (TextBox box in textBoxes)
            {
                if (String.IsNullOrEmpty(box.Text))
                {
                    return false;
                }
            }

            return true;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var textBoxes = new TextBox[]
            {
                nameTextBox,
                emailTextBox,
                phoneTextBox,
                addressTextBox,
                priorityTextBox,
                principalTextBox,
                tinTextBox,
                kppTextBox,
                totalTextBox
            };

            if (!ValidateTextBoxes(textBoxes))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание!");
                return;
            }

            if (!int.TryParse(priorityTextBox.Text, out int res))
            {
                MessageBox.Show("Приоритет должен быть числом");
                return;
            }

            if (!int.TryParse(totalTextBox.Text, out int res1))
            {
                MessageBox.Show("Продажи должны быть числом");
                return;
            }

            CompanyType compType = new CompanyType();
            foreach (var ct in db.CompanyTypes)
            {
                if (ct.Name == comptypeComboBox.SelectedValue.ToString())
                {
                    compType = ct;
                }
            }
            int sale = 0;

            foreach (var sal in db.Sales)
            {
                if (Convert.ToInt32(totalTextBox.Text) < sal.TotalImplementation)
                {
                    sale = sal.Sale1;
                    break;
                }
            }

            _currentAgent.Name = nameTextBox.Text;
            _currentAgent.Email = emailTextBox.Text;
            _currentAgent.Phone = phoneTextBox.Text;
            _currentAgent.LegalAddress = addressTextBox.Text;
            _currentAgent.Priority = Convert.ToInt32(priorityTextBox.Text);
            _currentAgent.Principal = principalTextBox.Text;
            _currentAgent.Tin = tinTextBox.Text;
            _currentAgent.Kpp = kppTextBox.Text;
            _currentAgent.TotalImplementation = Convert.ToInt32(totalTextBox.Text);
            _currentAgent.CompanyTypeId = compType.CompanyTypeId;
            _currentAgent.CompanyType = compType;
            _currentAgent.Sale = sale;

            db.Agents.Add(_currentAgent);
            db.SaveChanges();
            MessageBox.Show("Агент успешно добавлен!");
            backButton_Click(sender, e);
        }

        private void imageButton_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.DefaultExt = ".jpg";
            ofd.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            Nullable<bool> result = ofd.ShowDialog();

            if (result == true)
            {
                string filename = ofd.FileName;
                string currentDir = AppDomain.CurrentDomain.BaseDirectory;
                FileInfo fileInfo = new FileInfo(currentDir);
                DirectoryInfo dirInfo = fileInfo.Directory.Parent;
                string parentDirName = dirInfo.Name;

                fileInfo = new FileInfo(parentDirName);
                dirInfo = fileInfo.Directory.Parent;
                parentDirName = dirInfo.Name;

                fileInfo = new FileInfo(dirInfo.ToString());
                dirInfo = fileInfo.Directory.Parent;
                parentDirName = dirInfo.ToString() + "\\Resources\\" + ofd.SafeFileName;

                System.IO.File.Copy(filename, parentDirName, true);

                _currentAgent.Logo = ofd.SafeFileName;
                MessageBox.Show("Картинка добавлена!");
            }
        }
    }
}
