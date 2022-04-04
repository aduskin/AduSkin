using AduSkin.Controls.Helper;
using System.Drawing;
using System.Windows;
using System.Windows.Media;

namespace AduSkin.Themes.Metro
{
   /// <summary>
   /// AduMessageBoxWindow.xaml 的交互逻辑
   /// </summary>
   internal partial class AduMessageBoxWindow : Window
   {
      internal string Caption
      {
         get
         {
            return Win_Title.Text;
         }
         set
         {
            Win_Title.Text = value;
         }
      }

      internal string Message
      {
         get
         {
            return TextBlock_Message.Text;
         }
         set
         {
            TextBlock_Message.Text = value;
         }
      }

      internal string OkButtonText
      {
         get
         {
            return Label_Ok.Content.ToString();
         }
         set
         {
            Label_Ok.Content = value.TryAddKeyboardAccellerator();
         }
      }

      internal string CancelButtonText
      {
         get
         {
            return Label_Cancel.Content.ToString();
         }
         set
         {
            Label_Cancel.Content = value.TryAddKeyboardAccellerator();
         }
      }

      internal string YesButtonText
      {
         get
         {
            return Label_Yes.Content.ToString();
         }
         set
         {
            Label_Yes.Content = value.TryAddKeyboardAccellerator();
         }
      }

      internal string NoButtonText
      {
         get
         {
            return Label_No.Content.ToString();
         }
         set
         {
            Label_No.Content = value.TryAddKeyboardAccellerator();
         }
      }

      public MessageBoxResult Result { get; set; }

      internal AduMessageBoxWindow(string message)
      {
         InitializeComponent();

         Message = message;
         Image_MessageBox.Visibility = System.Windows.Visibility.Collapsed;
         DisplayButtons(MessageBoxButton.OK);
      }

      internal AduMessageBoxWindow(string message, string caption)
      {
         InitializeComponent();

         Message = message;
         Caption = caption;
         Image_MessageBox.Visibility = System.Windows.Visibility.Collapsed;
         DisplayButtons(MessageBoxButton.OK);
      }

      internal AduMessageBoxWindow(string message, string caption, MessageBoxButton button)
      {
         InitializeComponent();

         Message = message;
         Caption = caption;
         Image_MessageBox.Visibility = System.Windows.Visibility.Collapsed;

         DisplayButtons(button);
      }

      internal AduMessageBoxWindow(string message, string caption, MessageBoxImage image)
      {
         InitializeComponent();

         Message = message;
         Caption = caption;
         DisplayImage(image);
         DisplayButtons(MessageBoxButton.OK);
      }

      internal AduMessageBoxWindow(string message, string caption, MessageBoxButton button, MessageBoxImage image)
      {
         InitializeComponent();

         Message = message;
         Caption = caption;
         Image_MessageBox.Visibility = System.Windows.Visibility.Collapsed;

         DisplayButtons(button);
         DisplayImage(image);
      }

      private void DisplayButtons(MessageBoxButton button)
      {
         switch (button)
         {
            case MessageBoxButton.OKCancel:
               // Hide all but OK, Cancel
               Button_OK.Visibility = System.Windows.Visibility.Visible;
               Button_OK.Focus();
               Button_Cancel.Visibility = System.Windows.Visibility.Visible;

               Button_Yes.Visibility = System.Windows.Visibility.Collapsed;
               Button_No.Visibility = System.Windows.Visibility.Collapsed;
               break;
            case MessageBoxButton.YesNo:
               // Hide all but Yes, No
               Button_Yes.Visibility = System.Windows.Visibility.Visible;
               Button_Yes.Focus();
               Button_No.Visibility = System.Windows.Visibility.Visible;

               Button_OK.Visibility = System.Windows.Visibility.Collapsed;
               Button_Cancel.Visibility = System.Windows.Visibility.Collapsed;
               break;
            case MessageBoxButton.YesNoCancel:
               // Hide only OK
               Button_Yes.Visibility = System.Windows.Visibility.Visible;
               Button_Yes.Focus();
               Button_No.Visibility = System.Windows.Visibility.Visible;
               Button_Cancel.Visibility = System.Windows.Visibility.Visible;

               Button_OK.Visibility = System.Windows.Visibility.Collapsed;
               break;
            default:
               // Hide all but OK
               Button_OK.Visibility = System.Windows.Visibility.Visible;
               Button_OK.Focus();

               Button_Yes.Visibility = System.Windows.Visibility.Collapsed;
               Button_No.Visibility = System.Windows.Visibility.Collapsed;
               Button_Cancel.Visibility = System.Windows.Visibility.Collapsed;
               break;
         }
      }

