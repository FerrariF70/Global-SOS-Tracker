﻿#pragma checksum "..\..\AuthorizationAPIMedicalCards.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97AAC104347265160A1D7AC01607886A68C8C877"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AppGST;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace AppGST {
    
    
    /// <summary>
    /// AuthorizationAPIMedicalCards
    /// </summary>
    public partial class AuthorizationAPIMedicalCards : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\AuthorizationAPIMedicalCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox user;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AuthorizationAPIMedicalCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Key;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AuthorizationAPIMedicalCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox user_id;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\AuthorizationAPIMedicalCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button subbmitButton;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\AuthorizationAPIMedicalCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button page1;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\AuthorizationAPIMedicalCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button page2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AppGST;component/authorizationapimedicalcards.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AuthorizationAPIMedicalCards.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.user = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Key = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.user_id = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.subbmitButton = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\AuthorizationAPIMedicalCards.xaml"
            this.subbmitButton.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.page1 = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\AuthorizationAPIMedicalCards.xaml"
            this.page1.MouseEnter += new System.Windows.Input.MouseEventHandler(this.MouseEnter_Page1);
            
            #line default
            #line hidden
            
            #line 42 "..\..\AuthorizationAPIMedicalCards.xaml"
            this.page1.MouseLeave += new System.Windows.Input.MouseEventHandler(this.MouseLeave_Page1);
            
            #line default
            #line hidden
            
            #line 42 "..\..\AuthorizationAPIMedicalCards.xaml"
            this.page1.Click += new System.Windows.RoutedEventHandler(this.Page1_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.page2 = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
