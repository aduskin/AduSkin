using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{

    public class AduDataGrid : DataGrid
    {
        public AduDataGrid()
        {
            Utility.Refresh(this);
        }

        static AduDataGrid()
        {
            ElementBase.DefaultStyle<AduDataGrid>(DefaultStyleKeyProperty);
        }

        #region AduSkin
        #endregion
    }
}