      private void DisplayImage(MessageBoxImage image)
      {
         string Icon = null;
         switch (image)
         {
            case MessageBoxImage.Exclamation:       // Enumeration value 48 - also covers "Warning"
               Icon = "M514.63547095 64.50557607c-245.79772937 0-445.80505747 199.97978336-445.80505745 445.7795534 0 245.85077718 200.0073271 445.85810529 445.80505745 445.85810529 245.79875019 0 445.80505747-200.0073271 445.80505749-445.85810529C960.44052743 264.48535941 760.43422017 64.50557607 514.63547095 64.50557607zM572.44016637 798.25683382c-13.74446534 14.26678179-31.36753754 21.5057584-52.45401459 21.50575839-22.03113538 0-40.59886489-7.55216231-55.33899569-22.3453409-14.635056-14.79113893-22.03113538-32.5213256-22.03113537-52.66416523 0-19.46035985 6.87172326-35.87659514 20.50907311-48.78045812 17.93931743-17.04770793 36.61314256-25.70265117 55.39102367-25.70265118 20.40399732 0 38.08011732 7.3960794 52.55909039 21.92605961 14.58200819 14.47693239 21.92503973 32.31117502 21.92503974 53.08242667C593.00126648 766.25884451 586.0785361 784.14613494 572.44016637 798.25683382zM592.89721153 384.50077378l-26.12091168 136.06541617c-6.82071513 41.07119406-14.47693239 74.6932599-22.7656421 99.76545928l-0.94363748 3.04208384c0 0-8.28768988 0.42030118-11.59195128 0.42030118l-41.91077658-0.21015058-35.51138249-160.14195009c-12.43153382-62.47187666-20.40501816-106.16587322-24.39175932-133.59971641-2.09844638-17.73018767-3.09411183-30.84216056-3.09411182-39.34000105 0-2.51772771 0.7865347-7.92043552 2.5697547-16.10407044 1.5730694-17.57104421 8.39276469-31.21043477 20.24689454-40.23263136 11.43484853-8.60291527 27.48587116-13.74242565 47.89088833-15.21144013 10.85846444-1.67916503 18.25454379-2.57077553 21.55880619-2.57077552 23.28897839 0 43.22064757 6.03214073 59.16761426 17.99236524 16.4713238 12.27341122 24.75799285 29.68837249 24.75799287 51.87661064C602.75797079 305.71467607 599.50675619 337.81672134 592.89721153 384.50077378z";
               Image_MessageBox.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 153, 0));
               break;
            case MessageBoxImage.Error:             // Enumeration value 16, also covers "Hand" and "Stop"
               Icon = "M881.510752 573.386092c-15.745612-6.138814-21.400403-6.851035-48.313356-8.439206-26.912953-1.588171-31.004131 0.221034-59.474556 2.077312-128.870066 0.884137-257.154801 16.884552-382.724705 47.590901-80.273255 19.629059-159.52218 45.809325-235.43001 78.411861-48.994877 21.038152-57.654095 69.491701-15.294334 103.485933 50.149167 40.246633 118.762871-8.394181 164.725692-31.022551 78.463026-38.626739 315.544653-119.546723 404.01766-135.841851 99.574856-18.339694 186.075953-8.589632 187.662077-32.692586C894.074905 591.861886 897.256364 579.524906 881.510752 573.386092z M912.098397 578.64077c-23.939225 14.811334 6.349615 37.685297 27.733645 32.69975 25.548886-5.955642 18.216897-25.934672-0.203638-34.332946C929.971463 572.610426 919.367965 574.147432 912.098397 578.64077 M271.709285 387.416564c19.113313-8.293897 38.860053-15.419178 57.628512-24.099884 26.979468-12.481266 54.486962-30.454616 58.508555-62.534242 4.055362-32.310893-16.281825-58.32743-43.281759-73.349565-64.283072-35.768645-136.454812-2.146896-194.184631 30.063713-30.356378 16.941857-53.135174 43.911092-66.342987 75.990718-34.590819 83.989903-7.642051 197.990307 18.917862 254.121721 18.296715 38.675858 60.662615 56.901964 101.754498 55.561433 22.150486-0.723477 45.067428-6.814196 65.925479-13.956873 13.036921-4.461615 25.762757-9.830903 38.068014-16.030092 6.14393-3.099594 12.186554-6.405897 18.096147-9.934257 4.305049-2.569522 10.900258-9.100262 15.659655-10.091846 1.880837-0.38988 3.752464-1.033539 5.611811-1.943258 18.915815-9.314133 29.03836-26.543539 27.069519-46.076408-1.451048-14.461363-13.455453-29.566386-42.797735-28.596292-7.640004 0.252757-15.519462 1.623987-22.781866 3.963265-15.020088 4.845355-100.891851 58.340733-110.154819 37.502126-5.955642-13.403265 32.605605-27.402093 41.409109-31.347962 21.132296-9.466606 44.182268-13.373589 65.581648-22.104437 26.91193-10.980076 71.130014-32.04074 75.275427-65.014736 5.104251-40.612976-44.633546-45.369304-72.502267-40.136116-27.031657 5.078669-52.896744 12.673647-77.589123 25.018813-1.862417 0.933255-3.859911 1.889023-5.930059 1.648546-13.731746-1.593288 2.78237-15.542998 6.14086-17.753339C244.361427 400.046209 257.868045 393.427464 271.709285 387.416564 M566.432727 365.658004c-12.226462-11.811-32.686447-10.939143-48.75747-11.757788-20.536732-1.043772-41.192168 0.070608-61.497633 3.350304-75.191516 12.137435-54.967916 133.555785-40.393989 185.121208 6.725168 23.793916 40.133046 46.989197 57.488319 19.673062 9.198499-14.473643 1.916653-33.547047 1.585101-49.431829-0.313132-15.392572-0.656963-30.79026-0.86981-46.182832-0.319272-23.76424 8.90788-46.573735 31.006178-57.501622 22.234397-10.998495 53.559846-0.539282 64.325028-29.865191 0.887206-2.419096 1.520633-5.052063 0.957815-7.571443C569.845453 369.570103 568.390311 367.549074 566.432727 365.658004 M582.388117 392.262942c-11.023054 13.939477-10.873652 47.750537-11.437493 64.707744-0.586354 17.634636 1.388627 35.198663 4.034896 52.608172 0.832971 5.485945 2.725064 43.529399 16.673751 33.727149 3.596921-2.52859 8.435113-0.706081 12.378935-5.194302 12.890588-14.678304 17.025769-34.983769 18.679431-53.875025 0.952698-10.960633-2.405793-22.618137 0.553609-33.388435 4.76042-17.334807 17.551748-12.81998 31.66314-17.21508 25.586748-7.980765 41.24231-30.269397 12.945847-45.13906C649.435139 378.801349 597.08791 373.672538 582.388117 392.262942z M736.139873 496.272807c-3.832282 2.353604-8.368598 3.053546-13.228279 1.078565-24.283056-9.867742-4.149507-47.554062 21.378913-36.992519-0.147356 0.293689-0.25992 0.595564-0.38681 0.896416 0.309038 0.308015 0.688685 0.539282 0.949628 0.917906C751.596913 472.068546 746.357586 490.011196 736.139873 496.272807zM752.159732 413.68688c-15.767102-6.786567-31.175023-7.724938-45.830815 2.731204-10.084683 7.192819-17.23657 17.887392-22.060435 29.274744-10.021238 23.608697-19.142989 51.077306 2.40477 70.483284 13.657045 12.298094 37.884842 25.13547 56.625672 18.027585 13.382798-5.070482 22.468734-17.929348 28.14399-30.451546 11.054777-24.421202 15.767102-65.370847-8.566096-83.972507C759.845785 417.461857 756.147556 415.401941 752.159732 413.68688z M831.934636 482.111273c0.164752-0.167822 0.306992-0.357134 0.477884-0.522909 17.013489-16.610306 39.110763-10.090822 60.309574-12.124132 3.007497-0.289596 5.5279-3.162016 3.490497-6.037507-9.083889-12.839423-22.604834-18.491143-37.19104-23.449062-8.798387-2.995217-16.394389 3.368724-21.968337 10.380418-1.974981-12.604062-8.864902-22.789029-24.152073-16.647145-22.857591 9.17701-22.583344 48.02069-21.716604 67.3929 0.652869 14.504342 5.808286 45.686529 25.759687 29.064966 10.776438-8.977465 11.877515-33.568537 14.491039-45.938262C831.585689 483.510132 831.766814 482.812237 831.934636 482.111273";
               Image_MessageBox.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 85, 0));
               break;
            case MessageBoxImage.Information:       // Enumeration value 64 - also covers "Asterisk"
               Icon = "M512 0C229.206 0 0 229.289 0 512s229.206 512 512 512 512-229.378 512-512C1024 229.289 794.794 0 512 0z m80.3 700.333c-38.656 58.028-77.911 102.656-144.128 102.656-45.139-7.339-63.66-39.678-53.844-72.617l85.078-281.683c2.05-6.911-1.367-14.25-7.678-16.467-6.228-2.216-18.6 5.972-29.267 17.578l-51.372 61.867c-1.367-10.328-0.083-27.561-0.083-34.473 38.572-58.027 102.06-103.766 145.15-103.766 40.872 4.183 60.16 36.95 53.077 72.872l-85.677 283.044c-1.112 6.484 2.216 12.8 8.105 15.017 6.228 2.133 19.539-5.972 30.206-17.667l51.455-61.866c1.284 10.333-1.022 28.505-1.022 35.505z m-11.433-367.96c-32.6 0-58.878-23.64-58.878-58.623s26.367-58.622 58.878-58.622c32.427 0 58.966 23.639 58.966 58.622s-26.455 58.622-58.966 58.622z";
               Image_MessageBox.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 51, 153, 255));
               break;
            case MessageBoxImage.Question:
               Icon = "M517.12 69.12c-244.59264 0-442.88 198.28736-442.88 442.88 0 244.58752 198.28736 442.88 442.88 442.88 244.58752 0 442.88-198.29248 442.88-442.88C960 267.40736 761.70752 69.12 517.12 69.12zM534.96832 773.56032c-9.10848 8.35072-19.73248 12.90752-32.64512 12.90752-12.90752 0-23.53664-4.56192-32.64512-12.90752-9.10848-9.10848-12.90752-19.7376-12.90752-32.65024 0-12.9024 3.79392-23.54176 12.90752-31.88224 9.1136-9.10848 19.7376-12.90752 32.64512-12.90752 12.90752 0 24.2944 3.79904 33.40288 12.90752 8.35072 8.34048 12.90752 18.97984 12.90752 31.88224C548.6336 754.58048 544.08192 765.2096 534.96832 773.56032zM644.3008 469.86752c-7.58784 9.10848-28.09344 28.8512-61.50144 58.46016-16.70144 14.41792-28.08832 28.08832-35.68128 41.75872-9.87136 16.70144-14.42816 34.9184-14.42816 55.41888l0 17.46944L471.95648 642.97472l0-17.46944c0-25.05216 4.5568-47.06816 13.66528-66.048 10.62912-22.77888 35.6864-51.63008 76.68736-88.07424 12.14464-12.14464 21.25824-21.25824 25.80992-27.33056 15.18592-18.97984 22.77376-38.72256 22.77376-59.9808 0-30.36672-9.10336-53.90336-25.80992-70.6048-17.4592-18.22208-42.5216-26.56768-74.40384-26.56768-37.95968 0-66.048 12.14464-84.27008 37.20192-16.70656 21.25824-25.05728 50.10944-25.05728 87.31136L341.36576 411.41248c0-53.1456 14.42816-95.66208 44.79488-127.54432 30.37184-33.408 72.8832-50.11456 127.54944-50.11456 48.59392 0 87.31136 12.90752 116.92544 40.23296 28.08832 25.81504 42.51648 61.50144 42.51648 107.04896C673.152 415.20128 663.28064 444.81024 644.3008 469.86752z";
               Image_MessageBox.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 51, 153, 255));
               break;
            default:
               Icon= "M512 0C229.206 0 0 229.289 0 512s229.206 512 512 512 512-229.378 512-512C1024 229.289 794.794 0 512 0z m80.3 700.333c-38.656 58.028-77.911 102.656-144.128 102.656-45.139-7.339-63.66-39.678-53.844-72.617l85.078-281.683c2.05-6.911-1.367-14.25-7.678-16.467-6.228-2.216-18.6 5.972-29.267 17.578l-51.372 61.867c-1.367-10.328-0.083-27.561-0.083-34.473 38.572-58.027 102.06-103.766 145.15-103.766 40.872 4.183 60.16 36.95 53.077 72.872l-85.677 283.044c-1.112 6.484 2.216 12.8 8.105 15.017 6.228 2.133 19.539-5.972 30.206-17.667l51.455-61.866c1.284 10.333-1.022 28.505-1.022 35.505z m-11.433-367.96c-32.6 0-58.878-23.64-58.878-58.623s26.367-58.622 58.878-58.622c32.427 0 58.966 23.639 58.966 58.622s-26.455 58.622-58.966 58.622z";
               Image_MessageBox.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 51, 153, 255));
               break;
         }
         Image_MessageBox.Data = PathGeometry.Parse(Icon);
         Image_MessageBox.Visibility = System.Windows.Visibility.Visible;
      }

      private void Button_OK_Click(object sender, RoutedEventArgs e)
      {
         Result = MessageBoxResult.OK;
         Close();
      }

      private void Button_Cancel_Click(object sender, RoutedEventArgs e)
      {
         Result = MessageBoxResult.Cancel;
         Close();
      }

      private void Button_Yes_Click(object sender, RoutedEventArgs e)
      {
         Result = MessageBoxResult.Yes;
         Close();
      }

      private void Button_No_Click(object sender, RoutedEventArgs e)
      {
         Result = MessageBoxResult.No;
         Close();
      }

      private void btnClose_Click(object sender, RoutedEventArgs e)
      {
         Close();
      }

      private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
      {
         this.DragMove();
      }
   }
}
