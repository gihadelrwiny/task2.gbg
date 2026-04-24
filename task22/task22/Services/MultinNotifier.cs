using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using task22.interfaces.IServices;

namespace task22.Services
{
  public class MultinNotifier: INotifier
    {
       private readonly List<INotifier> notifiers;
        public MultinNotifier(List<INotifier> notifiers)
        {
            this.notifiers = notifiers;
        }
       
        void INotifier.Notify(string message)
        {
            foreach (var notifier in notifiers)
            {
                notifier.Notify(message);
            }
        }
    }
}
