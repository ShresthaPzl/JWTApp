using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel(){
                UserName = "Pzl", EmailAddress = "pzlshrestha7@gmail.com", Password = "ItsPassword1",
                Surname = "Shrestha", GivenName ="PraJwol", Role = "Administrator"
            },
            new UserModel(){
                UserName = "Pzl1", EmailAddress = "pzl1shrestha7@gmail.com", Password = "ItsPassword11",
                Surname = "Shrestha1", GivenName ="PraJwol1", Role = "Guest"
            },
        };
    }
}
