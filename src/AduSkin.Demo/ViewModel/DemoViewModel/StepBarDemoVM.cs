using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input; 
using System.Collections.ObjectModel; 

namespace AduSkin.Demo.ViewModel.DemoViewModel
{
   public partial class StepBarDemoVM : ObservableObject
   {
      public StepBarDemoVM()
      {
         StepItems.Add("第一步");
         StepItems.Add("第二步");
         StepItems.Add("第三步");
         StepItems.Add("第四步"); 
      }
      private ObservableCollection<string> _StepItems = new ObservableCollection<string>();
      /// <summary>
      /// 步骤
      /// </summary>
      public ObservableCollection<string> StepItems
      {
         get { return _StepItems; }
         set
         {
            _StepItems = value;
            OnPropertyChanged("StepItems");
         }
      }
      private int _StepIndex;
      /// <summary>
      /// 属性
      /// </summary>
      public int StepIndex
      {
         get { return _StepIndex; }
         set
         {
            _StepIndex = value;
            OnPropertyChanged("StepIndex");
         }
      } 
      [RelayCommand]
      public void Next(string e)
      {
         if (StepIndex >= StepItems.Count)
            return;
         StepIndex += 1;
      }
      [RelayCommand]
      public void Up(string e)
      {
         if (StepIndex > 0)
         {
            StepIndex -= 1;
         } 
      }
   }
}
