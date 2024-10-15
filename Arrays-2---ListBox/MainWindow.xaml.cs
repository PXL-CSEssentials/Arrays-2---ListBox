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

namespace Arrays_2___ListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] _names = new string[12] { "Inge", "Robbe", "Brecht", "Younes", "Patrizia", "Haci", "Andrea", "Geordy", "Gillian", "Jurgen", "Liesbeth", "Furkan" };
        public MainWindow()
        {
            InitializeComponent();
            ShowInListBox();
        }

        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            // Sorteer de items in de simpleListBox op alfabetische volgorde.
            //simpleListBox.Items.SortDescriptions.Add(
            //    new System.ComponentModel.SortDescription(
            //        "Content", 
            //        System.ComponentModel.ListSortDirection.Ascending));
            Array.Sort(_names);
            ShowInListBox();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            // Alle elementen verwijderen.
            simpleListBox.Items.Clear();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            //  index == -1 : niets geselecteerd
            if (simpleListBox.SelectedIndex == -1)
                return;

            // Element opvragen
            //resultTextBox.Text = ((ListBoxItem)simpleListBox.SelectedItem).Content.ToString();
            // RemoveAt gooit een exception wanneer er niets is geselecteerd.
            simpleListBox.Items.RemoveAt(simpleListBox.SelectedIndex);
            // Remove gooit geen exception wanneer er niets is geselecteerd.
            simpleListBox.Items.Remove(simpleListBox.SelectedItem);
        }

        private void replaceButton_Click(object sender, RoutedEventArgs e)
        {
            // Index opvragen van het geselecteerde item
            int index = simpleListBox.SelectedIndex;
            // Als niets geselecteerd is, niets meer doen.
            if (index == -1)
                return;

            ((ListBoxItem)simpleListBox.SelectedItem).Content = replaceTextBox.Text;

            // Of verwijderen en invoegen naar specifieke plaats, maar dat is trager...
            /*
            simpleListBox.Items.RemoveAt(index);
            ListBoxItem item = new ListBoxItem();
            item.Content = replaceTextBox.Text;
            simpleListBox.Items.Insert(index, item);
            */
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            // Achteraan toevoegen.
            ListBoxItem item = new ListBoxItem();
            item.Content = addTextBox.Text;
            simpleListBox.Items.Add(item);
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            int foundIndex = -1; // zet op -1 omdat we in het begin nog niks gevonden hebben
            int searchIndex = 0; // huidige positie in ListBox. Start vanaf 0

            foreach (ListBoxItem item in simpleListBox.Items)
            {
                if (item.Content.Equals(searchTextBox.Text))
                {
                    // Gevonden! Dus stoppen met zoeken => break om uit de lus te ontsnappen
                    foundIndex = searchIndex;
                    break;
                }
                searchIndex++;
            }
            if (foundIndex != -1)
            {
                searchLabel.Content = $"Item op plaats {foundIndex + 1} gevonden.";
                // Item in listbox selecteren.
                simpleListBox.SelectedIndex = foundIndex;
            }
            else
            {
                searchLabel.Content = "Item niet gevonden.";
            }
        }

        private void multipleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            resultTextBox.Clear();
            foreach (ListBoxItem item in simpleListBox2.SelectedItems)
            {
                resultTextBox.Text += $"{item.Content}\r\n";
            }
            */
            resultTextBox.Text = $"Er zijn {multipleListBox.SelectedItems.Count} item(s) geselecteerd.";
        }

        private void ShowInListBox()
        {
            simpleListBox.Items.Clear();
            foreach (string naam in _names)
            {
                simpleListBox.Items.Add(new ListBoxItem() { Content = naam });
            }
        }
    }
}
