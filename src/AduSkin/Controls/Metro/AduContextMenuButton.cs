using System.Windows.Controls;


namespace AduSkin.Controls.Metro
{
    /// <summary>
    ///     带上下文菜单的按钮
    /// </summary>
    public class AduContextMenuButton : AduPathIconButton
   {
        public MetroContextMenu Menu { get; set; }

        protected override void OnClick()
        {
            base.OnClick();
            if (Menu != null)
            {
                Menu.PlacementTarget = this;
                Menu.IsOpen = true;
            }
        }
    }
}