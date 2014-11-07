using WebFormsCrudLocalDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsCrudLocalDb
{
    public partial class _Default : Page
    {
        UserRepository repo = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public ICollection<User> GetData()
        {
            return repo.Read();
        }
    }
}