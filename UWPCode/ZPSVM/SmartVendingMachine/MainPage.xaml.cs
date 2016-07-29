using SmartVendingMachine.Model;
using ConnectLayer;
using ConnectLayer.DataEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.UI;
using Windows.UI.Xaml.Media.Imaging;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SmartVendingMachine
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        UploadMeg um = new UploadMeg();
        public ObservableCollection<DrinkItem> drinks;
        String[] paymentWay = { "CASH", "WECHAT", "QUICKPASS" };
        String thePayWay = "unknown";
        DrinkItem clickDrink;
        private DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        bool Isrefresh = false;

        public MainPage()
        {
            this.InitializeComponent();

            _dispatcherTimer.Tick += _dispatcherTimer_Tick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            _dispatcherTimer.Start();

            TransactionRecords tr = new TransactionRecords()
            {
                deviceId = localSettingsHelper.DeviceId,
                countNo = 1,
                transactionTime = DateTime.Now,
                channelId = "02",
                payType = "WECHAT",
                payBatchNo = Guid.NewGuid().ToString(),
                payFee = 3.0
            };

            AddProductsRecords apr = new AddProductsRecords()
            {
                addProductNo = 1,
                channelId = "01",
                deviceId = localSettingsHelper.DeviceId,
                addTime = DateTime.Now
            };


            //上传消息
            //um.SendDeviceToCloudMessagesAsync(tr);
            //um.SendDeviceToCloudMessagesAsync(apr);

            //return;
            ////前端注册获取下发消息事件
            um.ADinfoReceived += Um_ADinfoReceived;
            um.ChannelinfoReceived += Um_ChannelinfoReceived;
            this.Loaded += MainPage_Loaded;
            //drinks = new ObservableCollection<DrinkItem>();
            //DrinkData.Source = DrinkItem.GetDrinkList(24);
        }

        private void _dispatcherTimer_Tick(object sender, object e)
        {
            Random random = new Random();
            VMStatusRecords vmr = new VMStatusRecords()
            {
                deviceId = localSettingsHelper.DeviceId,
                temperature = (random.Next(50, 100) / 10.0).ToString(),
                voltDrop = random.Next(210, 230),
                powerDraw = random.Next(10, 30),
                dutyCycle = (random.Next(10, 100) / 10.0),
                healthFlag = "HEALTH",
                addDate = DateTime.Now,
            };
            um.SendDeviceToCloudMessagesAsync(vmr);
        }

        private void Um_ChannelinfoReceived(object sender, EventArgs e)
        {
            Channelinfo[] ChannelList = (Channelinfo[])sender;
            Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                if (ChannelList.Count() == 1)
                {
                    ObservableCollection<DrinkItem> diCollection = DrinkData.Source as ObservableCollection<DrinkItem>;

                    DrinkItem diUpdate = DrinkItem.GetDrinkList(ChannelList)[0];

                    for (int i = 0; i < diCollection.Count; i++)
                    {
                        DrinkItem item = diCollection[i];
                        if (item.ChannelId == diUpdate.ChannelId)
                        {
                            diCollection[i] = diUpdate;
                        }
                        Isrefresh = true;
                        DrinkData.Source = diCollection;
                        return;
                    }
                }
                else
                {
                    Isrefresh = true;
                    DrinkData.Source = DrinkItem.GetDrinkList(ChannelList);
                }
            }).AsTask();
        }

        private void Um_ADinfoReceived(object sender, EventArgs e)
        {
            Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                ADinfo adInfo = (ADinfo)sender;
                AdvertisePic.Source = new BitmapImage(new Uri(adInfo.contentUrl));
            }).AsTask();
        }

        //private void Um_MegReceived(object sender, EventArgs e)
        //{
        //    Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        //    {
        //        MessageDialog msgDialog = new MessageDialog(sender.ToString());
        //        msgDialog.ShowAsync();
        //    });
        //}

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //注册设备并保存token
            string test = await new Register().Enroll(localSettingsHelper.DeviceId);
        }



        private void PaymentCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PaymentView.IsOpen)
            {
                PaymentView.IsOpen = false;
            }
        }

        private void PaymentQuickpass_Tapped(object sender, TappedRoutedEventArgs e)
        {

            PaymentQuickpassPopup.IsOpen = true;
            PaymentQuickpassPopup.HorizontalOffset = 50;//Window.Current.Bounds.Width/2 - 494;
            PaymentQuickpassPopup.VerticalOffset = 634;//Window.Current.Bounds.Height/2 - ;
            PaymentImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/pay_quickpass2.png"));
            thePayWay = paymentWay[2];
        }

        private void PaymentSecondViewBackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PaymentQuickpassPopup.IsOpen)
            {
                PaymentQuickpassPopup.IsOpen = false;
            }
        }

        private void PaymentWechat_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PaymentQuickpassPopup.IsOpen = true;
            PaymentQuickpassPopup.HorizontalOffset = 50;//Window.Current.Bounds.Width/2 - 494;
            PaymentQuickpassPopup.VerticalOffset = 634;//Window.Current.Bounds.Height/2 - ;
            PaymentImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/pay_wechat2.png"));
            thePayWay = paymentWay[1];
        }

        private void PaymentCash_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PaymentQuickpassPopup.IsOpen = true;
            PaymentQuickpassPopup.HorizontalOffset = 50;//Window.Current.Bounds.Width/2 - 494;
            PaymentQuickpassPopup.VerticalOffset = 634;//Window.Current.Bounds.Height/2 - ;
            PaymentImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/pay_cash2.png"));
            thePayWay = paymentWay[0];
        }

        private void PaymentSecondViewCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PaymentQuickpassPopup.IsOpen)
            {
                PaymentQuickpassPopup.IsOpen = false;
            }
        }

        private void DrinksView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Isrefresh) { Isrefresh = false; return; }
            if (DrinksView.SelectedItem == null) return;
            DrinkItem drink = (DrinkItem)((GridView)sender).SelectedItem;
            if (drink == null) return;
            PaymentDrinkPic.Source = drink.ImageSource;
            PaymentDrinkPrice.Text = "¥" + drink.Price;
            PayDrinkName.Text = drink.DrinkName;
            //theChannelId = drink.ChannelId;
            clickDrink = drink;
            Debug.WriteLine("name:" + drink.DrinkName + ",price:" + drink.Price);
            if (!PaymentView.IsOpen)
            {
                //RootPopupBorder.Width = 646;
                PaymentView.HorizontalOffset = 50;//Window.Current.Bounds.Width/2 - 494;
                PaymentView.VerticalOffset = 634;//Window.Current.Bounds.Height/2 - ;
                PaymentView.IsOpen = true;
            }
        }

        private void PaymentImg_Tapped(object sender, TappedRoutedEventArgs e)
        {

            TransactionRecords tr = new TransactionRecords()
            {
                deviceId = localSettingsHelper.DeviceId,
                countNo = 1,
                transactionTime = DateTime.Now,
                channelId = clickDrink.ChannelId,
                payType = "WECHAT",
                //payType = thePayWay,
                payBatchNo = Guid.NewGuid().ToString(),
                payFee = clickDrink.Price
            };
            PaymentView.IsOpen = false;
            PaymentQuickpassPopup.IsOpen = false;
            um.SendDeviceToCloudMessagesAsync(tr);
        }
    }
}
