using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace AduSkin.Controls.Helper
{
    public static class VisualHelper
    {
        /// <summary>
        /// 查找元素的子元素
        /// </summary>
        /// <typeparam name="T">子元素类型</typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        /// <summary>
        /// 得到指定元素的集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        /// <summary>
        /// 利用visualtreehelper寻找对象的子级对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<T> FindVisualChildrenEx<T>(DependencyObject obj) where T : DependencyObject
        {
            try
            {
                List<T> TList = new List<T> { };
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                    if (child != null && child is T)
                    {
                        TList.Add((T)child);
                        List<T> childOfChildren = FindVisualChildrenEx<T>(child);
                        if (childOfChildren != null)
                        {
                            TList.AddRange(childOfChildren);
                        }
                    }
                    else
                    {
                        List<T> childOfChildren = FindVisualChildrenEx<T>(child);
                        if (childOfChildren != null)
                        {
                            TList.AddRange(childOfChildren);
                        }
                    }
                }
                return TList;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 查找元素的父元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i_dp"></param>
        /// <returns></returns>
        public static T FindParent<T>(DependencyObject i_dp) where T : DependencyObject
        {
            DependencyObject dobj = (DependencyObject)VisualTreeHelper.GetParent(i_dp);
            if (dobj != null)
            {
                if (dobj is T)
                {
                    return (T)dobj;
                }
                else
                {
                    dobj = FindParent<T>(dobj);
                    if (dobj != null && dobj is T)
                    {
                        return (T)dobj;
                    }
                }
            }
            return null;
        }

        public static T FindParent<T>(DependencyObject i_dp, string elementName) where T : DependencyObject
        {
            DependencyObject dobj = (DependencyObject)VisualTreeHelper.GetParent(i_dp);
            if (dobj != null)
            {
                if (dobj is T && ((System.Windows.FrameworkElement)(dobj)).Name.Equals(elementName))
                {
                    return (T)dobj;
                }
                else
                {
                    dobj = FindParent<T>(dobj);
                    if (dobj != null && dobj is T)
                    {
                        return (T)dobj;
                    }
                }
            }
            return null;
        }

        public static IntPtr GetHandle(this Visual visual)
        {
            return (PresentationSource.FromVisual(visual) as HwndSource)?.Handle ?? IntPtr.Zero;
        }

        /// <summary>
        /// 查找指定名称的元素
        /// </summary>
        /// <typeparam name="childItem">元素类型</typeparam>
        /// <param name="obj"></param>
        /// <param name="elementName">元素名称，及xaml中的Name</param>
        /// <returns></returns>
        public static childItem FindVisualElement<childItem>(DependencyObject obj, string elementName) where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem && ((System.Windows.FrameworkElement)(child)).Name.Equals(elementName))
                    return (childItem)child;
                else
                {
                    IEnumerator j = FindVisualChildren<childItem>(child).GetEnumerator();
                    while (j.MoveNext())
                    {
                        childItem childOfChild = (childItem) j.Current;
                        
                        if (childOfChild != null && !(childOfChild as FrameworkElement).Name.Equals(elementName))
                        {
                            FindVisualElement<childItem>(childOfChild, elementName);
                        }
                        else
                        {
                            return childOfChild;
                        }
                        
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 命中测试。根据当前选中元素，查找视觉树父节点与子节点，看是否存在指定类型的元素
        /// </summary>
        /// <typeparam name="T">想命中的元素类型</typeparam>
        /// <param name="dp">当前选中元素</param>
        /// <returns>true：命中成功</returns>
        public static bool HitTest<T>(DependencyObject dp) where T : DependencyObject
        {
            return FindParent<T>(dp) != null || FindVisualChild<T>(dp) != null;
        }

        public static T FindEqualElement<T>(DependencyObject source, DependencyObject element) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(source); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(source, i);
                if (child != null && child is T && child == element)
                {
                    return (T)child;
                }
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                        
                }
            }
            return null;
        }
    }
}
