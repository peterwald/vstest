﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.TestWindow.FullyQualifiedNameUtilities {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class FullyQualifiedNameMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal FullyQualifiedNameMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.VisualStudio.TestWindow.FullyQualifiedNameUtilities.FullyQualifiedNameM" +
                            "essages", typeof(FullyQualifiedNameMessages).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to FullyQualifiedName is incomplete.
        /// </summary>
        internal static string ErrorIncompleteFullyQualifiedName {
            get {
                return ResourceManager.GetString("ErrorIncompleteFullyQualifiedName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method arity must be numeric.
        /// </summary>
        internal static string ErrorMethodArityMustBeNumeric {
            get {
                return ResourceManager.GetString("ErrorMethodArityMustBeNumeric", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method &apos;{0}&apos; not found on type &apos;{1}&apos;.
        /// </summary>
        internal static string ErrorMethodNotFound {
            get {
                return ResourceManager.GetString("ErrorMethodNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type &apos;{0}&apos; not found.
        /// </summary>
        internal static string ErrorTypeNotFound {
            get {
                return ResourceManager.GetString("ErrorTypeNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unexpected characters after the end of the FullyQualifiedName (pos: {0}).
        /// </summary>
        internal static string ErrorUnexpectedCharactersAtEnd {
            get {
                return ResourceManager.GetString("ErrorUnexpectedCharactersAtEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Whitespace is not valid in a FullyQualifiedName (pos: {0}).
        /// </summary>
        internal static string ErrorWhitespaceNotValid {
            get {
                return ResourceManager.GetString("ErrorWhitespaceNotValid", resourceCulture);
            }
        }
    }
}