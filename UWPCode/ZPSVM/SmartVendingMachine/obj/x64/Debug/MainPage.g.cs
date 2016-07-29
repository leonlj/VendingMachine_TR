﻿#pragma checksum "C:\Users\leliang\Desktop\VendingMachineCode\UWPCode\ZPSVM\SmartVendingMachine\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "180310A9239C66AF067496DC7E231F00"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartVendingMachine
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_Image_Source(global::Windows.UI.Xaml.Controls.Image obj, global::Windows.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.Source = value;
            }
            public static void Set_Windows_UI_Xaml_UIElement_Visibility(global::Windows.UI.Xaml.UIElement obj, global::Windows.UI.Xaml.Visibility value)
            {
                obj.Visibility = value;
            }
        };

        private class MainPage_obj4_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::SmartVendingMachine.Model.DrinkItem dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private global::Windows.UI.Xaml.ResourceDictionary localResources;
            private global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement> converterLookupRoot;
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBlock obj5;
            private global::Windows.UI.Xaml.Controls.Image obj6;
            private global::Windows.UI.Xaml.Controls.Image obj7;

            public MainPage_obj4_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 5:
                        this.obj5 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 6:
                        this.obj6 = (global::Windows.UI.Xaml.Controls.Image)target;
                        break;
                    case 7:
                        this.obj7 = (global::Windows.UI.Xaml.Controls.Image)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 global::SmartVendingMachine.Model.DrinkItem data = args.NewValue as global::SmartVendingMachine.Model.DrinkItem;
                 if (args.NewValue != null && data == null)
                 {
                    throw new global::System.ArgumentException("Incorrect type passed into template. Based on the x:DataType global::SmartVendingMachine.Model.DrinkItem was expected.");
                 }
                 this.SetDataRoot(data);
                 this.Update();
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                switch(args.Phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(args.Item as global::SmartVendingMachine.Model.DrinkItem);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            ((global::Windows.UI.Xaml.Controls.RelativePanel)args.ItemContainer.ContentTemplateRoot).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::SmartVendingMachine.Model.DrinkItem) args.Item, 1 << (int)args.Phase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
            }

            // IMainPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            // MainPage_obj4_Bindings

            public void SetDataRoot(global::SmartVendingMachine.Model.DrinkItem newDataRoot)
            {
                this.dataRoot = newDataRoot;
            }
            public void SetConverterLookupRoot(global::Windows.UI.Xaml.FrameworkElement rootElement)
            {
                this.converterLookupRoot = new global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement>(rootElement);
            }

            public global::Windows.UI.Xaml.Data.IValueConverter LookupConverter(string key)
            {
                if (this.localResources == null)
                {
                    global::Windows.UI.Xaml.FrameworkElement rootElement;
                    this.converterLookupRoot.TryGetTarget(out rootElement);
                    this.localResources = rootElement.Resources;
                    this.converterLookupRoot = null;
                }
                return (global::Windows.UI.Xaml.Data.IValueConverter) (this.localResources.ContainsKey(key) ? this.localResources[key] : global::Windows.UI.Xaml.Application.Current.Resources[key]);
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::SmartVendingMachine.Model.DrinkItem obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Price(obj.Price, phase);
                        this.Update_ImageSource(obj.ImageSource, phase);
                        this.Update_Discount(obj.Discount, phase);
                    }
                }
            }
            private void Update_Price(global::System.Double obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj5, (global::System.String)this.LookupConverter("DoubleToString").Convert(obj, typeof(global::System.String), null, null), null);
                }
            }
            private void Update_ImageSource(global::Windows.UI.Xaml.Media.Imaging.BitmapImage obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Image_Source(this.obj6, obj, null);
                }
            }
            private void Update_Discount(global::System.Double obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj7, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("BoolToVisibility").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), null, null));
                }
            }
        }

        private class MainPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::SmartVendingMachine.MainPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.GridView obj8;

            private MainPage_obj1_BindingsTracking bindingsTracking;

            public MainPage_obj1_Bindings()
            {
                this.bindingsTracking = new MainPage_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 8:
                        this.obj8 = (global::Windows.UI.Xaml.Controls.GridView)target;
                        break;
                    default:
                        break;
                }
            }

            // IMainPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            // MainPage_obj1_Bindings

            public void SetDataRoot(global::SmartVendingMachine.MainPage newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::SmartVendingMachine.MainPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_DrinkData(obj.DrinkData, phase);
                    }
                }
            }
            private void Update_DrinkData(global::Windows.UI.Xaml.Data.CollectionViewSource obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_DrinkData(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_DrinkData_View(obj.View, phase);
                    }
                }
            }
            private void Update_DrinkData_View(global::Windows.UI.Xaml.Data.ICollectionView obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj8, obj, null);
                }
            }

            private class MainPage_obj1_BindingsTracking
            {
                global::System.WeakReference<MainPage_obj1_Bindings> WeakRefToBindingObj; 

                public MainPage_obj1_BindingsTracking(MainPage_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<MainPage_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_DrinkData(null);
                }

                public void DependencyPropertyChanged_DrinkData_View(global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop)
                {
                    MainPage_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        global::Windows.UI.Xaml.Data.CollectionViewSource obj = sender as global::Windows.UI.Xaml.Data.CollectionViewSource;
        if (obj != null)
        {
            bindings.Update_DrinkData_View(obj.View, DATA_CHANGED);
        }
                    }
                }
                private global::Windows.UI.Xaml.Data.CollectionViewSource cache_DrinkData = null;
                private long tokenDPC_DrinkData_View = 0;
                public void UpdateChildListeners_DrinkData(global::Windows.UI.Xaml.Data.CollectionViewSource obj)
                {
                    if (obj != cache_DrinkData)
                    {
                        if (cache_DrinkData != null)
                        {
                            cache_DrinkData.UnregisterPropertyChangedCallback(global::Windows.UI.Xaml.Data.CollectionViewSource.ViewProperty, tokenDPC_DrinkData_View);
                            cache_DrinkData = null;
                        }
                        if (obj != null)
                        {
                            cache_DrinkData = obj;
                            tokenDPC_DrinkData_View = obj.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Data.CollectionViewSource.ViewProperty, DependencyPropertyChanged_DrinkData_View);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2:
                {
                    this.DrinkData = (global::Windows.UI.Xaml.Data.CollectionViewSource)(target);
                }
                break;
            case 3:
                {
                    this.DrinkGridViewTemplate = (global::Windows.UI.Xaml.DataTemplate)(target);
                }
                break;
            case 8:
                {
                    this.DrinksView = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    #line 81 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.GridView)this.DrinksView).SelectionChanged += this.DrinksView_SelectionChanged;
                    #line default
                }
                break;
            case 9:
                {
                    this.PaymentView = (global::Windows.UI.Xaml.Controls.Primitives.Popup)(target);
                }
                break;
            case 10:
                {
                    this.PaymentQuickpassPopup = (global::Windows.UI.Xaml.Controls.Primitives.Popup)(target);
                }
                break;
            case 11:
                {
                    this.PaymentSecondViewCloseBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 214 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.PaymentSecondViewCloseBtn).Click += this.PaymentSecondViewCloseBtn_Click;
                    #line default
                }
                break;
            case 12:
                {
                    this.PaymentSecondViewBackBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 224 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.PaymentSecondViewBackBtn).Click += this.PaymentSecondViewBackBtn_Click;
                    #line default
                }
                break;
            case 13:
                {
                    this.PaymentImg = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 235 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)this.PaymentImg).Tapped += this.PaymentImg_Tapped;
                    #line default
                }
                break;
            case 14:
                {
                    this.PaymentCloseBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 117 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.PaymentCloseBtn).Click += this.PaymentCloseBtn_Click;
                    #line default
                }
                break;
            case 15:
                {
                    this.LeftPanel = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 16:
                {
                    this.RightPanel = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 17:
                {
                    this.RightTopPanel = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 18:
                {
                    this.RightBottomPanel = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 19:
                {
                    this.PaymentQuickpass = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 177 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)this.PaymentQuickpass).Tapped += this.PaymentQuickpass_Tapped;
                    #line default
                }
                break;
            case 20:
                {
                    this.PaymentWechat = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 185 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)this.PaymentWechat).Tapped += this.PaymentWechat_Tapped;
                    #line default
                }
                break;
            case 21:
                {
                    this.PaymentCash = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 195 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)this.PaymentCash).Tapped += this.PaymentCash_Tapped;
                    #line default
                }
                break;
            case 22:
                {
                    this.PayDrinkName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 23:
                {
                    this.PayDrinkSize = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 24:
                {
                    this.PaymentDrinkPrice = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 25:
                {
                    this.PaymentDrinkPic = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 26:
                {
                    this.Admin = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 27:
                {
                    this.AdvertisePic = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    MainPage_obj1_Bindings bindings = new MainPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.RelativePanel element4 = (global::Windows.UI.Xaml.Controls.RelativePanel)target;
                    MainPage_obj4_Bindings bindings = new MainPage_obj4_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot((global::SmartVendingMachine.Model.DrinkItem) element4.DataContext);
                    bindings.SetConverterLookupRoot(this);
                    element4.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element4, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

