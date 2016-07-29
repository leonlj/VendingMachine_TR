using ConnectLayer.DataEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace SmartVendingMachine.Model
{
    public class DrinkItem : INotifyPropertyChanged, IComparable
    {
        


        private String channelId;

        public String ChannelId
        { 
            get { return channelId; }
            set {
                if (value != channelId) {
                    channelId = value;
                    NotifyPropertyChanged("ChannelId");
                }
            }
        }

        private String id;

        public String Id
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set
            {
                if (value != price)
                {
                    price = value;
                    NotifyPropertyChanged("Price");
                }
            }
        }

        private double discount;

        public double Discount
        {
            get { return discount; }
            set
            {
                if (value != discount)
                {
                    discount = value;
                    NotifyPropertyChanged("Discount");
                }
            }
        }

        private BitmapImage imageSource;

        public BitmapImage ImageSource
        {
            get { return imageSource; }
            set
            {
                if (value != imageSource)
                {
                    imageSource = value;
                    NotifyPropertyChanged("ImageSource");
                }
            }
        }

        private String drinkName;

        public String DrinkName
        {
            get { return drinkName; }
            set
            {
                if (value != drinkName)
                {
                    drinkName = value;
                    NotifyPropertyChanged("DrinkName");
}
            }
        }

        public static List<BitmapImage> sources;

        public DrinkItem()
        {
            // default values for each property.
            Id = "id";
            Price = 2.5;
            Discount = 0.9;
            ImageSource = null;
            if (sources == null) generateImageSource();
        }

        private static void generateImageSource()
        {
            sources = new List<BitmapImage>()
            {
                new BitmapImage(new Uri("ms-appx:///Assets/home_01.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_02.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_03.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_04.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_05.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_06.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_07.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_08.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_09.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_10.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_11.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_12.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_13.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_14.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_15.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_16.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_17.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_18.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_19.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_20.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_21.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_22.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_23.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/home_24.png"))
            };
            return ;
        }

        //TEST code

        public static DrinkItem GetNewDrink(int i)
        {
            int id = i%24;
            if (DrinkItem.sources == null) DrinkItem.generateImageSource();
            return new DrinkItem()
            {
                Id = ""+id,
                Price = GeneratePrice(),
                Discount = GenerateDiscount(),
                ImageSource = sources[id]
            };
        }

        public static ObservableCollection<DrinkItem> GetDrinkList(int numberOfDrinks)
        {
            ObservableCollection<DrinkItem> drinks = new ObservableCollection<DrinkItem>();

            for (int i = 0; i < numberOfDrinks; i++)
            {
                drinks.Add(GetNewDrink(i));
            }
            return drinks;
        }

        public static DrinkItem GetNewDrink(Channelinfo drink)
        {
            
            if (DrinkItem.sources == null) DrinkItem.generateImageSource();
            double disPrice = Double.Parse(drink.discountPrice);
            double listPrice = Double.Parse(drink.listPrice);
            BitmapImage bitmap = drink.productImageUrl.StartsWith("http") ?
                  new BitmapImage(new Uri(drink.productImageUrl)) :
                  new BitmapImage(new Uri("ms-appx:///Assets/" + drink.productImageUrl + ".png"));
            DrinkItem di = new DrinkItem()
            {
                Id = drink.skuId,
                Price = Double.Parse(drink.listPrice),
                Discount = disPrice == 0 || listPrice == 0 ? 1 : Double.Parse(drink.discountPrice) / Double.Parse(drink.listPrice),
                ImageSource =bitmap,
                DrinkName = drink.skuName,
                ChannelId = drink.channelId
            };

            if (disPrice > 0)
            {
                di.Price = disPrice;
            }

            return di;
        }

        public static ObservableCollection<DrinkItem> GetDrinkList(Channelinfo[] drinksinfo)
        {
            ObservableCollection<DrinkItem> drinks = new ObservableCollection<DrinkItem>();

            for (int i = 0; i < drinksinfo.Length; i++)
            {
                drinks.Add(GetNewDrink(drinksinfo[i]));
            }
            drinks = new ObservableCollection<DrinkItem>(drinks.OrderBy(item => item.channelId));
            return drinks;
        }

        

        private static Random random = new Random();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private static int GenerateId()
        {
            return random.Next(0, 23);
        }

        private static double GeneratePrice()
        {
            return random.Next(4, 7)/2;
        }

        private static double GenerateDiscount()
        {
            return random.Next(9, 11)/10.0;
        }

        public int CompareTo(object obj)
        {
            int result;
            try
            {
                DrinkItem info = obj as DrinkItem;
                int thisid = int.Parse(this.channelId);
                int thatid = int.Parse(info.channelId);
                if (thisid > thatid)
                {
                    result = 0;
                }
                else
                    result = 1;
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
    }
}
