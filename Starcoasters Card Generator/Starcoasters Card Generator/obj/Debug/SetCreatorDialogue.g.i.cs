﻿#pragma checksum "..\..\SetCreatorDialogue.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23D1336FEE5D8FE353CEE3C7ECAA0D586114A1F1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Starcoasters_Card_Generator;
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


namespace Starcoasters_Card_Generator {
    
    
    /// <summary>
    /// SetCreatorDialogue
    /// </summary>
    public partial class SetCreatorDialogue : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\SetCreatorDialogue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBX_SetName;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\SetCreatorDialogue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBL_SetCodePreviewer;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\SetCreatorDialogue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBL_SetCode;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\SetCreatorDialogue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_MakeSet;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\SetCreatorDialogue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_Cancel;
        
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
            System.Uri resourceLocater = new System.Uri("/Starcoasters Card Generator;component/setcreatordialogue.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SetCreatorDialogue.xaml"
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
            this.TBX_SetName = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\SetCreatorDialogue.xaml"
            this.TBX_SetName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TBX_SetName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TBL_SetCodePreviewer = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TBL_SetCode = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.BTN_MakeSet = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\SetCreatorDialogue.xaml"
            this.BTN_MakeSet.Click += new System.Windows.RoutedEventHandler(this.BTN_MakeSet_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BTN_Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\SetCreatorDialogue.xaml"
            this.BTN_Cancel.Click += new System.Windows.RoutedEventHandler(this.BTN_Cancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

