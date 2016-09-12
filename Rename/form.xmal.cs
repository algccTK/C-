using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Text.RegularExpressions;

namespace _004_WPF_Practice2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string path;
        private List<string> mkvlist = new List<string>();
        private List<string> asslist = new List<string>();
             

        private void mkv_Drop(object sender, DragEventArgs e)//拖MKV
        {
            mkv_listBox1.Items.Clear();//拖動清原有的
            mkvlist.Clear();//拖動清原有的

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var aa =  Regex.Match(files[0],@"^(.*)\\.*$" );
            path = aa.Groups[1].ToString();
            foreach (string item in files)
            {
                var aa2 = Regex.Match(item, @"^.*\\(.*$)");
                mkvlist.Add(aa2.Groups[1].ToString());
                mkv_listBox1.Items.Add(aa2.Groups[1].ToString());
            }
        }

        private void ass_Drop(object sender, DragEventArgs e)//拖ASS
        {
            ass_listBox1.Items.Clear();//拖動清原有的
            asslist.Clear();//拖動清原有的

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var aa = Regex.Match(files[0], @"^(.*)\\.*$");
            path = aa.Groups[1].ToString();
            foreach (string item in files)
            {
                var aa2 = Regex.Match(item, @"^.*\\(.*$)");
                asslist.Add(aa2.Groups[1].ToString());
                ass_listBox1.Items.Add(aa2.Groups[1].ToString());
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Rename a = new Rename(mkvlist, asslist, path);
            
        }
        



        


            


        

        
    }
}
/*
.py改成.pyw
import datetime, calendar  
import time
def IsSunday():
    dayofweek = datetime.today().weekday() #获取的为当前系统时间,返回的是0-6是星期一到星期日
    if dayofweek==0 :return true
    else :return false

def alreadydo():#已執行過
    1
time.sleep( 3600 )#參數是秒
if IsSunday() and not alreadydo():
*/
