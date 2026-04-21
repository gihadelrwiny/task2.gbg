using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using task22.IServices;
using task22.Models;

namespace task22.Services
{
    internal class HandleOrder : Ihandelorder
    {
        private readonly IorderProcess _orderProcess;
        private readonly ISaveOrder _saveOrder;
        private readonly IconfirmationEmail _confirmationEmail;
        private readonly IgenerateInvoid _generateInvoid;
        public HandleOrder(IorderProcess orderProcess, ISaveOrder saveOrder, IconfirmationEmail confirmationEmail, IgenerateInvoid generateInvoid)
        {
            _orderProcess = orderProcess;
            _saveOrder = saveOrder;
            _confirmationEmail = confirmationEmail;
            _generateInvoid = generateInvoid;
        }

        public void handleorder(Order order)
        {
            try
            {
                Console.WriteLine($" Processing Order {order.Id}");

                _orderProcess.ProcessOrder(order);

                _saveOrder.saveOrder(order);

                string inv = _generateInvoid.GenerateInvoid(order);
                Console.WriteLine(inv);

              _confirmationEmail.SendConfirmationEmail(order);

                Console.WriteLine($" Order {order.Id} completed");
                Console.WriteLine("-------------------------------------");
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"[VALIDATION ERROR] Order {order.Id}: {ex.Message}");
                Console.WriteLine("-------------------------------------");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[INPUT ERROR] Order {order.Id}: {ex.Message}");
                Console.WriteLine("-------------------------------------");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"[BUSINESS ERROR] Order {order.Id}: {ex.Message}");
                Console.WriteLine("-------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UNKNOWN ERROR] Order {order.Id}: {ex.Message}");
                Console.WriteLine("-------------------------------------");
            }
        }
    }
}
