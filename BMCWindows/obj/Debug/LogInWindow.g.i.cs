﻿#pragma checksum "..\..\LogInWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9BC80C8A9B0CDFB3E585B5B335BA8B4F148079FE136658FC4FA1B17DA1B2DF23"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BMCWindows;
using BMCWindows.Properties;
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


namespace BMCWindows {
    
    
    /// <summary>
    /// LogIn
    /// </summary>
    public partial class LogIn : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\LogInWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonLogIn;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\LogInWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxUser;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\LogInWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxPassword;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\LogInWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonGoBack;
        
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
            System.Uri resourceLocater = new System.Uri("/BMCWindows;component/loginwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LogInWindow.xaml"
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
            this.buttonLogIn = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\LogInWindow.xaml"
            this.buttonLogIn.Click += new System.Windows.RoutedEventHandler(this.GoToHomePage);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBoxUser = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.textBoxPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ButtonGoBack = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\LogInWindow.xaml"
            this.ButtonGoBack.Click += new System.Windows.RoutedEventHandler(this.Cancel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

