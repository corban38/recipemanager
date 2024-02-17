using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipemanager
{
    internal static class STextFormat
    {
        public static string ToFirstCharUpper(string _s_)
        {
            if (string.IsNullOrEmpty(_s_)) return _s_;
            string result_ = _s_.ToLower();
            return result_.Substring(0, 1).ToUpper() + result_.Substring(1);
        }


    }
}
