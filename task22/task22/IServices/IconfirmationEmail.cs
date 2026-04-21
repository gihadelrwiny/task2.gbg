using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.Models;

namespace task22.IServices
{
  public interface IconfirmationEmail
    {
        public void SendConfirmationEmail(Order order );
    }
}
