using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqExamples {
    class Customer {
        public string Identifier;
        public int Points;
        public override string ToString() {
            return "Identifier (" + Identifier + ") Points (" + Points + ")";
        }
        public override bool Equals(object obj) {
            if (obj is Customer) {
                Customer otherObj = obj as Customer;
                if (otherObj.Points == Points &&
                    otherObj.Identifier.CompareTo(Identifier) == 0) {
                    return true;
                }
            }
            return false;
        }
        public override int GetHashCode() {
            return Points * Identifier.GetHashCode();
        }
    }

    class Program {
        static List<Customer> CreateList() {
            List<Customer> customers =
                    new List<Customer>() {
                new Customer {
                    Identifier = "Person 1",
                    Points = 0
                },
                new Customer {
                    Identifier = "Person 2",
                    Points = 10
                }
            };
            return customers;
        }
        static void Example01() {
            List<Customer> customers = CreateList();
            var points = (from customer in customers
                          where customer.Points > 5
                          select customer).Select(
                         (pCustomer, index) => {
                             pCustomer.Points += 5;
                             return pCustomer;
                         });
        }
        static void Example02() {
            List<Customer> customers = CreateList();
            var points = (from customer in customers
                          where customer.Points > 5
                          select customer).Select(
                         (customer, index) => {
                             customer.Points += 5;
                             return new {
                                 identifier = customer.Identifier,
                                 points = customer.Points
                             };
                         });
        }
        static void Example03() {
            int[] set1 = { 1, 2, 3, 4, 5 };
            int[] set2 = { 1, 2, 3, 4, 5 };
            int[] set3 = { 1, 2, 3, 4, 5 };

            var triples =
                from a in set1
                from b in set2
                from c in set3
                select new { a, b, c };
        }
        static void Example04() {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords =
                from w in words
                orderby w
                select w;
        }
        static void Example05() {
            List<Customer> customers = CreateList();
            var groupedCustomers =
                from customer in customers
                group customer by customer.Points > 5 into rewarded
                select new { ShouldReward = rewarded.Key, Customers = rewarded };
        }
        static void Example06() {
            List<Customer> customers1 =
                    new List<Customer>() {
                        new Customer {
                            Identifier = "Person 1",
                            Points = 0
                        },
                        new Customer {
                            Identifier = "Person 2",
                            Points = 10
                        }
                    };
            List<Customer> customers2 =
                    new List<Customer>() {
                        new Customer {
                            Identifier = "Person 3",
                            Points = 20
                        },
                        new Customer {
                            Identifier = "Person 2",
                            Points = 10
                        }
                    };
            var uniqueCustomers = customers1.Union(customers2);
        }
        static void Main(string[] args) {
            Example01();
            Example02();
            Example03();
            Example04();
            Example05();
            Example06();
        }
    }
}
