using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BizApp.model.UserModel;

namespace BizApp.viewmodel
{
    public class LoginViewModel: ViewmodelBase
    {
        public LoginViewModel()
        {
            _userList = App.DataAccess.GetUsers();
            _msgText = "For these original demo names, the password is 1234";
        }

        private List<User> _userList;

        public List<User> UserList
        {
            get { return _userList; }
            set { _userList = value;
                NotifyPropertyChanged("UserList");
            }
        }

        private User _selectedUser;

        public User SelectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser = value;
                if (value != null)
                {
                    CanLogin = true;
                   
                }
                else
                {
                    CanLogin = false;
                }
                NotifyPropertyChanged("SelectedUser");
            }
        }

        private bool _canLogin;

        public bool CanLogin
        {
            get { return _canLogin; }
            set { _canLogin = value;
                NotifyPropertyChanged("CanLogin");
            }
        }



        private string _msgText;
        
         public string MsgText {
            get { return _msgText; }

            set { _msgText = value;
                NotifyPropertyChanged("MsgText");
            }
        }

        public bool AuthenticateUser(string Username, string Password)
        { 
            //call our authentication service residing in our LoginModel
           return model.LoginModel.AuthenticateUser(Username, Password);
            
        }


    }
}


