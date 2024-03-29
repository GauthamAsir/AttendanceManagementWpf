﻿#pragma checksum "..\..\..\..\screens\User\DashboardUserWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EE18C41317CCBC34D2EB003D592E174B11C62DFF109C3B920D30863F937031A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AttendanceManagementWPF;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace AttendanceManagementWPF {
    
    
    /// <summary>
    /// DashboardUserWindow
    /// </summary>
    public partial class DashboardUserWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\screens\User\DashboardUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label roleLabel;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\screens\User\DashboardUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid dasboard_my_attendance;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\screens\User\DashboardUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid dasboard_my_leave;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\screens\User\DashboardUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid dasboard_leave_approvals;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\..\screens\User\DashboardUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid dasboard_attendance_approval;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\..\screens\User\DashboardUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid logout_menu_item;
        
        #line default
        #line hidden
        
        
        #line 197 "..\..\..\..\screens\User\DashboardUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frame;
        
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
            System.Uri resourceLocater = new System.Uri("/AttendanceManagementWPF;component/screens/user/dashboarduserwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\screens\User\DashboardUserWindow.xaml"
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
            this.roleLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.dasboard_my_attendance = ((System.Windows.Controls.Grid)(target));
            
            #line 53 "..\..\..\..\screens\User\DashboardUserWindow.xaml"
            this.dasboard_my_attendance.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.selectItem);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dasboard_my_leave = ((System.Windows.Controls.Grid)(target));
            
            #line 80 "..\..\..\..\screens\User\DashboardUserWindow.xaml"
            this.dasboard_my_leave.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.selectItem);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dasboard_leave_approvals = ((System.Windows.Controls.Grid)(target));
            
            #line 107 "..\..\..\..\screens\User\DashboardUserWindow.xaml"
            this.dasboard_leave_approvals.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.selectItem);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dasboard_attendance_approval = ((System.Windows.Controls.Grid)(target));
            
            #line 134 "..\..\..\..\screens\User\DashboardUserWindow.xaml"
            this.dasboard_attendance_approval.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.selectItem);
            
            #line default
            #line hidden
            return;
            case 6:
            this.logout_menu_item = ((System.Windows.Controls.Grid)(target));
            
            #line 162 "..\..\..\..\screens\User\DashboardUserWindow.xaml"
            this.logout_menu_item.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.selectItem);
            
            #line default
            #line hidden
            return;
            case 7:
            this.frame = ((System.Windows.Controls.Frame)(target));
            
            #line 204 "..\..\..\..\screens\User\DashboardUserWindow.xaml"
            this.frame.Navigating += new System.Windows.Navigation.NavigatingCancelEventHandler(this.frameNavigation);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

