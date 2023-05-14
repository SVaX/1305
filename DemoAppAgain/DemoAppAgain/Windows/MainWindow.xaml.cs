using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoAppAgain
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		DemoAgainDbContext db = new DemoAgainDbContext();
		List<Agent> agents = new List<Agent>();
		public MainWindow()
		{
			InitializeComponent();

			agents = db.Agents.ToList();

			foreach (var ag in agents)
			{
				ag.Logo = ag.Logo.Replace("\\agents\\", "");
				ag.Logo = $"/Resources/{ag.Logo}";

				foreach (var ct in db.CompanyTypes)
				{
					if (ag.CompanyTypeId == ct.CompanyTypeId)
					{
						ag.CompanyType = ct;
					}
				}
			}

			InitComboBoxes();
			InitList();
		}

		private void InitList()
        {
			agentsList.ItemsSource = agents;
		}

		private void InitComboBoxes()
        {
			agentSortComboBox.Items.Add("Отсортировать по названию (возрастание)");
			agentSortComboBox.Items.Add("Отсортировать по названию (убывание)");
			agentSortComboBox.Items.Add("Отсортировать по размеру скидки (возрастание)");
			agentSortComboBox.Items.Add("Отсортировать по размеру скидки (убывание)");
			agentSortComboBox.Items.Add("Отсортировать по приоритету (возрастание)");
			agentSortComboBox.Items.Add("Отсортировать по приоритету (убывание)");

            agentTypeFilterComboBox.Items.Add("Все типы");
			agentTypeFilterComboBox.SelectedIndex = 0;
			foreach (var cp in db.CompanyTypes)
            {
				agentTypeFilterComboBox.Items.Add(cp.Name);
            }
        }

        private void agentSortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			switch (agentSortComboBox.SelectedIndex)
            {
				case 0:
                    {
						agents = agents.OrderBy(x => x.Name).ToList();
						agentsList.ItemsSource = agents;
						break;
                    }
				case 1:
                    {
						agents = agents.OrderByDescending(x => x.Name).ToList();
						agentsList.ItemsSource = agents;
						break;
					}
				case 2:
                    {
						agents = agents.OrderBy(x => x.Sale).ToList();
						agentsList.ItemsSource = agents;
						break;
					}
				case 3:
                    {
						agents = agents.OrderByDescending(x => x.Sale).ToList();
						agentsList.ItemsSource = agents;
						break;
					}
				case 4:
                    {
						agents = agents.OrderBy(x => x.Priority).ToList();
						agentsList.ItemsSource = agents;
						break;
					}
				case 5:
					{
						agents =agents.OrderByDescending(x => x.Priority).ToList();
						agentsList.ItemsSource = agents;
						break;
					}
				default:
                    {
						agents = db.Agents.ToList();
						agentsList.ItemsSource = agents;
						break;
					}
			}
        }

        private void agentTypeFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			agents = db.Agents.ToList();
			switch (agentTypeFilterComboBox.SelectedIndex)
            {
				case 0:
					{
						agents = db.Agents.ToList();
						agentsList.ItemsSource = agents;
						break;
					}
				default:
                    {
						agents = agents.Where(a => a.CompanyType.Name == agentTypeFilterComboBox.SelectedValue).ToList();
						agentsList.ItemsSource = agents;
						break;
                    }
			}
			agentSortComboBox_SelectionChanged(sender, e);
        }
    }
}
