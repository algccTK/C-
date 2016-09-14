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
using System.Windows.Shapes;

using System.Collections.ObjectModel;

using System.Text.RegularExpressions;

using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Window11.xaml 的交互逻辑
    /// </summary>
    public partial class Window11 : Window
    {
        public Window11()
        {
            InitializeComponent();
        }

        private List<TreeViewItem> FindResultList = new List<TreeViewItem>();

        private int nowdisaplyindex = 0; //當前索引

        private int result_count//總數
        {
            get { return FindResultList.Count; }
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)//查詢文本
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)//查
        {
            /*不展開可以選中
             * 選中不會自動展開
             * 滾動條不會自動到選中的位置，貌似可以通過設置滾動條的值實現
             * 用 is  TreeViewItem;來判斷是不是根節點
             * 用 a.Items.Count 判斷末節點
             */

            FindResultList.Clear();

            FindItemJoinList(treeView2);

            if (FindResultList.Count == 0)
            {
                MessageBox.Show("無符合結果");
                return;
            }
            smalltree(treeView2);
            OpenNeedTree(FindResultList[0]);
            FindResultList[0].IsSelected = true;
            nowdisaplyindex = 0;

            //顯示個數
            label1.Content = nowdisaplyindex+1;
            label3.Content = result_count;


        }

        private void previous_button2_Click(object sender, RoutedEventArgs e)//前一個按钮
        {
            smalltree(treeView2);
            int showindex = 0;
            if (nowdisaplyindex == 0)
            {
                MessageBox.Show("之前已經是第一個，跳轉到最後一個");
                showindex = FindResultList.Count - 1;
            }
            else showindex = nowdisaplyindex - 1;
            OpenNeedTree(FindResultList[showindex]);
            FindResultList[showindex].IsSelected = true;
            nowdisaplyindex = showindex;

            //顯示個數
            label1.Content = nowdisaplyindex+1;
        }

        private void next_button3_Click(object sender, RoutedEventArgs e)//後一個按钮
        {
            smalltree(treeView2);
            int showindex = 0;
            if (nowdisaplyindex == FindResultList.Count-1)
            {
                MessageBox.Show("之前已經是最後一個，跳轉到第一個");
            }
            else showindex = nowdisaplyindex + 1;
            OpenNeedTree(FindResultList[showindex]);
            FindResultList[showindex].IsSelected = true;
            nowdisaplyindex = showindex;

            //顯示個數
            label1.Content = nowdisaplyindex+1;

        }

        private void filedrop(object sender, DragEventArgs e)//拖放文件
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string   line,drive_letter;
            

            //讀TXT
            StreamReader sr = new StreamReader(files[0], Encoding.UTF8);//編碼可不用，會自動識別

            line = sr.ReadLine();
            drive_letter = line.Substring(0, 1);//盤符
            TreeViewItem Tree = new TreeViewItem() { Header = drive_letter };//建樹的根
            BuildTree(Tree, StrPathToList(line), 1);//這裡已把第一行加入樹

            while ((line = sr.ReadLine()) != null)//逐行讀取
            {
                BuildTree(Tree, StrPathToList(line), 1);
            }
            sr.Close();

            treeView2.Items.Add(Tree);

        }


        

        #region 功能函數

        private void FindItemJoinList(ItemsControl item)//遞歸搜索符合的末端加入FindResultList
        {
            if (item is TreeViewItem)
            {
                TreeViewItem tviCurrent = item as TreeViewItem;
                if (tviCurrent.Items.Count == 0 )//末節點
                {
                    
                    if (tviCurrent.Header.ToString() == null) return;
                    else if (tviCurrent.Header.ToString().Contains(textBox1.Text))//符合
                    {
                        FindResultList.Add(tviCurrent);
                    }
                    return ;
                }
                //展開子節點
                tviCurrent.IsExpanded = true;
                tviCurrent.UpdateLayout();
            }
            
            for (int i = 0; i < item.Items.Count; i++)
            {
                TreeViewItem subContainer = (TreeViewItem)item.ItemContainerGenerator.ContainerFromIndex(i);

                if (null == subContainer)
                {
                    continue;
                }
                FindItemJoinList(subContainer);
            }
            return ;
        }

        private void smalltree(ItemsControl item)//節點全部收縮
        {
            for (int i = 0; i < item.Items.Count; i++)
            {
                TreeViewItem tviCurrent = (TreeViewItem)item.ItemContainerGenerator.ContainerFromIndex(i);
                
                if (tviCurrent == null) continue;
                
                if ( tviCurrent.Parent is TreeViewItem)//判斷是否到了根節點
                {
                    TreeViewItem tvipCurrent = tviCurrent.Parent as TreeViewItem;
                    tvipCurrent.IsExpanded = false;
                }
                smalltree(tviCurrent);
            }
           
           


        }

        private void OpenNeedTree(TreeViewItem item)//展開搜索所在的
        {
            if (item.Parent is TreeViewItem)
            {
                TreeViewItem tviCurrent = item.Parent as TreeViewItem;
                tviCurrent.IsExpanded = true;
                OpenNeedTree(tviCurrent);
            }
            else return;
        }

        private void BuildTree(TreeViewItem treeitem, List<string> strlist, int listindex)//建樹
        {
            if (listindex > strlist.Count-1) return;
            TreeViewItem willadd = new TreeViewItem() { Header =strlist[listindex]  };
            bool alreadyhave = false;

            //treeitem.IsExpanded = true;
            //treeitem.UpdateLayout();
            foreach (TreeViewItem treehaveitem in treeitem.Items)//判斷是否已存在
            {
                if (treehaveitem.Header.ToString() == strlist[listindex])
                {
                    alreadyhave = true;
                    willadd = treehaveitem;
                    break;
                }
            }
            if (!alreadyhave)//沒有就添加
            {
                treeitem.Items.Add(willadd);
            }
            BuildTree(willadd, strlist, listindex + 1);
        }

        private List<string> StrPathToList(string path) //str路徑處理
        {
            List<string> lt = new List<string>();
            lt.Add(path.Substring(0, 1) );
            MatchCollection foloders = Regex.Matches(path, @"(?<=\\).*?(?=\\)");
            foreach (Match item in foloders)
            {
                lt.Add(item.ToString());
            }
            Match a = Regex.Match(path, @"^.*\\(.*?)$");
            lt.Add(a.Groups[1].ToString());

            return lt;

        }

        

        #endregion

        //private void button2_Click_1(object sender, RoutedEventArgs e) //遞歸建樹測試成功
        //{
        //    //D:\qpapp\beta\cliconfg.rll
        //    //D:\qpapp\beta\curllib.dll
        //    //D:\qpapp\beta\bmp\2.bmp
        //    List<string> afilepath = new List<string>();
        //    afilepath.Add("D");
        //    afilepath.Add("qpapp");
        //    afilepath.Add("beta");
        //    afilepath.Add("cliconfg.rll");

        //    List<string> bfilepath = new List<string>();
        //    bfilepath.Add("D");
        //    bfilepath.Add("qpapp");
        //    bfilepath.Add("beta");
        //    bfilepath.Add("curllib.dll");

        //    List<string> cfilepath = new List<string>();
        //    cfilepath.Add("D");
        //    cfilepath.Add("qpapp");
        //    cfilepath.Add("beta");
        //    cfilepath.Add("bmp");
        //    cfilepath.Add("2.bmp");

        //    TreeViewItem oo = new TreeViewItem() { Header = afilepath[0] };
        //    BuildTree(oo, afilepath, 1);
        //   // treeView1.Items.Add(oo);
        //    BuildTree(oo, bfilepath, 1);
        //    //treeView1.Items.Add(oo);
      
        //    BuildTree(oo, cfilepath, 1);
        //    treeView1.Items.Add(oo);
        //}

        

        



        

        

        
    }
}
