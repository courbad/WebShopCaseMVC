﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TryCatch.Resources.Views {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Products {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Products() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TryCatch.Resources.Views.Products", typeof(Products).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to to cart.
        /// </summary>
        public static string BtnToCart {
            get {
                return ResourceManager.GetString("BtnToCart", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name.
        /// </summary>
        public static string ThName {
            get {
                return ResourceManager.GetString("ThName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Price.
        /// </summary>
        public static string ThPrice {
            get {
                return ResourceManager.GetString("ThPrice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Price (ex. VAT).
        /// </summary>
        public static string ThPriceExVat {
            get {
                return ResourceManager.GetString("ThPriceExVat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Price (inc. VAT).
        /// </summary>
        public static string ThPriceWithVat {
            get {
                return ResourceManager.GetString("ThPriceWithVat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to VAT.
        /// </summary>
        public static string ThVat {
            get {
                return ResourceManager.GetString("ThVat", resourceCulture);
            }
        }
    }
}
