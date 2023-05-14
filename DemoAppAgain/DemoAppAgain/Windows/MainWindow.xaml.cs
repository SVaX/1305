using DemoAppAgain.Windows;
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
				ag.Logo = ag.Logo.Replace("/Resources/", "");
				ag.Logo = $"/Resources/{ag.Logo}";
				db.Entry(ag).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				db.SaveChanges();

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
			agents = db.Agents.ToList();
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

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
			var foundAgents = agents.Where(x => x.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
			agentsList.ItemsSource = foundAgents;
        }

        private void agentsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			if (agentsList.SelectedItems.Count > 1)
            {
				changePriorityButton.Visibility = Visibility.Visible;
            }
			else
            {
				changePriorityButton.Visibility = Visibility.Hidden;
            }
        }

        private void changePriorityButton_Click(object sender, RoutedEventArgs e)
        {
			var priority = 0;
			var highestPriority = 0;
			var window = new ChangePriorityModalWindow();
			foreach (var ag in agents)
			{
				for (var i = 0; i < agentsList.SelectedItems.Count; i++)
				{
					if (ag == agentsList.SelectedItems[i] as Agent)
					{
						if (ag.Priority > highestPriority)
                        {
							highestPriority = ag.Priority;
                        }
					}
				}
			}
			window.priorityTextBox.Text = highestPriority.ToString();

			if (window.ShowDialog() == true)
            {
				priority = Convert.ToInt32(window.priorityTextBox.Text);
				foreach (var ag in agents)
                {
					for (var i = 0; i < agentsList.SelectedItems.Count; i++)
                    {
						if (ag == agentsList.SelectedItems[i] as Agent)
                        {
                            ag.Priority = priority;
							db.Entry(ag).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
							db.SaveChanges();
                        }
                    }
                }
            }
			else
            {

				return;
            }

			changePriorityButton.Visibility = Visibility.Hidden;
			InitList();
			agentsList.SelectedIndex = 0;
        }

        private void agentsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
			var window = new EditAgentWindow(agentsList.SelectedItem as Agent);
			window.Show();
			this.Close();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
			var window = new AddAgentWindow();
			window.Show();
			this.Close();
        }
    }
}
