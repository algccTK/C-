using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using System.IO;//Rename

namespace _004_WPF_Practice2
{
    class Rename
    {
        public Rename(List<string> mkvlist, List<string> asslist, string path)
        {
            
            foreach (string item in asslist)
            {
                string re = "^.*[^0-9A-Za-z]\\(d{2})[^0-9A-Za-z].*\\.(\\w)$";
                var aa = Regex.Match(item, re);
                string willRename="";
                string re2 = string.Format("(^.*[^0-9A-Za-z]{0}[^0-9A-Za-z].*\\).\\w$", aa.Groups[1].ToString());
                foreach (var mkvitem in mkvlist)
                {
                    if (Regex.IsMatch(mkvitem, re2))
                    {
                        var aa2 = Regex.Match(item, re2);
                        willRename = aa2.Groups[1].ToString() + "." + aa.Groups[2].ToString();
                        break;
                    }
                }
                string sourceFileName = path + "\\" + item;
                string destFileName = path + "\\" + willRename;
                File.Move(sourceFileName, destFileName);
            }
        }
    }
}
