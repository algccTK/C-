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

        private int nowdisaplyindex;//當前索引
        
        

        private void button1_Click(object sender, RoutedEventArgs e)//
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
            smalltree();
            OpenNeedTree(FindResultList[0]);
            FindResultList[0].IsSelected = true;
            nowdisaplyindex = 0;

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void previous_button2_Click(object sender, RoutedEventArgs e)//前一個按钮
        {
            smalltree();
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
        }

        private void next_button3_Click(object sender, RoutedEventArgs e)//後一個按钮
        {
            smalltree();
            int showindex = 0;
            if (nowdisaplyindex == FindResultList.Count-1)
            {
                MessageBox.Show("之前已經是最後一個，跳轉到第一個");
            }
            else showindex = nowdisaplyindex + 1;
            OpenNeedTree(FindResultList[showindex]);
            FindResultList[showindex].IsSelected = true;
            nowdisaplyindex = showindex;

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

        private void smalltree()//節點全部收縮函數，網上得到，裡面寫死了控件名稱
        {
            foreach (var item in treeView2.Items)//treeView2是控件名稱
            {
                DependencyObject dObject = treeView2.ItemContainerGenerator.ContainerFromItem(item);//treeView2是控件名稱
                CollapseTreeviewItems(((TreeViewItem)dObject));
            }  
        }

        private void CollapseTreeviewItems(TreeViewItem Item)//節點全部收縮展開所需函數，網上得到，裡面寫死了控件名稱
        {
            Item.IsExpanded = false;

            foreach (var item in Item.Items)
            {
                DependencyObject dObject = treeView2.ItemContainerGenerator.ContainerFromItem(item);//treeView2是控件名

                if (dObject != null)
                {
                    ((TreeViewItem)dObject).IsExpanded = false;

                    if (((TreeViewItem)dObject).HasItems)
                    {
                        CollapseTreeviewItems(((TreeViewItem)dObject));
                    }
                }
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

        #endregion

        

        

        
    }
}
