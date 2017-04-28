using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizApp.viewmodel
{
    public class LoginViewModel: ViewmodelBase
    {private string _msgText;
        
         public string MsgText {
            get { return _msgText; }

            set { _msgText = value;
                NotifyPropertyChanged("MsgText");
            }

        }
    }
}


