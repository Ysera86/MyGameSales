using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            Console.WriteLine("1 - Customers");
            Console.WriteLine("2 - Campaigns");
            Console.WriteLine("3 - Orders");
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine();
                        CustomerMenu(key);
                    }
                    break;
                case ConsoleKey.D2:
                    {
                        Console.WriteLine();
                        CampaignMenu(key);
                    }
                    break;
                case ConsoleKey.D3:
                    {
                        Console.WriteLine();
                        OrderMenu(key);
                    }
                    break;
                default:
                    break;
            }


            Console.ReadKey();
        }

        private static void OrderMenu(ConsoleKeyInfo key)
        {
            OrderManager orderManager = new OrderManager(new IMOrderDAL());

            ListOrders(orderManager);

            Console.WriteLine("A - Add Order");
            Console.WriteLine("U - Update Order");
            Console.WriteLine("D - Delete Order");
            Console.WriteLine("M - Main Menu");

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.A:
                    {
                        Console.WriteLine();
                        var orders = orderManager.GetAllOrders();

                        Order order = new Order();
                        if (orders.Count > 0)
                        {
                            order.OrderId = orders.Max(x => x.OrderId) + 1;
                        }
                        else { order.OrderId = 1; }
                        Console.Write("Campaing Id : ");
                        order.CampaignId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Customer Id : ");
                        order.CustomerId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Game Id : ");
                        order.GameId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Order Date : ");
                        order.OrderDate = Convert.ToDateTime(Console.ReadLine());

                        try
                        {
                            orderManager.AddOrder(order);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        ListOrders(orderManager);
                    }
                    break;
                case ConsoleKey.U:
                    {
                        Console.WriteLine();
                        Order order = new Order();
                        Console.Write("Order Id : ");

                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            order.OrderId = id;
                        }
                        if (orderManager.GetAllOrders().SingleOrDefault(x => x.OrderId == order.OrderId) != null)
                        {
                            Console.Write("Campaing Id : ");
                            order.CampaignId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Customer Id : ");
                            order.CustomerId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Game Id : ");
                            order.GameId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Order Date : ");
                            order.OrderDate = Convert.ToDateTime(Console.ReadLine());

                            orderManager.UpdateOrder(order);
                            ListOrders(orderManager);
                        }
                        else
                        {
                            Console.WriteLine("No such Order exists!!");
                        }
                    }
                    break;
                case ConsoleKey.D:
                    {
                        Console.WriteLine();
                        Console.Write("Order Id : ");

                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            var order = orderManager.GetOrder(id);
                            if (order != null)
                            {
                                orderManager.DeleteOrder(order);
                                ListOrders(orderManager);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No such Order exists!!");
                        }
                    }
                    break;
                case ConsoleKey.M:
                    {
                        Console.WriteLine("");
                        MainMenu();
                    }
                    break;
                default:
                    break;
            }

        }
        private static void ListOrders(OrderManager orderManager)
        {
            foreach (var order in orderManager.GetAllOrders())
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4}", order.OrderId, order.OrderDate, order.CampaignId, order.GameId, order.Price);
            }
        }
        private static void CustomerMenu(ConsoleKeyInfo key)
        {
            CustomerManager customerManager = new CustomerManager(new IMCustomerDAL(), new RealPersonCheckManager());

            ListCustomers(customerManager);

            Console.WriteLine("A - Add Customer");
            Console.WriteLine("U - Update Customer");
            Console.WriteLine("D - Delete Customer");
            Console.WriteLine("M - Main Menu");

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.A:
                    {
                        Console.WriteLine();
                        Customer customer = new Customer();
                        customer.Id = customerManager.GetAllCustomers().Max(x => x.Id) + 1;
                        Console.Write("Customer FirstName : ");
                        customer.FirstName = Console.ReadLine();
                        Console.Write("Customer LastName : ");
                        customer.LastName = Console.ReadLine();
                        Console.Write("Customer NationalityId : ");
                        customer.NationalityId = Console.ReadLine();
                        Console.Write("Customer DateOfBirth : ");
                        customer.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Customer Favourite Genre : ");
                        customer.FavouriteGenre = Console.ReadLine();

                        try
                        {
                            customerManager.AddCustomer(customer);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        ListCustomers(customerManager);
                    }
                    break;
                case ConsoleKey.U:
                    {
                        Console.WriteLine();
                        Customer customer = new Customer();
                        Console.Write("Customer Id : ");

                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            customer.Id = id;
                        }
                        if (customerManager.GetAllCustomers().SingleOrDefault(x => x.Id == customer.Id) != null)
                        {
                            Console.Write("Favourite Genre : ");
                            customer.FavouriteGenre = Console.ReadLine();

                            customerManager.UpdateCustomer(customer);
                            ListCustomers(customerManager);
                        }
                        else
                        {
                            Console.WriteLine("No such customer exists!!");
                        }
                    }
                    break;
                case ConsoleKey.D:
                    {
                        Console.WriteLine();
                        Console.Write("Customer Id : ");

                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            var campaign = customerManager.GetCustomer(id);
                            if (campaign != null)
                            {
                                customerManager.DeleteCustomer(campaign);
                                ListCustomers(customerManager);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No such customer exists!!");
                        }
                    }
                    break;
                case ConsoleKey.M:
                    {
                        Console.WriteLine("");
                        MainMenu();
                    }
                    break;
                default:
                    break;
            }

        }

        private static void ListCustomers(CustomerManager customerManager)
        {
            foreach (var customer in customerManager.GetAllCustomers())
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", customer.Id, customer.FirstName, customer.LastName, customer.FavouriteGenre);
            }
        }
        private static void CampaignMenu(ConsoleKeyInfo key)
        {
            CampaignManager campaignManager = new CampaignManager(new IMCampaignDAL());

            ListCampaigns(campaignManager);

            Console.WriteLine("A - Add Campaign");
            Console.WriteLine("U - Update Campaign");
            Console.WriteLine("D - Delete Campaign");
            Console.WriteLine("M - Main Menu");
            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.A:
                    {
                        Console.WriteLine();
                        Campaign campaign = new Campaign();
                        campaign.Id = campaignManager.GetAllCampaigns().Max(x => x.Id) + 1;
                        Console.Write("Campaign Name : ");
                        campaign.CampaignName = Console.ReadLine();
                        Console.Write("Campaign Description : ");
                        campaign.Description = Console.ReadLine();
                        Console.Write("Campaign Discount : ");
                        campaign.Discount = Convert.ToDecimal(Console.ReadLine());

                        campaignManager.AddCampaign(campaign);
                        ListCampaigns(campaignManager);
                    }
                    break;
                case ConsoleKey.U:
                    {
                        Console.WriteLine();
                        Campaign campaign = new Campaign();
                        Console.Write("Campaign Id : ");

                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            campaign.Id = id;
                        }
                        if (campaignManager.GetAllCampaigns().SingleOrDefault(x => x.Id == campaign.Id) != null)
                        {
                            Console.Write("Campaign Name : ");
                            campaign.CampaignName = Console.ReadLine();
                            Console.Write("Campaign Description : ");
                            campaign.Description = Console.ReadLine();
                            Console.Write("Campaign Discount : ");
                            campaign.Discount = Convert.ToDecimal(Console.ReadLine());

                            campaignManager.UpdateCampaign(campaign);
                            ListCampaigns(campaignManager);
                        }
                        else
                        {
                            Console.WriteLine("No such campaign exists!!");
                        }
                    }
                    break;
                case ConsoleKey.D:
                    {
                        Console.WriteLine();
                        Console.Write("Campaign Id : ");

                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            var campaign = campaignManager.GetCampaign(id);
                            if (campaign != null)
                            {
                                campaignManager.DeleteCampaign(campaign);
                                ListCampaigns(campaignManager);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No such campaign exists!!");
                        }
                    }
                    break;
                case ConsoleKey.M:
                    {
                        Console.WriteLine("");
                        MainMenu();
                    }
                    break;
                default:
                    break;
            }

        }

        private static void ListCampaigns(CampaignManager campaignManager)
        {
            foreach (var campaign in campaignManager.GetAllCampaigns())
            {
                Console.WriteLine("{0} - {1} - {2}", campaign.Id, campaign.CampaignName, campaign.Description);
            }
        }
    }
}
