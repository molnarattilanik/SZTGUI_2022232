using Newtonsoft.Json;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pizza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists("orders.json"))
            {
                var pizzas = JsonConvert.DeserializeObject<Order[]>(File.ReadAllText("orders.json"));
                pizzas.ToList().ForEach(o => orders_listBox.Items.Add(o));
            }

            pizzaName_comboBox.Items.Add("Mexikói");
            pizzaName_comboBox.Items.Add("Magyaros");
            pizzaName_comboBox.Items.Add("Húsos");
            pizzaName_comboBox.Items.Add("Hawaii");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Order order = new(personName_textBox.Text, pizzaName_comboBox.SelectedItem.ToString(), tomato_radioButton.IsChecked);
            orders_listBox.Items.Add(order);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var orders = new List<Order>();
            foreach (var item in orders_listBox.Items)
            {
                orders.Add(item as Order);
            }

            var ordersInJson = JsonConvert.SerializeObject(orders);

            File.WriteAllText("orders.json", ordersInJson);
        }
    }

    public class Order
    {
        public Order(string personName, string pizzaName, bool? isTomato)
        {
            PersonName = personName;
            PizzaName = pizzaName;
            IsTomato = isTomato;
        }

        public string PersonName { get; set; }

        public string PizzaName { get; set; }

        public bool? IsTomato { get; set; }

        public override string ToString()
        {
            return $"{PersonName} - {PizzaName} - {IsTomato}";
        }
    }
}
