using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDD_111_1082.Tools
{
   public enum UserManagementEnum
        {
            Delete = 1,
            Update = 2,
            Select = 3,
            Exit = 4
        }
   public enum LoginManagementEnum
   {
       Login = 1,
       Register = 2,
       Exit = 3
   }
   public enum MailManagementEnum
   {
       SendMessage = 1,
       Inbox = 2,
       ViewUsers = 3,
       Exit = 4
   }
}
