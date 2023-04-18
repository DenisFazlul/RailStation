﻿#pragma checksum "..\..\..\..\UI\StationUserControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B830F61AF650D3ABA2441E0483661D5711873FEA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Station.UI;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Station.UI {
    
    
    /// <summary>
    /// StationUserControl
    /// </summary>
    public partial class StationUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\..\UI\StationUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox MainGrupBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\UI\StationUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SwithcEditModeButton;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\UI\StationUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreatePark;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\UI\StationUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SerchPath;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\UI\StationUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ParksCombobox;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\UI\StationUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FillPattern;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\UI\StationUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Fill;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\UI\StationUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvasView;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\UI\StationUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Parks;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\UI\StationUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox SelectionView;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\..\UI\StationUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock StatusBar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Station;V1.0.0.0;component/ui/stationusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\StationUserControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MainGrupBox = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 2:
            this.SwithcEditModeButton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\UI\StationUserControl.xaml"
            this.SwithcEditModeButton.Click += new System.Windows.RoutedEventHandler(this.SwithcEditModeButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CreatePark = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\UI\StationUserControl.xaml"
            this.CreatePark.Click += new System.Windows.RoutedEventHandler(this.CreatePark_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SerchPath = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\UI\StationUserControl.xaml"
            this.SerchPath.Click += new System.Windows.RoutedEventHandler(this.SerchPath_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ParksCombobox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.FillPattern = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.Fill = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\UI\StationUserControl.xaml"
            this.Fill.Click += new System.Windows.RoutedEventHandler(this.Fill_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.canvasView = ((System.Windows.Controls.Canvas)(target));
            
            #line 50 "..\..\..\..\UI\StationUserControl.xaml"
            this.canvasView.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.canvasView_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Parks = ((System.Windows.Controls.ListBox)(target));
            
            #line 68 "..\..\..\..\UI\StationUserControl.xaml"
            this.Parks.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Parks_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.SelectionView = ((System.Windows.Controls.ListBox)(target));
            return;
            case 11:
            this.StatusBar = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

