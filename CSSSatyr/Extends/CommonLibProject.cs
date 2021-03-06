﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CSSSatyr.Extends
{
    /// <summary>
    /// TODO: 完善项目管理操作
    /// </summary>
    public static partial class CommonLib
    {
        /// <summary>
        /// 创建新项目
        /// </summary>
        /// <param name="listView1"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ListViewGroup CreateNewProject(ListView listView1, string name= "New project")
        {
            listView1.Clear();
            //新建一个项目
            ListViewGroup _defaultGroup = new ListViewGroup();
            _defaultGroup.Header = name;
            _defaultGroup.HeaderAlignment = HorizontalAlignment.Center;
            listView1.Groups.Add(_defaultGroup);
            return _defaultGroup;
        }
    }
}
