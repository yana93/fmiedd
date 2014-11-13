using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDD_111_1082.Entity;
using EDD_111_1082.Repository;
using EDD_111_1082.Tools;
using System.Threading;

namespace EDD_111_1082.Presentation
{
    class MailView
    {
        public string LoggedUser { get; set; }
      
        public MailView(string loggedUser)
        {
            this.LoggedUser = loggedUser;
            while (true)
            {
                MailManagementEnum choice = RenderMenu();
                switch (choice)
                {
                    case MailManagementEnum.SendMessage: { SendMessage(); break; }
                    case MailManagementEnum.Inbox: { ViewInbox(); break; }
                    case MailManagementEnum.ViewUsers: { ViewOtherUsers(); break; }
                    case MailManagementEnum.Exit: { return; }
                }
            }
        }
        private MailManagementEnum RenderMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("C-Mail Menu");
                Console.WriteLine("1.Send message");
                Console.WriteLine("2.Inbox");
                Console.WriteLine("3.View users");
                Console.WriteLine("4.Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": { return MailManagementEnum.SendMessage; }
                    case "2": { return MailManagementEnum.Inbox; }
                    case "3": { return MailManagementEnum.ViewUsers; }
                    case "4": { return MailManagementEnum.Exit; }
                    default:
                        {
                            Console.WriteLine("Invalid choice.");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }
        #region Functional Methods
        private void SendMessage()
        {            
            while(true)
            {
                MailRepository mrepo = new MailRepository();
                Message message1 = new Message();
                Console.Clear();
                message1.Sender = LoggedUser;
                Console.WriteLine("Reciever username:");
                message1.Reciever = Console.ReadLine();                
                
               Console.WriteLine("Message:");
                message1.Messages = Console.ReadLine();
                if(message1.Sender!=null&&message1.Reciever!=null)
                { 
                   int sent= mrepo.InsertMail(message1);
                   if (sent > 0)
                   {
                       Console.WriteLine("Message successfully sent!");
                       Thread.Sleep(1500);
                       break;
                   }
                   else
                   {
                       Console.WriteLine("Invalid reciever/operation!Failed sending message!");                       
                       Console.ReadKey(true);
                   }
                }
                else
                {
                    Console.WriteLine("Invalid sender or reciever!");
                    Console.ReadKey(true);                
                }
            }
        }
        private void ViewInbox()
        {
            MailRepository mrepo = new MailRepository();
            try
            {
                List<Message> mailbox=mrepo.RetrieveMail(LoggedUser);
                foreach (Message m in mailbox)
                {
                    Console.WriteLine("{0} from: {1} || to: {2} || Message {3} ", m.ID, m.Sender, m.Reciever, m.Messages);
                }
                if (mailbox.Count<=0)
                {
                    Console.WriteLine("You don't have any messages in your inbox yet.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ooops! Something went wrong!Error: {0}", e.Message);
            }
            Console.ReadKey(true);
        }
        private void ViewOtherUsers()
        {
            UserRepository urepo = new UserRepository();
            try
            {
                urepo.Retrieve(LoggedUser);
                foreach (User u in urepo.Retrieve(LoggedUser))
                {
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4}", u.ID, u.Firstname, u.Lastname, u.Username, u.Password);
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine("Ooops! Something went wrong!Error: {0}", e.Message);
            }
            Console.ReadKey(true);
            
        }
        #endregion
    }
}
